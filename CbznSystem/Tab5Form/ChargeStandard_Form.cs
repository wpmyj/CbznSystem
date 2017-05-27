using Dal;
using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    /// <summary>
    /// 收费标准
    /// </summary>
    public partial class ChargeStandard_Form : Form
    {
        private CbChargeParameter _mChargeParam;

        public ChargeStandard_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += ChargeStandardForm_Load;
            this.KeyDown += ChargeStandard_Form_KeyDown;

            cb_ChargeMode.SelectedIndexChanged += Cb_ChargeMode_SelectedIndexChanged;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void ChargeStandard_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            try
            {
                int chargemode = cb_ChargeMode.SelectedIndex;
                int openmode = cb_OpenMode.SelectedIndex;
                int freeminutes = (int)ud_FreeMinutes.Value;
                double dailylimit = (double)ud_DailyLimit.Value;
                int firstcharge = (int)ud_FirstCharge.Value;
                double firstmoney = (double)ud_FirstMoney.Value;
                int twocharge = (int)ud_TwoCharge.Value;
                double twomoney = (double)ud_TwoMoney.Value;
                int threecharge = (int)ud_ThreeCharge.Value;
                double threemoney = (double)ud_ThreeMoney.Value;
                int fourcharge = (int)ud_FourCharge.Value;
                double fourmoney = (double)ud_FourMoney.Value;
                int fivecharge = (int)ud_FiveCharge.Value;
                double fivemoney = (double)ud_FiveMoney.Value;
                int sixcharge = (int)ud_SixCharge.Value;
                double sixmoney = (double)ud_SixMoney.Value;

                _mChargeParam.ChargeMode = chargemode;
                _mChargeParam.GateMode = openmode;
                _mChargeParam.FreeMinutes = freeminutes;
                _mChargeParam.DailyLimit = dailylimit;
                _mChargeParam.FirstCharge = firstcharge;
                _mChargeParam.FirstMoney = firstmoney;
                _mChargeParam.TwoCharge = twocharge;
                _mChargeParam.TwoMoney = twomoney;
                _mChargeParam.ThreeCharge = threecharge;
                _mChargeParam.ThreeMoney = threemoney;
                _mChargeParam.FourCharge = fourcharge;
                _mChargeParam.FourMoney = fourmoney;
                _mChargeParam.FiveCharge = fivecharge;
                _mChargeParam.FiveMoney = fivemoney;
                _mChargeParam.SixCharge = sixcharge;
                _mChargeParam.SixMoney = sixmoney;

                if (_mChargeParam.ID == 0)
                {
                    _mChargeParam.ID = Dbhelper.Db.Insert<CbChargeParameter>(_mChargeParam);
                }
                else
                {
                    Dbhelper.Db.Update<CbChargeParameter>(_mChargeParam);
                }
                Dal_ChargeParameter.ChargeParam = _mChargeParam;
                _mChargeParam = null;
                MessageBox.Show("收费标准保存成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cb_ChargeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_ChargeMode.SelectedIndex)
            {
                case 0:
                    NotCharge();
                    break;

                case 1:
                    TimeCharge();
                    break;

                case 2:
                    ParkingFee();
                    break;

                case 3:
                    OnTimeCharge();
                    break;
            }
        }

        private void TimeCharge()
        {
            cb_OpenMode.Enabled = true;
            ud_FreeMinutes.Enabled = true;
            ud_DailyLimit.Enabled = true;
            l_FirstChargeTitle.Text = "首段时间";
            ud_FirstCharge.Enabled = true;
            ud_FirstCharge.Value = 30;
            l_FirstMoneyTitle.Text = "首段金额";
            ud_FirstMoney.Enabled = true;
            ud_FirstMoney.DecimalPlaces = 1;
            ud_FirstMoney.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            ud_FirstMoney.Value = 5;
            l_TwoChargeTitle.Text = "间隔时间";
            ud_TwoCharge.Enabled = true;
            ud_TwoCharge.Value = 60;
            l_TwoMoneyTitle.Text = "间隔金额";
            ud_TwoMoney.Enabled = true;
            ud_TwoMoney.Value = 1;
            ud_ThreeCharge.Enabled = false;
            ud_ThreeMoney.Enabled = false;
            ud_FourCharge.Enabled = false;
            ud_FourMoney.Enabled = false;
            ud_FiveCharge.Enabled = false;
            ud_FiveMoney.Enabled = false;
            ud_SixCharge.Enabled = false;
            ud_SixMoney.Enabled = false;
        }

        private void ParkingFee()
        {
            cb_OpenMode.Enabled = true;
            ud_FreeMinutes.Enabled = true;
            ud_DailyLimit.Enabled = true;
            l_FirstChargeTitle.Text = "首段时间";
            ud_FirstCharge.Enabled = true;
            ud_FirstCharge.Value = 30;
            l_FirstMoneyTitle.Text = "首段金额";
            ud_FirstMoney.Enabled = true;
            ud_FirstMoney.DecimalPlaces = 1;
            ud_FirstMoney.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            ud_FirstMoney.Value = 5;
            l_TwoChargeTitle.Text = "第二段时间";
            ud_TwoCharge.Enabled = true;
            ud_TwoCharge.Value = 240;
            l_TwoMoneyTitle.Text = "第二段金额";
            ud_TwoMoney.Enabled = true;
            ud_TwoMoney.Value = 6;
            l_ThreeChargeTitle.Text = "第三段时间";
            ud_ThreeCharge.Enabled = true;
            ud_ThreeCharge.Value = 480;
            l_ThreeMoneyTitle.Text = "第三段金额";
            ud_ThreeMoney.Enabled = true;
            ud_ThreeMoney.Value = 7;
            l_FourChargeTitle.Text = "第四段时间";
            ud_FourCharge.Enabled = true;
            ud_FourCharge.Value = 720;
            l_FourMoneyTitle.Text = "第四段金额";
            ud_FourMoney.Enabled = true;
            ud_FourMoney.DecimalPlaces = 1;
            ud_FirstMoney.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            ud_FourMoney.Value = 8;
            l_FiveChargeTitle.Text = "第五段时间";
            ud_FiveCharge.Enabled = true;
            ud_FiveCharge.Value = 960;
            l_FiveMoneyTitle.Text = "第五段金额";
            ud_FiveMoney.Enabled = true;
            ud_FiveMoney.Value = 9;
            l_SixChargeTitle.Text = "第六段时间";
            ud_SixCharge.Enabled = true;
            ud_SixCharge.Value = 1440;
            l_SixMoneyTitle.Text = "第六段金额";
            ud_SixMoney.Enabled = true;
            ud_SixMoney.Value = 10;
        }

        private void NotCharge()
        {
            cb_OpenMode.Enabled = false;
            ud_FreeMinutes.Enabled = false;
            ud_DailyLimit.Enabled = false;
            ud_FirstCharge.Enabled = false;
            ud_FirstMoney.Enabled = false;
            ud_TwoCharge.Enabled = false;
            ud_TwoMoney.Enabled = false;
            ud_ThreeCharge.Enabled = false;
            ud_ThreeMoney.Enabled = false;
            ud_FourCharge.Enabled = false;
            ud_FourMoney.Enabled = false;
            ud_FiveCharge.Enabled = false;
            ud_FiveMoney.Enabled = false;
            ud_SixCharge.Enabled = false;
            ud_SixMoney.Enabled = false;
        }

        private void OnTimeCharge()
        {
            cb_OpenMode.Enabled = true;
            ud_FreeMinutes.Enabled = true;
            ud_DailyLimit.Enabled = true;
            l_FirstChargeTitle.Text = "忙时时间";
            ud_FirstCharge.Enabled = true;
            ud_FirstCharge.Value = 960;
            l_FirstMoneyTitle.Text = "截止时间";
            ud_FirstMoney.Enabled = true;
            ud_FirstMoney.DecimalPlaces = 0;
            ud_FirstMoney.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            ud_FirstMoney.Value = 1440;
            l_TwoChargeTitle.Text = "首段时间";
            ud_TwoCharge.Enabled = true;
            ud_TwoCharge.Value = 30;
            l_TwoMoneyTitle.Text = "首段金额";
            ud_TwoMoney.Enabled = true;
            ud_TwoMoney.Value = 5;
            l_ThreeChargeTitle.Text = "间隔时间";
            ud_ThreeCharge.Enabled = true;
            ud_ThreeCharge.Value = 60;
            l_ThreeMoneyTitle.Text = "间隔金额";
            ud_ThreeMoney.Enabled = true;
            ud_ThreeMoney.Value = 1;
            l_FourChargeTitle.Text = "闲时时间";
            ud_FourCharge.Enabled = true;
            ud_FourCharge.Value = 1440;
            l_FourMoneyTitle.Text = "截止时间";
            ud_FourMoney.Enabled = true;
            ud_FourMoney.DecimalPlaces = 0;
            ud_FirstMoney.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            ud_FourMoney.Value = 960;
            l_FiveChargeTitle.Text = "首段时间";
            ud_FiveCharge.Enabled = true;
            ud_FiveCharge.Value = 30;
            l_FiveMoneyTitle.Text = "首段金额";
            ud_FiveMoney.Enabled = true;
            ud_FiveMoney.Value = 5;
            l_SixChargeTitle.Text = "间隔时间";
            ud_SixCharge.Enabled = true;
            ud_SixCharge.Value = 60;
            l_SixMoneyTitle.Text = "间隔金额";
            ud_SixMoney.Enabled = true;
            ud_SixMoney.Value = 1;
        }

        private void ChargeStandardForm_Load(object sender, EventArgs e)
        {
            try
            {
                _mChargeParam = Dbhelper.Db.FirstDefault<CbChargeParameter>();
                if (_mChargeParam == null)
                {
                    _mChargeParam = new CbChargeParameter();
                    cb_ChargeMode.SelectedIndex = 1;
                    cb_OpenMode.SelectedIndex = 1;
                }
                else
                {
                    cb_ChargeMode.SelectedIndex = _mChargeParam.ChargeMode;
                    cb_OpenMode.SelectedIndex = _mChargeParam.GateMode;
                    ud_FreeMinutes.Value = _mChargeParam.FreeMinutes;
                    ud_DailyLimit.Value = (decimal)_mChargeParam.DailyLimit;
                    ud_FirstCharge.Value = _mChargeParam.FirstCharge;
                    ud_FirstMoney.Value = (decimal)_mChargeParam.FirstMoney;
                    ud_TwoCharge.Value = _mChargeParam.TwoCharge;
                    ud_TwoMoney.Value = (decimal)_mChargeParam.TwoMoney;
                    ud_ThreeCharge.Value = _mChargeParam.ThreeCharge;
                    ud_ThreeMoney.Value = (decimal)_mChargeParam.ThreeMoney;
                    ud_FourCharge.Value = _mChargeParam.FourCharge;
                    ud_FourMoney.Value = (decimal)_mChargeParam.FourMoney;
                    ud_FiveCharge.Value = _mChargeParam.FirstCharge;
                    ud_FiveMoney.Value = (decimal)_mChargeParam.FiveMoney;
                    ud_SixCharge.Value = _mChargeParam.SixCharge;
                    ud_SixMoney.Value = (decimal)_mChargeParam.SixMoney;
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static ChargeStandard_Form _uniqueInstance;

        public static ChargeStandard_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new ChargeStandard_Form()); }
        }

    }
}
