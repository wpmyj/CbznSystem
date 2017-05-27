using System.Data;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Db_Rom
{
    partial class DbComm
    {
        public static string GetPrimaryKey<T>()
        {
            return GetPrimaryKey<T>(Activator.CreateInstance<T>());
        }

        public static string GetPrimaryKey<T>(T t)
        {
            PrimaryKey primaryky = Attribute.GetCustomAttribute(t.GetType(), typeof(PrimaryKey)) as PrimaryKey;
            if (primaryky == null)
                throw new ArgumentNullException(string.Format("实体类{0}没有主键类型，无法完成操作。", typeof(T).Name));
            return primaryky.SetPrimaryKey;
        }

        public static bool GetAutoId<T>(string primarykey)
        {
            PropertyInfo info = typeof(T).GetProperty(primarykey);
            AutoId autoid = Attribute.GetCustomAttribute(info, typeof(AutoId)) as AutoId;
            return autoid.SetAutoId;
        }

        public static string GetPrimaryKeyWhere<T>(long id)
        {
            return string.Format(" and {0}={1} ", GetPrimaryKey<T>(), id);
        }

        public static List<T> DataToClass<T>(DataTable dt)
        {
            PropertyInfo[] infos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            List<T> tlist = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T t = Activator.CreateInstance<T>();
                foreach (PropertyInfo item in infos)
                {
                    item.SetValue(t, row[item.Name], null);
                }
                tlist.Add(t);
            }
            return tlist;
        }

        public static string GetColumnStr<T>()
        {
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] pinfos =
    typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (PropertyInfo item in pinfos)
            {
                sb.AppendFormat(" [{0}],", item.Name);
            }
            sb = sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
