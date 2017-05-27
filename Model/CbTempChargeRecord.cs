using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    /// <summary>
    /// 临时收费记录表
    /// </summary>
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbTempChargeRecord
    {
        /// <summary>
        /// 主键
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// 入口时间
        /// </summary>
        public DateTime EntranceTime { get; set; }

        /// <summary>
        /// 出口时间
        /// </summary>
        public DateTime ExportTime { get; set; }

        /// <summary>
        ///应收金额
        /// </summary>
        public double ChargeAmount { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        public double ActualAmount { get; set; }

        /// <summary>
        /// 出口编号
        /// </summary>
        public int ExitNumber { get; set; }

        /// <summary>
        /// 收费用户
        /// </summary>
        public string ManageName { get; set; }


    }
}
