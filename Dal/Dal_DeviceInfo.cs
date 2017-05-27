using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data.SQLite;

namespace Dal
{
    public class Dal_DeviceInfo
    {
        public static DataTable GetHostNumber()
        {
            string cmdtext = " select DISTINCT HostNumber from CbDeviceInfo order by HostNumber asc ";
            DataTable dt = Dbhelper.Db.ToTable(cmdtext);
            return dt;
        }
        
    }
}
