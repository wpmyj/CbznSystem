using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    /// <summary>
    /// 操作记录表
    /// </summary>
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbManageLog
    {
        /// <summary>
        /// 主键
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string ManageName { get; set; }

        /// <summary>
        /// 操作说明
        /// </summary>
        public string Explains { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime LogTime { get; set; }

    }
}
