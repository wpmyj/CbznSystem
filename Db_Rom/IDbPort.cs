using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Db_Rom
{
    public interface IDbPort
    {
        string ConnectionStr { get; }

        T FirstDefault<T>();

        T FirstDefault<T>(long id);

        T FirstDefault<T>(string where);

        List<T> ToList<T>();

        List<T> ToList<T>(string where);

        List<T> ToList<T>(int page, int count);

        List<T> ToList<T>(int page, int count, string where);

        List<T> ToList<T>(int page, int count, string where, bool orderby);

        List<T> ToList<T>(int page, int count, string where, string column, bool orderby);

        DataTable ToTable<T>();

        DataTable ToTable<T>(string where);

        DataTable ToTable<T>(int page, int count);

        DataTable ToTable<T>(int page, int count, string where);

        DataTable ToTable<T>(int page, int count, string where, bool orderby);

        DataTable ToTable<T>(int page, int count, string where, string orderbycolumn, bool orderby);

        DataTable GetAggregate<T>(AggregateFuncion aggregate);

        DataTable GetAggregate<T>(AggregateFuncion aggregate, string where);

        DataTable GetAggregate<T>(AggregateFuncion[] aggregates);

        DataTable GetAggregate<T>(AggregateFuncion[] aggregates, string where);

        int Del<T>();

        int Del<T>(long id);

        int Del<T>(string where);

        int Del<T>(T[] values);

        int Update<T>(T value);
          
        int Update<T>(T[] values);
        
        int GetCount<T>();

        int GetCount<T>(string column);

        int GetCount<T>(string column, string where);

        DataTable GetCount<T>(AggregateParam[] param);

        DataTable GetCount<T>(AggregateParam[] param, string where);

        int Insert<T>(T value);

        int Insert<T>(T[] values);

        int ExecuteNonQuery(string cmdtext);

        int ExecuteNonQuery(string cmdtext, IDataParameter[] param);

        DataTable ToTable(string cmdtext);

        DataTable ToTable(string cmdtext, DbParameter[] param);

        DataSet ToDataSet(string cmdtext);

        DataSet ToDataSet(string cmdtext, DbParameter[] param);

        int Insert<T>(DataTable dt);

        int Update<T>(DataTable dt);

    }
}
