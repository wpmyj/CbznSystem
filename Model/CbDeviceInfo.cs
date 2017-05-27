using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;

namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbDeviceInfo
    {
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 门口编号
        /// </summary>
        public int HostNumber { get; set; }

        /// <summary>
        /// 入口出口  0 进 1 出
        /// </summary>
        public int IOSate { get; set; }

        /// <summary>
        /// 道闸编号
        /// </summary>
        public int DeviceNumber { get; set; }

        /// <summary>
        /// 开闸模式
        /// </summary>
        public int DeviceMode { get; set; }

        /// <summary>
        /// 场分区
        /// </summary>
        public int FieldPartition { get; set; }

        /// <summary>
        /// 返潜回 0 关闭 1 开启
        /// </summary>
        public int AntiSubmarineBack { get; set; }

        /// <summary>
        /// 车辆检测 0 关闭 1 开启
        /// </summary>
        public int VehicleDetection { get; set; }

        /// <summary>
        /// 读卡距离
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// 读卡延迟
        /// </summary>
        public int EquipmentDelay { get; set; }

        /// <summary>
        /// 语言种类
        /// </summary>
        public int Language { get; set; }

        /// <summary>
        /// 车牌识别
        /// </summary>
        public int IsLikeMachine { get; set; }

        /// <summary>
        /// 频率校正
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// 像机 ID
        /// </summary>
        public int WirelessID { get; set; }

        /// <summary>
        /// 模糊查询位数
        /// </summary>
        public int VagueQueryNumber { get; set; }
    }
}
