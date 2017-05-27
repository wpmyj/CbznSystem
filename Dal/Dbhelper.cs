using System;
using System.Collections.Generic;
using System.Text;
using Db_Rom;
using System.Configuration;
using System.IO;
using System.Data.SQLite;

namespace Dal
{
	public class Dbhelper
	{
		public static IDbPort Db;

		private static string _DbFilePath;

		public static void Backups(string backupsaddress)
		{
			try
			{
				string strConnection = ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString;
				string backupsconnstr = string.Format(strConnection, backupsaddress);
				string currentconnstr = string.Format(strConnection, _DbFilePath);
				using (SQLiteConnection currentconn = new SQLiteConnection(currentconnstr))
				{
					using (SQLiteConnection backupsconn = new SQLiteConnection(backupsconnstr))
					{
						currentconn.Open();
						backupsconn.Open();

						currentconn.BackupDatabase(backupsconn, "main", "main", -1, null, 0);

						currentconn.Close();
						currentconn.Close();
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void InitSqlPort(string ip, string account, string password)
		{
			string strConnection = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
			strConnection = string.Format(strConnection, ip, account, password);
			Db = new SqlHelper(strConnection);
		}

		public static void InitSqlitePort(string filepath)
		{
			_DbFilePath = filepath;
			string strConnection = ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString;
			strConnection = string.Format(strConnection, filepath);
			Db = new SqliteHelper(strConnection);
			if (!File.Exists(filepath))
			{
				string directoryfile = Path.GetDirectoryName(filepath);
				if (!Directory.Exists(directoryfile))
				{
					Directory.CreateDirectory(directoryfile);
				}
				CreateSqliteDb(filepath);
			}

		}

		private static void CreateSqliteDb(string filepath)
		{
			try
			{
				//创建数据库
				SQLiteConnection.CreateFile(filepath);
				//创建表
				StringBuilder sb = new StringBuilder();

				/* 用户信息表
				 * ID 主键
				 * ManageName 帐户名
				 * UserName 名称
				 * ManagePwd 密码
				 * ManageType 用户类型
				 */
				sb.Append(" Create table CBManageInfo( ID  integer primary key AUTOINCREMENT  , ManageName Nvarchar(18) not null, UserName Nvarchar(10) , ManagePwd Nvarchar(18) , ManageType INT ) ;");

				//插入管理员
				sb.Append(" Insert into CBManageInfo (ManageName,UserName,ManagePwd,ManageType) values('admin','admin','',0) ;");

				/* 操作记录表
				 * ID 主键
				 * ManageName 用户ID
				 * Explains 操作说明
				 * LogTime 记录时间
				 */
				sb.Append(" Create table CBManageLog(ID integer primary key AUTOINCREMENT,ManageName Nvarchar(18),Explains Nvarchar(100), LogTime DateTime );");

				/*卡片信息
				 * ID 主键自增
				 * CardNumber 卡号
				 * CardType 卡片类型 0 单卡 1 组合卡 2 副卡 3 车牌识别卡 4 挂失卡 5 卡片密码错误
				 * UserName 用户名称
				 * PlateNumber 车牌号码
				 * StartTime 开始期限
				 * StopTime 结止期限
				 * Distance 距离 0 1.2米 1 2.5米 2 3.8米 3 5米 4距离由主机设定
				 * Unlocked 解锁 0 解锁 1 锁住
				 * LoseState 挂失状态 0 正常 1 已挂失
				 * UseState 使用状态 0 未使用 1 已使用 2 已挂失
				 * FieldPartition 场分区
				 * ParkingRestrictions 停车限制 0 关闭 1 开启
				 * Electricity 电量 0 正常 1 电量底
				 * UserSex 性别 0 男 1 女
				 * UserAge 年龄
				 * UserPhone 电话号码
				 * UserAddress 地址
				 * RegistrationTime 注册时间
				 */
				sb.Append(" Create table CBCardInfo(ID integer primary key AUTOINCREMENT,CardNumber Nvarchar(10),CardType INT , UserName Nvarchar(10) ,PlateNumber Nvarchar(10), StartTime DateTime ,StopTime DateTime,Distance INT ,Unlocked INT,LoseState INT,UseState INT,FieldPartition INT ,ParkingRestrictions INT, Electricity INT ,UserSex INT ,UserAge INT ,UserPhone Nvarchar(11),UserAddress Nvarchar(100),RegistrationTime DateTime );");

				/* 副卡信息
				 * ID 主键
				 * CardID CBCardInfo的主键
				 * AssociateCardNumber 副卡卡号
				 * UseState 操作状态 0无操作 1更新时间和场分区 2添加捆绑设置时间和场分区 3删除的定距卡副卡标记
				 * AssociateCardTime 副卡时间
				 * UpdateTime 更新时间
				 * SubCardDivision 副卡分区
				 */
				sb.Append(" Create table CBAssociateCard (ID integer primary key AUTOINCREMENT,CardID integer  ,AssociateCardNumber Nvarchar(10),UseState INT,AssociateCardTime DateTime , UpdateTime DateTime ,SubCardDivision INT,FOREIGN KEY(CardID) REFERENCES CBCardInfo(ID) );");

				/* 计数状态
				 * ID 主键
				 * UseNumber 使用编号
				 * UseCounting 计数
				 * UseFunction 功能
				 */
				sb.Append(" Create table CBCardCountingState(ID integer primary key AUTOINCREMENT, UseNumber Nvarchar(10) ,UseCounting INT , UseFunction INT );");

				/* 进出记录表
				 * ID 主键
				 *MasterCardNumber 主卡卡号
				 *SubCardNumber 副卡卡号
				 *DeviceNumber 设备编号
				 *IOState 进出状态
				 *IOTime 进出时间
				 */
				sb.Append(" Create table CBIORecord (ID integer primary key AUTOINCREMENT,MasterCardNumber Nvarchar(10),SubCardNumber Nvarchar(10),DeviceNumber INT ,IOState bit,IOTime DateTime );");

				/* 设备信息表
				 *  ID 主键
				 *  HostNumber 主机编号
				 *  IOSate  进出状态 0 进 1 出
				 *  DeviceNumber 设备编号
				 *  DeviceMode 开闸模式
				 *  FieldPartition 场分区
				 *  AntiSubmarineBack 返潜回 0 关闭 1 开启
				 *  VehicleDetection 车辆检测 0 关闭 1 开启
				 *  Distance 距离
				 *  EquipmentDelay 设备延迟
				 *  Language 语言种类
				 *  IsLikeMachine 检测像机
				 *  Frequency 无线频率
				 *  WirelessID 无线ID
				 *  VagueQueryNumber 模糊查询位数
				 */
				sb.Append(" Create table CBDeviceInfo(ID integer primary key AUTOINCREMENT,HostNumber INT,IOSate INT,DeviceNumber INT, DeviceMode INT ,FieldPartition INT ,AntiSubmarineBack INT,VehicleDetection INT,Distance INT,EquipmentDelay INT ,Language INT,IsLikeMachine INT,Frequency INT,WirelessID INT,VagueQueryNumber INT );");

				/*设备密码表
				 * ID 主键
				 * Pwd 密码
				 */
				sb.Append(" Create table CBDevicePwd (ID integer primary key AUTOINCREMENT, Pwd Nvarchar(6) );");

				/*IC设备密码
				 * ID 主键
				 * Pwd 密码
				 */
				sb.Append(" Create table CBIcDeviePwd(ID integer primary key AUTOINCREMENT  ,Pwd Nvarchar(12) ) ;");

				/*车牌识别用户信息表
				 * ID 主键
				 * UserName 用户名称
				 * UserPlate 车牌号码
				 * StartTime 开始期限
				 * StopTime 结止期限
				 * UserType 黑白名单 0 白名单 1黑名单
				 * UserSex 性别 0 男 1 女
				 * UserAge 年龄
				 * UserPhone 电话号码
				 * UserAddress 地址
				 * RegistrationTime 注册时间
				 * PlateType 车辆类型
				 */
				sb.Append(" Create table CBLprUserInfo(ID integer primary key AUTOINCREMENT,UserName nvarchar(10),UserPlate nvarchar(10),StartTime DateTime,StopTime DateTime,UserType INT,UserSex INT,UserAge INT,UserPhone nvarchar(11),UserAddress nvarchar(100),RegistrationTime DateTime ,PlateType INT ); ");

				/*车牌延期记录表
				 * ID 主键 
				 * LprUserName 用户名称
				 * LprUserPlate 车牌号码
				 * StartTime 开始期限
				 * StopTime 结止期限
				 * ChargeAmount 收费金额
				 * Operator 操作人员
				 * RecordTime 记录时间
				 */
				sb.Append(" Create table CBLprDelayRecord(ID integer primary key AUTOINCREMENT,LprUserName Nvarchar(10), LprUserPlate nvarchar(10),StartTime DateTime,StopTime DateTime,ChargeAmount double,Operator nvarchar(10),RecordTime DateTime );");

				/*入口临时记录表
				 * ID 主键
				 * PlateNumber 车牌号
				 * EntranceTime 入口时间
				 * ImgData  入口图片
				 * PlateData    车牌图片
				 */
				sb.Append(" Create table CBEnteranceRecrd(ID integer primary key AUTOINCREMENT, PlateNumber nvarchar(10), EntranceTime datetime , ImgData varbinary , PlateData varbinary);");

				/* 临时收费记录表
				 * ID 主键
				 * CardNumber 卡号
				 * PlateNumber 车牌号
				 * EntranceTime 入口时间
				 * ExportTime 出口时间
				 * ChargeAmount 金额
				 * ManageName 收费用户
				 * ActualAmount 实收金额
				 * ExitNumber 出口编号
				 */
				sb.Append(" Create table CBTempChargeRecord (ID integer primary key AUTOINCREMENT ,CardNumber Nvarchar(10),PlateNumber Nvarchar(10),EntranceTime DateTime,ExportTime DateTime,ChargeAmount Double,ManageName Nvarchar(18),ActualAmount Double ,ExitNumber Int );");

				/* 摄像机列表
				 * ID 主键
				 * IP 摄像机的IP地址
				 * IOState 进入还是出口
				 * ID 对应的设备
				 */
				//sb.Append(" Create table CBLPRCSDKSet(ID integer primary key AUTOINCREMENT, IP nvarchar(15),IOState INT ,DeviceID INT ); ");

				/*月租收费
				 * DayCharge 日收费金额
				 * MonthlyCharge 月收费金额
				 * AnnualCharge 年收费金额
				 */
				//sb.Append(" create table CBDelayCharg(ID integer primary key AUTOINCREMENT,	DayCharge int,	MonthlyCharge int,	AnnualCharge int );");

				/*收费设置
				 * ChargeMode 收费模式
				 * GateMode 开闸模式
				 * FreeMinutes 免费时间
				 * DailyLimit 每日限额
				 * FirstCharge 第一段时间
				 * FirstMoney  第一段收费
				 * TwoCharge 第二段时间
				 * TwoMoney 第二段收费
				 * ThreeCharge 第三段时间
				 * ThreeMoney 第三段收费
				 * FourCharge 第四段时间
				 * FourMoney 第四段收费
				 * FiveCharge 第五段时间
				 * FiveMoney 第五段收费
				 * SixCharge 第六段时间
				 * SixMoney 第六段收费
				 * SevenCharge 第七段时间
				 * SevenMoney 第七段收费
				 * EightCharge 第八段时间
				 * EightMoney 第八段收费
				 * NineCharge 第九段时间
				 * NineMoney 第九段收费
				 * TenCharge 第十段时
				 * TenMoney 第十段收费
				 */
				sb.Append(" create table CBChargeParameter(ID integer primary key AUTOINCREMENT,ChargeMode int ,GateMode int,FreeMinutes int,DailyLimit Double,	FirstCharge int,FirstMoney Double,TwoCharge int,TwoMoney Double,ThreeCharge int,ThreeMoney Double,FourCharge int,FourMoney Double,FiveCharge int,FiveMoney Double,SixCharge int,SixMoney Double,SevenCharge int,SevenMoney Double,EightCharge int,EightMoney Double,NineCharge int,NineMoney Double,TenCharge int,TenMoney Double) ;");

				/*用户权限表
				 * ID 主键
				 * UserID 用户ID
				 * CardOperationIssue 卡片操作 发行
				 * CardOperationDelay 卡片操作 延期
				 * CardOperationLoss 卡片操作 挂失
				 * CardOperationLog  卡片操作注销
				 * CardOperationDeferredUpdate 卡片操作 延期更新
				 * CardOperationUnlock 卡片操作 解锁
				 * CardOperationLock  卡片操作 锁住
				 * InforMationEntryToAdd 信息录入 添加
				 * InforMationEntryEditing 信息录入 编辑
				 * InformationEntryAndDeletion 信息录入 删除
				 * LicensePlateOperationRegistration 车牌操作 注册
				 * LicensePlateOperationEditor 车牌操作 编辑
				 * LicensePlateOperationDelay 车牌操作 延期
				 * RemovalOfLicensePlateOperation 车牌操作 删除
				 * AddEquipmentCatalog 设备编录 添加
				 * CatalogEditingEquipment 设备编录 编辑
				 * DeleteLoggingEquipment 设备编录 删除
				 * ExportEquipmentCatalog 设备编录 导出
				 * ImportEquipmentCatalog 设备编录 导入
				 * DeviceEncryption 设备加密 
				 * DevicEncryptionCardEncryption 设备加密 卡片加密
				 * ICEncryptionICDeviceEncryption IC加密 IC设备加密
				 * ICEncryptionICCardEncryption IC加密 IC卡加密
				 * CameraManagement 像机管理
				 * ModuleSettings 模块设置
				 * SetUserManagementToAdd 设置 用户管理 添加
				 * SetUserManagemenetEditor 设置 用户管理 编辑
				 * SetUserManagementToDelete 设备 用户管理 删除
				 * SetUserAdministrationRights 设置 用户管理 权限
				 * SetDataManagementBackup 设置 数据管理 备份
				 * SetDataManagementRecovery 设置 数据管理 恢复
				 * SetDataManagementClear 设置 数据管理 清除
				 * SetChargeManagement 收费管理
				 */
				sb.Append(" Create table CBManageRights(ID integer primary key AUTOINCREMENT,UserID integer ,CardOperationIssue bit,CardOperationDelay bit,CardOperationLoss bit,CardOperationLog bit,CardOperationDeferredUpdate bit,CardOperationUnlock bit,CardOperationLock bit,InforMationEntryToAdd bit,InforMationEntryEditing bit,InformationEntryAndDeletion bit,LicensePlateOperationRegistration bit,LicensePlateOperationEditor bit,LicensePlateOperationDelay bit,RemovalOfLicensePlateOperation bit,AddEquipmentCatalog bit,CatalogEditingEquipment bit,DeleteLoggingEquipment bit,ExportEquipmentCatalog bit,ImportEquipmentCatalog bit,DeviceEncryption bit,DevicEncryptionCardEncryption bit,ICEncryptionICDeviceEncryption bit,ICEncryptionICCardEncryption bit,CameraManagement bit,ModuleSettings bit,SetUserManagementToAdd bit,SetUserManagemenetEditor bit,SetUserManagementToDelete bit,SetUserAdministrationRights bit,SetDataManagementBackup bit,SetDataManagementRecovery bit,SetDataManagementClear bit,SetChargeManagement bit) ;");

				//添加管理员权限
				sb.Append(" insert into CBManageRights(UserID,CardOperationIssue ,CardOperationDelay ,CardOperationLoss ,CardOperationLog ,CardOperationDeferredUpdate ,CardOperationUnlock ,CardOperationLock ,InforMationEntryToAdd ,InforMationEntryEditing ,InformationEntryAndDeletion ,LicensePlateOperationRegistration ,LicensePlateOperationEditor ,LicensePlateOperationDelay ,RemovalOfLicensePlateOperation ,AddEquipmentCatalog ,CatalogEditingEquipment ,DeleteLoggingEquipment ,ExportEquipmentCatalog ,ImportEquipmentCatalog ,DeviceEncryption ,DevicEncryptionCardEncryption ,ICEncryptionICDeviceEncryption ,ICEncryptionICCardEncryption ,CameraManagement ,ModuleSettings ,SetUserManagementToAdd ,SetUserManagemenetEditor ,SetUserManagementToDelete ,SetUserAdministrationRights ,SetDataManagementBackup ,SetDataManagementRecovery ,SetDataManagementClear ,SetChargeManagement ) values(1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 ) ; ");
				Db.ExecuteNonQuery(sb.ToString());
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static string CreateSqlDb()
		{
			StringBuilder sb = new StringBuilder();

			/* 用户信息表
			 * ID 主键
			 * ManageName 帐户名
			 * UserName 名称
			 * ManagePwd 密码
			 * ManageType 用户类型
			 */
			sb.Append(@" Create table CBManageInfo(
							ID int primary key identity(1, 1),
							ManageName Nvarchar(18) not null,
							UserName Nvarchar(10),
							ManagePwd Nvarchar(18),
							ManageType INT
						 ) ;");

			//插入管理员
			sb.Append(@" Insert into CBManageInfo 
						 (ManageName,UserName,ManagePwd,ManageType) 
						 values
						 ('admin','admin','',0) ;");

			/* 操作记录表
			 * ID 主键
			 * ManageName 用户ID
			 * Explains 操作说明
			 * LogTime 记录时间
			 */
			sb.Append(@" Create table CBManageLog(
							ID int primary key identity(1,1),
							ManageName Nvarchar(18),
							Explains Nvarchar(100), 
							LogTime DateTime 
						 ) ;");

			/*卡片信息
			 * ID 主键自增
			 * CardNumber 卡号
			 * CardType 卡片类型 0 单卡 1 组合卡 2 副卡 3 车牌识别卡 4 挂失卡 5 卡片密码错误
			 * UserName 用户名称
			 * PlateNumber 车牌号码
			 * StartTime 开始期限
			 * StopTime 结止期限
			 * Distance 距离 0 1.2米 1 2.5米 2 3.8米 3 5米 4距离由主机设定
			 * Unlocked 解锁 0 解锁 1 锁住
			 * LoseState 挂失状态 0 正常 1 已挂失
			 * UseState 使用状态 0 未使用 1 已使用 2 已挂失
			 * FieldPartition 场分区
			 * ParkingRestrictions 停车限制 0 关闭 1 开启
			 * Electricity 电量 0 正常 1 电量底
			 * UserSex 性别 0 男 1 女
			 * UserAge 年龄
			 * UserPhone 电话号码
			 * UserAddress 地址
			 * RegistrationTime 注册时间
			 */
			sb.Append(@" Create table CBCardInfo(
							 ID int primary key identity(1,1),
							 CardNumber Nvarchar(10),
							 CardType INT , 
							 UserName Nvarchar(10) ,
							 PlateNumber Nvarchar(10), 
							 StartTime DateTime, 
							 StopTime DateTime, 
							 Distance INT, 
							 Unlocked INT, 
							 LoseState INT, 
							 UseState INT, 
							 FieldPartition INT, 
							 ParkingRestrictions INT, 
							 Electricity INT, 
							 UserSex INT, 
							 UserAge INT, 
							 UserPhone Nvarchar(11), 
							 UserAddress Nvarchar(100), 
							 RegistrationTime DateTime
						   ) ;");

			/* 副卡信息
			 * ID 主键
			 * CardID CBCardInfo的主键
			 * AssociateCardNumber 副卡卡号
			 * UseState 操作状态 0无操作 1更新时间和场分区 2添加捆绑设置时间和场分区 3删除的定距卡副卡标记
			 * AssociateCardTime 副卡时间
			 * UpdateTime 更新时间
			 * SubCardDivision 副卡分区
			 */
			sb.Append(@" Create table CBAssociateCard (
							ID int primary key identity(1,1),
							CardID INT  ,
							AssociateCardNumber Nvarchar(10),
							UseState INT,
							AssociateCardTime DateTime, 
							UpdateTime DateTime, 
							SubCardDivision INT, 
							FOREIGN KEY(CardID) REFERENCES CBCardInfo(ID)
						 ) ;");

			/* 计数状态
			 * ID 主键
			 * UseNumber 使用编号
			 * UseCounting 计数
			 * UseFunction 功能
			 */
			sb.Append(@" Create table CBCardCountingState(
							ID int primary key identity(1,1), 
							UseNumber Nvarchar(10) ,
							UseCounting INT , 
							UseFunction INT 
						 ) ;");

			/* 进出记录表
			 * ID 主键
			 * MasterCardNumber 主卡卡号
			 * SubCardNumber 副卡卡号
			 * DeviceNumber 设备编号
			 * IOState 进出状态
			 * IOTime 进出时间
			 */
			sb.Append(@" Create table CBIORecord (
							ID int primary key identity(1,1),
							MasterCardNumber Nvarchar(10),
							SubCardNumber Nvarchar(10),
							DeviceNumber INT ,
							IOState bit, 
							IOTime DateTime
						 ) ;");

			/* 设备信息表
			 *  ID 主键
			 *  HostNumber 主机编号
			 *  IOSate  进出状态 0 进 1 出
			 *  DeviceNumber 设备编号
			 *  DeviceMode 开闸模式
			 *  FieldPartition 场分区
			 *  AntiSubmarineBack 返潜回 0 关闭 1 开启
			 *  VehicleDetection 车辆检测 0 关闭 1 开启
			 *  Distance 距离
			 *  EquipmentDelay 设备延迟
			 *  Language 语言种类
			 *  IsLikeMachine 检测像机
			 *  Frequency 无线频率
			 *  WirelessID 无线ID
			 *  VagueQueryNumber 模糊查询位数
			 */
			sb.Append(@" Create table CBDeviceInfo(
							ID int primary key identity(1,1),
							HostNumber INT,
							IOSate INT,
							DeviceNumber INT, 
							DeviceMode INT ,
							FieldPartition INT , 
							AntiSubmarineBack INT, 
							VehicleDetection INT, 
							Distance INT, 
							EquipmentDelay INT, 
							Language INT, 
							IsLikeMachine INT, 
							Frequency INT, 
							WirelessID INT, 
							VagueQueryNumber INT
						 ) ;");

			/*设备密码表
			 * ID 主键
			 * Pwd 密码
			 */
			sb.Append(@" Create table CBDevicePwd (
							ID int primary key identity(1,1) , 
							Pwd Nvarchar(6)  
						 ) ;");

			/*IC设备密码
			 * ID 主键
			 * Pwd 密码
			 */
			sb.Append(@" Create table CBIcDeviePwd(
							ID int primary key identity(1,1) ,
							Pwd Nvarchar(12) 
						 ) ;");

			/*车牌识别用户信息表
			 * ID 主键
			 * UserName 用户名称
			 * UserPlate 车牌号码
			 * StartTime 开始期限
			 * StopTime 结止期限
			 * UserType 黑白名单 0 白名单 1黑名单
			 * UserSex 性别 0 男 1 女
			 * UserAge 年龄
			 * UserPhone 电话号码
			 * UserAddress 地址
			 * RegistrationTime 注册时间
			 * PlateType 车辆类型
			 */
			sb.Append(@" Create table CBLprUserInfo(
							ID int primary key identity(1,1),
							UserName nvarchar(10),
							UserPlate nvarchar(10),
							StartTime DateTime,
							StopTime DateTime, 
							UserType INT, 
							UserSex INT, 
							UserAge INT, 
							UserPhone nvarchar(11), 
							UserAddress nvarchar(100), 
							RegistrationTime DateTime, 
							PlateType INT 
						) ;");

			/*车牌延期记录表
			 * ID 主键 
			 * LprUserName 用户名称
			 * LprUserPlate 车牌号码
			 * StartTime 开始期限
			 * StopTime 结止期限
			 * ChargeAmount 收费金额
			 * Operator 操作人员
			 * RecordTime 记录时间
			 */
			sb.Append(@" Create table CBLprDelayRecord(
							ID int primary key identity(1,1),
							LprUserName Nvarchar(10), 
							LprUserPlate nvarchar(10),
							StartTime DateTime,
							StopTime DateTime, 
							ChargeAmount float, 
							Operator nvarchar(10), 
							RecordTime DateTime
						 ) ;");

			/*入口临时记录表
			 * ID 主键
			 * PlateNumber 车牌号
			 * EntranceNumber 入口编号
			 * EntranceTime 入口时间
			 * ImgData  入口图片
			 * PlateData    车牌图片
			 */
			sb.Append(@" Create table CBEnteranceRecrd(
							ID int primary key identity(1,1), 
							PlateNumber nvarchar(10),
							EntranceNumber int,
							EntranceTime datetime , 
							ImgData varbinary(Max) , 
							PlateData varbinary(Max)
						 ) ;");

			/* 临时收费记录表
			 * ID 主键
			 * CardNumber 卡号
			 * PlateNumber 车牌号
			 * EntranceTime 入口时间
			 * ExportTime 出口时间
			 * ChargeAmount 金额
			 * ManageName 收费用户
			 * ActualAmount 实收金额
			 * ExitNumber 出口编号
			 */
			sb.Append(@" Create table CBTempChargeRecord (
							ID int primary key identity(1,1) ,
							CardNumber Nvarchar(10),
							PlateNumber Nvarchar(10),
							EntranceTime DateTime, 
							ExportTime DateTime, 
							ChargeAmount float, 
							ManageName Nvarchar(18), 
							ActualAmount float,
							ExitNumber int 
						 ) ;");

			//sb.Append(" create table CBDelayCharg(ID int primary key identity(1,1),	DayCharge int,	MonthlyCharge int,	AnnualCharge int )");

			/*收费设置
			 * ChargeMode 收费模式
			 * GateMode 开闸模式
			 * FreeMinutes 免费时间
			 * DailyLimit 每日限额
			 * FirstCharge 第一段时间
			 * FirstMoney  第一段收费
			 * TwoCharge 第二段时间
			 * TwoMoney 第二段收费
			 * ThreeCharge 第三段时间
			 * ThreeMoney 第三段收费
			 * FourCharge 第四段时间
			 * FourMoney 第四段收费
			 * FiveCharge 第五段时间
			 * FiveMoney 第五段收费
			 * SixCharge 第六段时间
			 * SixMoney 第六段收费
			 * SevenCharge 第七段时间
			 * SevenMoney 第七段收费
			 * EightCharge 第八段时间
			 * EightMoney 第八段收费
			 * NineCharge 第九段时间
			 * NineMoney 第九段收费
			 * TenCharge 第十段时
			 * TenMoney 第十段收费
			 */
			sb.Append(@" create table CBChargeParameter(
							ID int primary key identity(1,1),
							ChargeMode int ,
							GateMode int,
							FreeMinutes int,
							DailyLimit float,	
							FirstCharge int, 
							FirstMoney float, 
							TwoCharge int, 
							TwoMoney float, 
							ThreeCharge int, 
							ThreeMoney float, 
							FourCharge int, 
							FourMoney float, 
							FiveCharge int, 
							FiveMoney float, 
							SixCharge int, 
							SixMoney float, 
							SevenCharge int, 
							SevenMoney float, 
							EightCharge int, 
							EightMoney float, 
							NineCharge int, 
							NineMoney float, 
							TenCharge int, 
							TenMoney float
						 ) ;");

			/*用户权限表
			 * ID 主键
			 * UserID 用户ID
			 * CardOperationIssue 卡片操作 发行
			 * CardOperationDelay 卡片操作 延期
			 * CardOperationLoss 卡片操作 挂失
			 * CardOperationLog  卡片操作注销
			 * CardOperationDeferredUpdate 卡片操作 延期更新
			 * CardOperationUnlock 卡片操作 解锁
			 * CardOperationLock  卡片操作 锁住
			 * InforMationEntryToAdd 信息录入 添加
			 * InforMationEntryEditing 信息录入 编辑
			 * InformationEntryAndDeletion 信息录入 删除
			 * LicensePlateOperationRegistration 车牌操作 注册
			 * LicensePlateOperationEditor 车牌操作 编辑
			 * LicensePlateOperationDelay 车牌操作 延期
			 * RemovalOfLicensePlateOperation 车牌操作 删除
			 * AddEquipmentCatalog 设备编录 添加
			 * CatalogEditingEquipment 设备编录 编辑
			 * DeleteLoggingEquipment 设备编录 删除
			 * ExportEquipmentCatalog 设备编录 导出
			 * ImportEquipmentCatalog 设备编录 导入
			 * DeviceEncryption 设备加密 
			 * DevicEncryptionCardEncryption 设备加密 卡片加密
			 * ICEncryptionICDeviceEncryption IC加密 IC设备加密
			 * ICEncryptionICCardEncryption IC加密 IC卡加密
			 * CameraManagement 像机管理
			 * ModuleSettings 模块设置
			 * SetUserManagementToAdd 设置 用户管理 添加
			 * SetUserManagemenetEditor 设置 用户管理 编辑
			 * SetUserManagementToDelete 设备 用户管理 删除
			 * SetUserAdministrationRights 设置 用户管理 权限
			 * SetDataManagementBackup 设置 数据管理 备份
			 * SetDataManagementRecovery 设置 数据管理 恢复
			 * SetDataManagementClear 设置 数据管理 清除
			 * SetChargeManagement 收费管理
			 */
			sb.Append(@" Create table CBManageRights(
							ID int primary key identity(1,1),
							UserID integer ,
							CardOperationIssue bit,
							CardOperationDelay bit,
							CardOperationLoss bit, 
							CardOperationLog bit, 
							CardOperationDeferredUpdate bit, 
							CardOperationUnlock bit, 
							CardOperationLock bit, 
							InforMationEntryToAdd bit, 
							InforMationEntryEditing bit, 
							InformationEntryAndDeletion bit, 
							LicensePlateOperationRegistration bit, 
							LicensePlateOperationEditor bit, 
							LicensePlateOperationDelay bit, 
							RemovalOfLicensePlateOperation bit, 
							AddEquipmentCatalog bit, 
							CatalogEditingEquipment bit, 
							DeleteLoggingEquipment bit, 
							ExportEquipmentCatalog bit, 
							ImportEquipmentCatalog bit, 
							DeviceEncryption bit, 
							DevicEncryptionCardEncryption bit, 
							ICEncryptionICDeviceEncryption bit, 
							ICEncryptionICCardEncryption bit, 
							CameraManagement bit, 
							ModuleSettings bit, 
							SetUserManagementToAdd bit, 
							SetUserManagemenetEditor bit, 
							SetUserManagementToDelete bit, 
							SetUserAdministrationRights bit, 
							SetDataManagementBackup bit, 
							SetDataManagementRecovery bit, 
							SetDataManagementClear bit, 
							SetChargeManagement bit
						 ) ;");

			//添加管理员权限
			sb.Append(@" insert into CBManageRights
	(UserID,CardOperationIssue ,CardOperationDelay ,CardOperationLoss ,CardOperationLog ,CardOperationDeferredUpdate ,CardOperationUnlock ,CardOperationLock ,InforMationEntryToAdd ,InforMationEntryEditing ,InformationEntryAndDeletion ,LicensePlateOperationRegistration ,LicensePlateOperationEditor ,LicensePlateOperationDelay ,RemovalOfLicensePlateOperation ,AddEquipmentCatalog ,CatalogEditingEquipment ,DeleteLoggingEquipment ,ExportEquipmentCatalog ,ImportEquipmentCatalog ,DeviceEncryption ,DevicEncryptionCardEncryption ,ICEncryptionICDeviceEncryption ,ICEncryptionICCardEncryption ,CameraManagement ,ModuleSettings ,SetUserManagementToAdd ,SetUserManagemenetEditor ,SetUserManagementToDelete ,SetUserAdministrationRights ,SetDataManagementBackup ,SetDataManagementRecovery ,SetDataManagementClear ,SetChargeManagement ) 
	                        values
	                      (1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1) ");

			return sb.ToString();
		}
	}
}
