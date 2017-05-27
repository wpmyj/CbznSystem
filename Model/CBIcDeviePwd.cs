using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;

namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbIcDeviePwd
    {
         /// <summary>
        /// 主键
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
    }
}
