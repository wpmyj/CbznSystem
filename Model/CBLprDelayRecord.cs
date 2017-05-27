using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    /// <summary>
    /// 车牌延期记录表
    /// </summary>
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbLprDelayRecord
    {
         /// <summary>
        /// 主键 
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

         /// <summary>
        /// 用户名称
        /// </summary>
        public string LprUserName { get; set; }

        /// <summary>
        /// 车牌号码
        /// </summary>
        public string LprUserPlate { get; set; }

        /// <summary>
        /// 开始期限
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结止期限
        /// </summary>
        public DateTime StopTime { get; set; }

        /// <summary>
        /// 收费金额
        /// </summary>
        public double ChargeAmount { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { get; set; }

    }
}
