using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbCardCountingState
    {

        /// <summary>
        /// 主键
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 使用编号
        /// </summary>
        public string UseNumber { get; set; }

        /// <summary>
        /// 计数
        /// </summary>
        public int UseCounting { get; set; }

        /// <summary>
        /// 功能
        /// </summary>
        public int UseFunction { get; set; }

    }
}
