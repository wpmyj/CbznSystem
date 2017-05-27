using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbCardInfo
    {
        /// <summary>
        /// 主键自增
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 卡片类型  0 单卡 1 组合卡 2 车牌识别卡 3 副卡 4 挂失卡 5 卡片密码错误
        /// </summary>
        public int CardType { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 车牌号码
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// 开始期限
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结止期限
        /// </summary>
        public DateTime StopTime { get; set; }

        /// <summary>
        /// 距离 0 1.2米 1 2.5米 2 3.8米 3 5米 4距离由主机设定
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// 解锁 0 解锁 1 锁住
        /// </summary>
        public int Unlocked { get; set; }

        /// <summary>
        /// 挂失状态 0 正常 1 已挂失
        /// </summary>
        public int LoseState { get; set; }

        /// <summary>
        /// 使用状态 0 未使用 1 已使用 
        /// </summary>
        public int UseState { get; set; }

        /// <summary>
        /// 场分区
        /// </summary>
        public int FieldPartition { get; set; }

        /// <summary>
        /// 停车限制 0 关闭 1 开启
        /// </summary>
        public int ParkingRestrictions { get; set; }

        /// <summary>
        /// 电量 0 正常 1 电量底
        /// </summary>
        public int Electricity { get; set; }

        /// <summary>
        /// 性别 0 男 1 女
        /// </summary>
        public int UserSex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int UserAge { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string UserAddress { get; set; }
                
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistrationTime { get; set; }

    }
}
