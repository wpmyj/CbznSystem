using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Db_Rom
{
    public class SqlHelper : IDbPort
    {
        private string _ConnectionStr;

        public SqlHelper(string connectionstr)
        {
            this._ConnectionStr = connectionstr;
        }

        public string ConnectionStr
        {
            get { return _ConnectionStr; }
        }

        public int Del<T>()
        {
            return Del<T>(string.Empty);
        }

        public int Del<T>(string where)
        {
            string cmdtext = string.Format(" delete from {0} where 1=1 {1} ", typeof(T).Name, where);
            return ExecuteNonQuery(cmdtext);
        }

        public int Del<T>(long id)
        {
            return Del<T>(DbComm.GetPrimaryKeyWhere<T>(id));
        }

        public int Del<T>(T[] values)
        {
            StringBuilder sb = new StringBuilder();
            string primarykey = DbComm.GetPrimaryKey<T>();
            string tablename = typeof(T).Name;
            foreach (T item in values)
            {
                sb.AppendFormat(" delete from {0} where 1=1 and {1}={2} ; ", tablename, primarykey, typeof(T).GetProperty(primarykey).GetValue(item, null));
            }
            return ExecuteNonQuery(sb.ToString());
        }

        public int ExecuteNonQuery(string cmdtext)
        {
            return ExecuteNonQuery(cmdtext, null);
        }

        public int ExecuteNonQuery(string cmdtext, IDataParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            SqlCommand comm = new SqlCommand(cmdtext, conn);
            if (param != null)
                comm.Parameters.AddRange(param);
            conn.Open();
            int count;
            try
            {
                count = comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
        public T FirstDefault<T>()
        {
            return FirstDefault<T>(string.Empty);
        }

        public T FirstDefault<T>(string where)
        {
            T t = default(T);
            DataTable dt = ToTable<T>(where);
            List<T> tlist = DbComm.DataToClass<T>(dt);
            if (tlist.Count > 0)
                t = tlist[0];
            return t;
        }

        public T FirstDefault<T>(long id)
        {
            return FirstDefault<T>(DbComm.GetPrimaryKeyWhere<T>(id));
        }

        public DataTable GetAggregate<T>(AggregateFuncion[] aggregates)
        {
            return GetAggregate<T>(aggregates, string.Empty);
        }

        public DataTable GetAggregate<T>(AggregateFuncion[] aggregates, string where)
        {
            StringBuilder sb = new StringBuilder(" Select ");
            foreach (AggregateFuncion item in aggregates)
            {
                switch (item.AggregateType)
                {
                    case AggregateTypes.AVG:
                        sb.AppendFormat(" AVG({0}) ", item.Column);
                        break;
                    case AggregateTypes.SUM:
                        sb.AppendFormat(" SUM({0}) ", item.Column);
                        break;
                    case AggregateTypes.MAX:
                        sb.AppendFormat(" MAX({0}) ", item.Column);
                        break;
                    case AggregateTypes.MIN:
                        sb.AppendFormat(" MIN({0}) ", item.Column);
                        break;
                    case AggregateTypes.COUNT:
                        sb.AppendFormat(" COUNT({0}) ", item.Column);
                        break;
                }
                if (!string.IsNullOrEmpty(item.ColumnAlias))
                {
                    sb.AppendFormat("as {0},", item.ColumnAlias);
                }
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" from {0} where 1=1 {1} ", typeof(T).Name, where);
            return ToTable(sb.ToString());
        }

        public DataTable GetAggregate<T>(AggregateFuncion aggregate)
        {
            return GetAggregate<T>(new AggregateFuncion[] { aggregate }, string.Empty);
        }

        public DataTable GetAggregate<T>(AggregateFuncion aggregate, string where)
        {
            return GetAggregate<T>(new AggregateFuncion[] { aggregate }, where);
        }

        public DataTable ToTable<T>()
        {
            return ToTable<T>(0, 0, string.Empty, string.Empty, false);
        }

        public DataTable ToTable<T>(string where)
        {
            return ToTable<T>(0, 0, where, string.Empty, false);
        }

        public DataTable ToTable<T>(int page, int count)
        {
            return ToTable<T>(page, count, string.Empty, string.Empty, false);
        }

        public DataTable ToTable<T>(int page, int count, string where)
        {
            return ToTable<T>(page, count, where, string.Empty, false);
        }

        public DataTable ToTable<T>(int page, int count, string where, bool orderby)
        {
            return ToTable<T>(page, count, where, string.Empty, orderby);
        }

        public DataTable ToTable<T>(int page, int count, string where, string orderbycolumn, bool orderby)
        {
            /*SELECT * FROM ARTICLE w1
    WHERE ID in
        (
            SELECT top 30 ID FROM
            (
                SELECT top 45030 ID, YEAR FROM ARTICLE ORDER BY YEAR DESC, ID DESC
            ) w ORDER BY w.YEAR ASC, w.ID ASC
        )
    ORDER BY w1.YEAR DESC, w1.ID DESC
             */
            StringBuilder sb = new StringBuilder(" select  ");
            sb.Append(DbComm.GetColumnStr<T>());
            sb.AppendFormat(" from {0} mi where ", typeof(T).Name);
            if (count > 0)
            {
                sb.AppendFormat(" {0} in ( select  top {1} {0} from ( select top {2} {0} from {3} where 1=1 {4} order by {0} desc ) mi1 order by mi1.{0} asc ) ", DbComm.GetPrimaryKey<T>(), count, (page * count) + count, typeof(T).Name, where);
            }
            else
            {
                sb.AppendFormat(" 1=1 {0} ", where);
            }
            if (string.IsNullOrEmpty(orderbycolumn))
                orderbycolumn = DbComm.GetPrimaryKey<T>();
            sb.AppendFormat(" order by mi.{0} ", orderbycolumn);
            sb.AppendFormat(" {0} ", @orderby ? "asc" : "desc");
            return ToTable(sb.ToString());
        }

        public DataTable ToTable(string cmdtext)
        {
            return ToTable(cmdtext, null);
        }

        public DataTable ToTable(string cmdtext, DbParameter[] param)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                SqlCommand comm = new SqlCommand(cmdtext, conn);
                if (param != null)
                {
                    comm.Parameters.AddRange(param);
                }
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dt);
            }
            return dt;
        }


        public DataSet ToDataSet(string cmdtext)
        {
            return ToDataSet(cmdtext, null);
        }

        public DataSet ToDataSet(string cmdtext, DbParameter[] param)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                SqlCommand comm = new SqlCommand(cmdtext, conn);
                if (param != null)
                {
                    comm.Parameters.AddRange(param);
                }
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            return ds;
        }

        public List<T> ToList<T>()
        {
            return ToList<T>(0, 0, string.Empty, string.Empty, false);
        }

        public List<T> ToList<T>(string where)
        {
            return ToList<T>(0, 0, where, string.Empty, false);
        }

        public List<T> ToList<T>(int page, int count)
        {
            return ToList<T>(page, count, string.Empty, string.Empty, false);
        }

        public List<T> ToList<T>(int page, int count, string where)
        {
            return ToList<T>(page, count, where, string.Empty, false);
        }

        public List<T> ToList<T>(int page, int count, string where, bool orderby)
        {
            return ToList<T>(page, count, where, string.Empty, orderby);
        }

        public List<T> ToList<T>(int page, int count, string where, string column, bool orderby)
        {
            DataTable dt = ToTable<T>(page, count, where, column, orderby);
            return DbComm.DataToClass<T>(dt);
        }

        public int Update<T>(T value)
        {
            return Update<T>(new T[] { value });
        }

        public int Update<T>(T[] values)
        {
            string where = string.Empty;
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string primarykey = DbComm.GetPrimaryKey<T>();
            string tablename = typeof(T).Name;
            int count = 0;
            foreach (T value in values)
            {
                sb.Append(" Update " + tablename + " set ");
                foreach (PropertyInfo item in pinfos)
                {
                    if (primarykey == item.Name)
                    {
                        where = string.Format(" and {0}={1} ;", primarykey, item.GetValue(value, null));
                        continue;
                    }
                    sb.AppendFormat("[{0}]=@{0}{1},", item.Name, count);
                    parameters.Add(new SqlParameter(item.Name + count, item.GetValue(value, null)));
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.AppendFormat(" where 1=1 {0} ; ", where);
                count++;
            }
            return ExecuteNonQuery(sb.ToString(), parameters.ToArray());

        }

        public int GetCount<T>()
        {
            return GetCount<T>("*", string.Empty);
        }

        public int GetCount<T>(string column)
        {
            return GetCount<T>(column, string.Empty);
        }

        public int GetCount<T>(string column, string where)
        {
            StringBuilder sb = new StringBuilder(" Select ");
            sb.AppendFormat("Count({0})", column);
            sb.AppendFormat(" from {0} where 1=1 {1} ", typeof(T).Name, where);
            object obj = ExecuteScalar(sb.ToString(), null);
            if (obj != DBNull.Value)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        public object ExecuteScalar(string cmdtext, DbParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            SqlCommand comm = new SqlCommand(cmdtext, conn);
            if (parameters != null)
                comm.Parameters.AddRange(parameters);
            conn.Open();
            object result;
            try
            {
                result = comm.ExecuteScalar();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public DataTable GetCount<T>(AggregateParam[] param)
        {
            return GetCount<T>(param, string.Empty);
        }

        public DataTable GetCount<T>(AggregateParam[] param, string where)
        {
            StringBuilder sb = new StringBuilder(" select ");
            foreach (AggregateParam item in param)
            {
                sb.AppendFormat(" Count({0})", item.Column);
                if (!string.IsNullOrEmpty(item.ColumnAlias))
                {
                    sb.AppendFormat(" as {0}", item.ColumnAlias);
                }
                sb.Append(",");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" from {0} where 1=1 {1} ", typeof(T).Name, where);
            return ToTable(sb.ToString());
        }

        public int Insert<T>(T value)
        {
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string primarykey = DbComm.GetPrimaryKey<T>();
            StringBuilder sbcolumn = new StringBuilder();
            StringBuilder sbvalue = new StringBuilder();
            bool isautoid = false;
            foreach (PropertyInfo item in pinfos)
            {
                if (item.Name == primarykey)
                {
                    AutoId attributeautoid = Attribute.GetCustomAttribute(item, typeof(AutoId)) as AutoId;
                    if (attributeautoid != null)
                        isautoid = attributeautoid.SetAutoId;
                    continue;
                }
                sbcolumn.AppendFormat("[{0}],", item.Name);
                sbvalue.AppendFormat("@{0},", item.Name);
                parameters.Add(new SqlParameter(item.Name, item.GetValue(value, null)));
            }
            sbcolumn = sbcolumn.Remove(sbcolumn.Length - 1, 1);
            sbvalue = sbvalue.Remove(sbvalue.Length - 1, 1);
            sb.AppendFormat(" Insert Into {0}({1}) values({2}) ", typeof(T).Name, sbcolumn.ToString(), sbvalue.ToString());
            if (isautoid)
            {
                sb.AppendFormat(" ; SELECT IDENT_CURRENT('{0}') ", typeof(T).Name);
                object obj = ExecuteScalar(sb.ToString(), parameters.ToArray());
                if (obj != DBNull.Value)
                    return Convert.ToInt32(obj);
            }
            return ExecuteNonQuery(sb.ToString(), parameters.ToArray());
        }

        public int Insert<T>(T[] values)
        {
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            StringBuilder sbcmdtext = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string primarykey = DbComm.GetPrimaryKey<T>();
            int count = 0;
            foreach (T item in values)
            {
                StringBuilder sbcolumn = new StringBuilder();
                StringBuilder sbvalue = new StringBuilder();
                foreach (PropertyInfo info in pinfos)
                {
                    if (info.Name == primarykey) continue;
                    sbcolumn.AppendFormat("[{0}],", info.Name);
                    sbvalue.AppendFormat("@{0}{1},", info.Name, count);
                    parameters.Add(new SqlParameter(info.Name + count, info.GetValue(item, null)));
                }
                sbcolumn = sbcolumn.Remove(sbcolumn.Length - 1, 1);
                sbvalue = sbvalue.Remove(sbvalue.Length - 1, 1);
                sbcmdtext.AppendFormat(" Insert Into {0}({1}) values({2}) ; ", typeof(T).Name, sbcolumn.ToString(), sbvalue.ToString());
                count++;
            }
            return ExecuteNonQuery(sbcmdtext.ToString(), parameters.ToArray());
        }

        public int Insert<T>(DataTable dt)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection(ConnectionStr);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(" select top 1 * from " + typeof(T).Name + " ", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.InsertCommand = builder.GetInsertCommand();
                count = da.Update(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public int Update<T>(DataTable dt)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection(ConnectionStr);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(" select top 1 * from " + typeof(T).Name + " ", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.InsertCommand = builder.GetUpdateCommand();
                count = da.Update(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
    }
}
