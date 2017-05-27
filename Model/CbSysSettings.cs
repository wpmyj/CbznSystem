using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CbSysSettings
    {
        /// <summary>
        /// 帐号
        /// </summary>
        public string ManageAccount { get; set; }

        /// <summary>
        /// 是否保存密码
        /// </summary>
        public bool IsSavePassword { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string ManagePassword { get; set; }

        /// <summary>
        /// 远程连接数据库
        /// </summary>
        public int RemoteConnection { get; set; }

        /// <summary>
        /// 连接IP地址
        /// </summary>
        public string RemoteConnectionIP { get; set; }

        /// <summary>
        /// 远程连接帐号
        /// </summary>
        public string RemoteConnectionUserID { get; set; }

        /// <summary>
        /// 远程连接密码
        /// </summary>
        public string RemoteConnectionPwd { get; set; }

        /// <summary>
        /// 备份地址
        /// </summary>
        public string BackupsAddress { get; set; }

        /// <summary>
        /// 保存的频率
        /// </summary>
        public int SaveFrequency { get; set; }

        /// <summary>
        /// 保存通信ID
        /// </summary>
        public int SaveCommunicationID { get; set; }

        /// <summary>
        /// 有无临时卡设备 true 有  false 无
        /// </summary>
        public bool IsSetTempIcDevice { get; set; }

        /// <summary>
        /// 有无车牌识别设备 true 有 false 无
        /// </summary>
        public bool IsSetLprDevice { get; set; }

        /// <summary>
        /// 是否显示图像对比
        /// </summary>
        public bool IsShowImgContrast { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
    }
}
