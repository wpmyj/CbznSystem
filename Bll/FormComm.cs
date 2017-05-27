using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Bll
{
    public class FormComm
    {
        public static int GetPage(int count, int rowcount, Label description)
        {
            int page = count / rowcount;
            if (count % rowcount > 0) page++;
            description.Text = string.Format("总计 {0} 条记录，共 {1} 页", count, page);
            return page;
        }


        public static void DrawBtnEnabled(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled) return;
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.FillRectangle(new SolidBrush(Color.FromArgb(160, 160, 160)), rect);
            g.DrawString(btn.Text, btn.Font, new SolidBrush(btn.ForeColor), rect, sf);
        }

        public static T GetDataSourceToClass<T>(DataGridView dgv, ref int index)
        {
            index = dgv.SelectedRows[0].Index;
            return GetDataSourceToClass<T>(dgv, index);
        }

        public static T GetDataSourceToClass<T>(DataGridView dgv, int index)
        {
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            T t = Activator.CreateInstance<T>();
            foreach (PropertyInfo item in pinfos)
            {
                object obj = dgv[item.Name, index].Value;
                if (obj == DBNull.Value) continue;
                item.SetValue(t, obj, null);
            }
            return t;
        }

        public static void UpdateDgvDataSource<T>(T value, DataGridView dgv, int index)
        {
            DataTable dt = dgv.DataSource as DataTable;
            if (dt == null)
            {
                dt = GetDgvDataSource<T>(dgv);
            }
            PropertyInfo[] pinfs = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            DataRow dr = dt.Rows[index];
            foreach (PropertyInfo item in pinfs)
            {
                dr[item.Name] = item.GetValue(value, null);
            }
        }

        public static void AddDgvSource<T>(T value, DataGridView dgv)
        {
            DataTable dt = dgv.DataSource as DataTable;
            if (dt == null)
            {
                dt = GetDgvDataSource<T>(dgv);
                dgv.DataSource = dt;
            }
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo item in pinfos)
            {
                dr[item.Name] = item.GetValue(value, null);
            }
            dt.Rows.Add(dr);
        }

        private static DataTable GetDgvDataSource<T>(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo item in pinfos)
            {
                dt.Columns.Add(new DataColumn(item.Name, item.PropertyType));
            }
            return dt;
        }
    }
}
