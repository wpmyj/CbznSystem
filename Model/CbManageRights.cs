using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;

namespace Model
{
    /// <summary>
    /// 用户权限
    /// </summary>
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CbManageRights
    {
        [AutoId(SetAutoId = true)]
        public long ID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 卡片操作 发行
        /// </summary>
        public bool CardOperationIssue { get; set; }

        /// <summary>
        /// 卡片操作 延期
        /// </summary>
        public bool CardOperationDelay { get; set; }

        /// <summary>
        /// 卡片操作 挂失
        /// </summary>
        public bool CardOperationLoss { get; set; }

        /// <summary>
        /// 卡片操作 注销
        /// </summary>
        public bool CardOperationLog { get; set; }

        /// <summary>
        /// 卡片操作 延期更新
        /// </summary>
        public bool CardOperationDeferredUpdate { get; set; }

        /// <summary>
        /// 卡片操作 解锁
        /// </summary>
        public bool CardOperationUnlock { get; set; }

        /// <summary>
        /// 卡片操作 锁住
        /// </summary>
        public bool CardOperationLock { get; set; }

        /// <summary>
        /// 信息录入 添加
        /// </summary>
        public bool InforMationEntryToAdd { get; set; }

        /// <summary>
        /// 信息录入 编辑
        /// </summary>
        public bool InforMationEntryEditing { get; set; }

        /// <summary>
        /// 信息录入 删除
        /// </summary>
        public bool InformationEntryAndDeletion { get; set; }

        /// <summary>
        /// 车牌操作 注册
        /// </summary>
        public bool LicensePlateOperationRegistration { get; set; }

        /// <summary>
        /// 车牌操作 编辑
        /// </summary>
        public bool LicensePlateOperationEditor { get; set; }

        /// <summary>
        /// 车牌操作 延期
        /// </summary>
        public bool LicensePlateOperationDelay { get; set; }

        /// <summary>
        /// 车牌操作 删除
        /// </summary>
        public bool RemovalOfLicensePlateOperation { get; set; }

        /// <summary>
        /// 设备编录 添加
        /// </summary>
        public bool AddEquipmentCatalog { get; set; }

        /// <summary>
        /// 设备编录 编辑
        /// </summary>
        public bool CatalogEditingEquipment { get; set; }

        /// <summary>
        /// 设备编录 删除
        /// </summary>
        public bool DeleteLoggingEquipment { get; set; }

        /// <summary>
        /// 设备编录 导出
        /// </summary>
        public bool ExportEquipmentCatalog { get; set; }

        /// <summary>
        /// 设备编录 导入
        /// </summary>
        public bool ImportEquipmentCatalog { get; set; }

        /// <summary>
        /// 设备加密 设备加密
        /// </summary>
        public bool DeviceEncryption { get; set; }

        /// <summary>
        /// 设备加密 卡片加密
        /// </summary>
        public bool DevicEncryptionCardEncryption { get; set; }

        /// <summary>
        /// IC 加密    IC设备加密
        /// </summary>
        public bool ICEncryptionICDeviceEncryption { get; set; }

        /// <summary>
        /// IC 加密    IC卡加密
        /// </summary>
        public bool ICEncryptionICCardEncryption { get; set; }

        /// <summary>
        /// 像机管理
        /// </summary>
        public bool CameraManagement { get; set; }

        /// <summary>
        /// 模块设置
        /// </summary>
        public bool ModuleSettings { get; set; }

        /// <summary>
        /// 设置 用户管理 添加
        /// </summary>
        public bool SetUserManagementToAdd { get; set; }

        /// <summary>
        /// 设置 用户管理 编辑
        /// </summary>
        public bool SetUserManagemenetEditor { get; set; }

        /// <summary>
        /// 设置 用户管理 删除
        /// </summary>
        public bool SetUserManagementToDelete { get; set; }

        /// <summary>
        /// 设置 用户管理 权限
        /// </summary>
        public bool SetUserAdministrationRights { get; set; }

        /// <summary>
        /// 设置 数据管理 备份
        /// </summary>
        public bool SetDataManagementBackup { get; set; }

        /// <summary>
        /// 设置 数据管理 恢复
        /// </summary>
        public bool SetDataManagementRecovery { get; set; }

        /// <summary>
        /// 设置 数据管理 清除
        /// </summary>
        public bool SetDataManagementClear { get; set; }

        /// <summary>
        /// 在线收费
        /// </summary>
        public bool SetChargeManagement { get; set; }

    }
}
