using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
namespace Model
{
    /// <summary>
    /// 入口临时记录表
    /// </summary>
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CBEnteranceRecrd
    {

        /// <summary>
        /// 主键
        /// </summary>
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// 入口时间
        /// </summary>
        public DateTime EntranceTime { get; set; }

        /// <summary>
        /// 入口图片
        /// </summary>
        public byte[] ImgData { get; set; }


        /// <summary>
        /// 车牌图片
        /// </summary>
        public byte[] PlateData { get; set; }
    }
}
