using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Dal
{
    public class Dal_ManageInfo
    {
        public static CbManageInfo ManageInfo;

        public static CbManageInfo GetManage(string account, string password)
        {
            string where = string.Format(" and ManageName ='{0}' and ManagePwd='{1}' ", account, password);
            return Dbhelper.Db.FirstDefault<CbManageInfo>(where);
        }

        public static DataTable GetManageAndRights()
        {
            string cmdtext = " select * from CbManageInfo inner Join CbManageRights on CbManageInfo.ID=CbManageRights.UserID ";
            return Dbhelper.Db.ToTable(cmdtext);
        }
    }
}
