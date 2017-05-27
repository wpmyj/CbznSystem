using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bll;
using Dal;
using Model;
using NewControl;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace CbznSystem
{
    public partial class InputEnterExitRecord_Form : NewForm
    {
        private string[] _FileNames;

        private Thread tInputRecord;

        public InputEnterExitRecord_Form(string[] filenames)
        {
            InitializeComponent();

            this._FileNames = filenames;

            this.Load += InputEnterExitRecord_Form_Load;
            this.FormClosing += InputEnterExitRecord_Form_FormClosing;
        }

        private void InputEnterExitRecord_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tInputRecord == null) return;
            if (MessageBox.Show("确认退出当前操作。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void InputEnterExitRecord_Form_Load(object sender, EventArgs e)
        {
            pBar.Maximum = _FileNames.Length;

            tInputRecord = new Thread(InputRecord);
            tInputRecord.IsBackground = true;
            tInputRecord.Start();
        }

        private void InputRecord()
        {
            List<CbIoRecord> mRecord = new List<CbIoRecord>();
            try
            {
                foreach (string item in _FileNames)
                {
                    if (!CRegex.IsEnterExitRecordFileName(Path.GetFileNameWithoutExtension(item))) continue;
                    this.Invoke(new EventHandler(delegate
                     {
                         l_Title.Text = string.Format("正在导入“{0}”", Path.GetFileNameWithoutExtension(item));
                         pBar.PerformStep();
                     }));
                    using (TextFieldParser tfp = new TextFieldParser(item, Encoding.GetEncoding("gb2312")))
                    {
                        tfp.Delimiters = new string[] { "," };//确认分隔符
                        tfp.TextFieldType = FieldType.Delimited;
                        int number = 0;
                        int state = 0;
                        int count = 0;
                        while (!tfp.EndOfData)
                        {
                            string[] str = tfp.ReadFields();//读取行
                            if (str.Length >= 3)
                            {
                                count++;
                                //888883,000000,20140927151922
                                //组合Sql语句
                                CbIoRecord record = new CbIoRecord();
                                record.DeviceNumber = number;
                                record.IOTime = DateTime.ParseExact(str[2], "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                                record.IOState = state;//0进 1出

                                if (str[0] == "FFFFFF" && str[1] == "FFFFFF")
                                {
                                    string[] str2 = tfp.ReadFields();
                                    if (str2[0] == "FFFFFF" && str2[1] == "FFFFFF")
                                    {

                                    }
                                    else if (str2[0] == "FFFFFF")//车牌识别卡
                                    {
                                        record.MasterCardNumber = str2[1];
                                    }
                                    else //IC卡
                                    {
                                        string icnumber = str2[0] + str2[1];
                                        icnumber = icnumber.Remove(0, 4);
                                        record.MasterCardNumber = icnumber;
                                    }
                                    record.SubCardNumber = str2[2];
                                }
                                else
                                {
                                    record.MasterCardNumber = str[0];
                                    record.SubCardNumber = str[1];
                                }
                                mRecord.Add(record);
                            }
                            else
                            {
                                if (str[0].Contains("!!"))
                                {
                                    number = Utils.StrToInt(str[0].Substring(10, 2), 0);
                                    state = Utils.StrToInt(str[0].Substring(12, 2), 0);
                                }
                            }
                        }
                    }
                }
                this.Invoke(new EventHandler(delegate
                                {
                                    l_Title.Text = "正在保存数据";
                                    Dbhelper.Db.Insert<CbIoRecord>(mRecord.ToArray());
                                    tInputRecord = null;
                                    this.DialogResult = DialogResult.OK;
                                }));
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show("导入失败错误数据：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tInputRecord = null;
                Close();
            }
        }
    }
}
