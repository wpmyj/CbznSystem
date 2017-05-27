using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbManageInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 帐户名
        /// </summary>
        public string ManageName { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string UserName { get; set; }
         
        /// <summary>
        /// 密码
        /// </summary>
        public string ManagePwd { get; set; }


        /// <summary>
        /// 用户类型 0 管理员 1临时管理员 2收费员
        /// </summary>
        public int ManageType { get; set; }
    }
}
