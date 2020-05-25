/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : SQL Server
 Source Server Version : 14001000
 Source Host           : localhost:1433
 Source Catalog        : GameStudioSimulator
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 14001000
 File Encoding         : 65001

 Date: 25/05/2020 15:08:19
*/


-- ----------------------------
-- Table structure for DeveloperRelation
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DeveloperRelation]') AND type IN ('U'))
	DROP TABLE [dbo].[DeveloperRelation]
GO

CREATE TABLE [dbo].[DeveloperRelation] (
  [DeveloperStaffNumber] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [DeveloperGameNumber] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[DeveloperRelation] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of DeveloperRelation
-- ----------------------------
INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'0')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'8')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'2', N'1')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'2', N'11')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'8')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'8')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'8')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'8')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'2', N'9')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'9')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'9')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'5', N'9')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'9')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'2', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'8', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'5', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'886')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'886')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'9', N'886')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'886')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'886')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'10', N'2')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'2')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'2')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'7', N'2')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'8', N'2')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'2')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'9', N'2')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'10', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'8', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'9', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'5', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'2', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'10', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'5', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'7', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'8', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'9', N'888')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'1')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'1')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'7', N'1')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'8', N'1')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'9', N'1')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'10', N'5')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'5', N'5')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'5')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'5')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'5')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'2', N'999')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'11')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'0')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'2', N'0')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'2', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'5', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'7', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'8', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'7', N'55')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'9999')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'9', N'77')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'7', N'3')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'1', N'996')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'0', N'996')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'3', N'996')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'4', N'996')
GO

INSERT INTO [dbo].[DeveloperRelation]  VALUES (N'6', N'996')
GO


-- ----------------------------
-- Table structure for GameInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[GameInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[GameInfo]
GO

CREATE TABLE [dbo].[GameInfo] (
  [GameNumber] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [GameName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [GamePrice] int  NULL,
  [GameSales] int  NULL,
  [GameStudio] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [GameGenres] int  NULL,
  [GameFun] int  NULL,
  [GameArt] int  NULL,
  [GameMusic] int  NULL,
  [GameIsDeveloping] int  NULL,
  [GameFinishDevelopTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [GameStartDevelopTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[GameInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of GameInfo
-- ----------------------------
INSERT INTO [dbo].[GameInfo]  VALUES (N'1', N'文明7', N'248', N'5920519', N'0', N'0', N'161', N'170', N'161', N'0', N'2020/8/17 2:00:00', N'2020/8/8 17:40:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'2', N'只狼', N'0', N'0', N'0', N'0', N'141', N'90', N'54', N'0', N'2020/6/26 19:40:00', N'2020/6/22 15:40:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'3', N'赛博朋克2077', N'0', N'0', N'0', N'0', N'1292', N'1154', N'1170', N'0', N'2020/7/17 19:00:00', N'2020/7/5 7:00:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'5', N'黑暗之魂', N'198', N'13063574', N'0', N'0', N'318', N'264', N'262', N'0', N'2020/8/18 19:00:00', N'2020/8/10 11:00:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'55', N'看门狗', N'0', N'0', N'0', N'0', N'1125', N'453', N'1096', N'0', N'2020/6/11 14:40:00', N'2020/6/7 10:40:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'77', N'合金装备', N'0', N'0', N'0', N'0', N'1222', N'579', N'804', N'0', N'2020/5/31 23:20:00', N'2020/5/29 21:20:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'8', N'文明6', N'0', N'0', N'0', N'0', N'118', N'61', N'63', N'0', N'2020/5/26 7:40:00', N'2020/5/25 1:40:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'886', N'黑暗之魂3', N'0', N'0', N'0', N'0', N'20', N'66', N'27', N'0', N'2020/6/19 13:00:00', N'2020/6/17 11:00:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'888', N'Minecraft', N'148', N'34309706', N'0', N'0', N'512', N'243', N'244', N'0', N'2020/7/29 22:20:00', N'2020/7/21 14:20:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'9', N'荒野大镖客', N'0', N'0', N'0', N'0', N'42', N'21', N'15', N'0', N'2020/5/26 2:40:00', N'2020/5/25 16:40:00')
GO

INSERT INTO [dbo].[GameInfo]  VALUES (N'996', N'神秘海域', N'0', N'0', N'0', N'0', N'284', N'148', N'154', N'0', N'2020/6/14 13:00:00', N'2020/6/13 19:00:00')
GO


-- ----------------------------
-- Table structure for PlayerInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[PlayerInfo]
GO

CREATE TABLE [dbo].[PlayerInfo] (
  [PlayerStudioNumber] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [PlayerStartTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [PlayerPassword] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [PlayerNowTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [PlayerNumber] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[PlayerInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of PlayerInfo
-- ----------------------------
INSERT INTO [dbo].[PlayerInfo]  VALUES (N'0', N'2020-05-20T00:00:00', N'0', N'2020/8/26 20:40:00', N'0')
GO


-- ----------------------------
-- Table structure for StaffInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[StaffInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[StaffInfo]
GO

CREATE TABLE [dbo].[StaffInfo] (
  [StaffNumber] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [StaffName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [StaffGender] int  NULL,
  [StaffSalary] int  NULL,
  [StaffRank] int  NULL,
  [StaffOccupation] int  NULL,
  [StaffStrength] int  NULL,
  [StaffIntelligence] int  NULL,
  [StaffLoyalty] int  NULL,
  [StaffProperty] int  NULL,
  [TimeToWork] int  NULL,
  [TimeToQuit] int  NULL,
  [WeekdaysLength] int  NULL,
  [StaffTemperament] int  NULL,
  [StaffStudio] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[StaffInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of StaffInfo
-- ----------------------------
INSERT INTO [dbo].[StaffInfo]  VALUES (N'0', N'比尔盖子', N'0', N'200', N'6', N'3', N'24', N'94', N'10', N'100', N'9', N'18', N'6', N'6', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'1', N'席德梅尔', N'0', N'8000', N'6', N'0', N'24', N'85', N'100', N'100', N'9', N'17', N'5', N'31', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'10', N'宫崎英高', N'0', N'1000', N'4', N'0', N'22', N'94', N'40', N'2000', N'9', N'17', N'5', N'5', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'2', N'大陆秀夫', N'0', N'10000', N'6', N'0', N'24', N'92', N'10', N'100', N'9', N'17', N'5', N'6', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'3', N'达芬奇', N'0', N'10000', N'2', N'2', N'30', N'87', N'100', N'100', N'9', N'21', N'5', N'6', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'4', N'贝多芬', N'0', N'10000', N'2', N'4', N'30', N'88', N'100', N'100', N'9', N'21', N'5', N'6', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'5', N'黄仁勋', N'0', N'10000', N'2', N'3', N'30', N'87', N'100', N'100', N'9', N'21', N'5', N'6', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'6', N'宫本茂', N'0', N'10000', N'2', N'1', N'24', N'100', N'100', N'100', N'9', N'17', N'5', N'6', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'7', N'陈星汉', N'0', N'5000', N'3', N'1', N'24', N'86', N'51', N'1000', N'9', N'17', N'5', N'1', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'8', N'高瞰', N'0', N'1000', N'3', N'4', N'24', N'86', N'51', N'1000', N'9', N'17', N'5', N'5', N'0')
GO

INSERT INTO [dbo].[StaffInfo]  VALUES (N'9', N'莫奈', N'0', N'5000', N'6', N'2', N'24', N'86', N'51', N'1000', N'9', N'21', N'5', N'1', N'0')
GO


-- ----------------------------
-- Table structure for StudioInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[StudioInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[StudioInfo]
GO

CREATE TABLE [dbo].[StudioInfo] (
  [StudioNumber] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [StudioName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [StudioProperty] int  NULL,
  [StudioReputation] int  NULL
)
GO

ALTER TABLE [dbo].[StudioInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of StudioInfo
-- ----------------------------
INSERT INTO [dbo].[StudioInfo]  VALUES (N'0', N'Ubisoft', N'8000000', N'70')
GO

INSERT INTO [dbo].[StudioInfo]  VALUES (N'1', N'Rockstar', N'3000000', N'80')
GO

INSERT INTO [dbo].[StudioInfo]  VALUES (N'2', N'NaughtyDog', N'8000000', N'80')
GO


-- ----------------------------
-- Primary Key structure for table GameInfo
-- ----------------------------
ALTER TABLE [dbo].[GameInfo] ADD CONSTRAINT [PK__GameInfo__CEF05AAD122CCB86] PRIMARY KEY CLUSTERED ([GameNumber])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table PlayerInfo
-- ----------------------------
ALTER TABLE [dbo].[PlayerInfo] ADD CONSTRAINT [PK__PlayerSt__97FBCAF16ED2440E] PRIMARY KEY CLUSTERED ([PlayerNumber])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table StaffInfo
-- ----------------------------
ALTER TABLE [dbo].[StaffInfo] ADD CONSTRAINT [PK__StaffInf__F2BC669A4CD4D20F] PRIMARY KEY CLUSTERED ([StaffNumber])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table StudioInfo
-- ----------------------------
ALTER TABLE [dbo].[StudioInfo] ADD CONSTRAINT [PK__AllStudi__084073AF9375853C] PRIMARY KEY CLUSTERED ([StudioNumber])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

