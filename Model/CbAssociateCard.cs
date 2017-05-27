using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbAssociateCard
    {

        /// <summary>
        /// 主键
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// CBCardInfo的主键
        /// </summary>
        public long CardID { get; set; }

        /// <summary>
        /// 副卡卡号
        /// </summary>
        public string AssociateCardNumber { get; set; }

        /// <summary>
        /// 操作状态 0无操作 1更新时间和场分区 2添加副卡须解锁 3 延期
        /// </summary>
        public int UseState { get; set; }


        /// <summary>
        /// 副卡时间
        /// </summary>
        public DateTime AssociateCardTime { get; set; }


        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 副卡分区
        /// </summary>
        public int SubCardDivision { get; set; }


    }
}
