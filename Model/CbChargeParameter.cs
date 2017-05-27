using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbChargeParameter
    {

        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 收费模式
        /// </summary>
        public int ChargeMode { get; set; }

        /// <summary>
        /// 开闸模式 0 识别即开闸 1 收费开闸 2 固定车开闸
        /// </summary>
        public int GateMode { get; set; }

        /// <summary>
        /// 免费时间
        /// </summary>
        public int FreeMinutes { get; set; }

        /// <summary>
        /// 每日限额
        /// </summary>
        public double DailyLimit { get; set; }

        /// <summary>
        /// 第一段时间
        /// </summary>
        public int FirstCharge { get; set; }

        /// <summary>
        /// 第一段收费
        /// </summary>
        public double FirstMoney { get; set; }

        /// <summary>
        /// 第二段时间
        /// </summary>
        public int TwoCharge { get; set; }

        /// <summary>
        /// 第二段收费
        /// </summary>
        public double TwoMoney { get; set; }

        /// <summary>
        /// 第三段时间
        /// </summary>
        public int ThreeCharge { get; set; }

        /// <summary>
        /// 第三段收费
        /// </summary>
        public double ThreeMoney { get; set; }

        /// <summary>
        /// 第四段时间
        /// </summary>
        public int FourCharge { get; set; }

        /// <summary>
        /// 第四段收费
        /// </summary>
        public double FourMoney { get; set; }

        /// <summary>
        /// 第五段时间
        /// </summary>
        public int FiveCharge { get; set; }

        /// <summary>
        /// 第五段收费
        /// </summary>
        public double FiveMoney { get; set; }

        /// <summary>
        /// 第六段时间
        /// </summary>
        public int SixCharge { get; set; }

        /// <summary>
        /// 第六段收费
        /// </summary>
        public double SixMoney { get; set; }

        /// <summary>
        /// 第七段时间
        /// </summary>
        public int SevenCharge { get; set; }

        /// <summary>
        /// 第七段收费
        /// </summary>
        public double SevenMoney { get; set; }

        /// <summary>
        /// 第八段时间
        /// </summary>
        public int EightCharge { get; set; }

        /// <summary>
        /// 第八段收费
        /// </summary>
        public double EightMoney { get; set; }

        /// <summary>
        /// 第九段时间
        /// </summary>
        public int NineCharge { get; set; }

        /// <summary>
        /// 第九段收费
        /// </summary>
        public double NineMoney { get; set; }

        /// <summary>
        /// 第十段时间
        /// </summary>
        public int TenCharge { get; set; }

        /// <summary>
        /// 第十段收费
        /// </summary>
        public double TenMoney { get; set; }

    }
}
