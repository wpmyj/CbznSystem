using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbIoRecord
    {
        /// <summary>
        /// 主键
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 主卡卡号
        /// </summary>
        public string MasterCardNumber { get; set; }
        
        /// <summary>
        /// 副卡卡号
        /// </summary>
        public string SubCardNumber { get; set; }

        /// <summary>
        ///  设备编号
        /// </summary>
        public int DeviceNumber { get; set; }

         /// <summary>
        /// 进出状态
        /// </summary>
        public int IOState { get; set; }

        /// <summary>
        /// 进出时间
        /// </summary>
        public DateTime IOTime { get; set; }

    }

}
