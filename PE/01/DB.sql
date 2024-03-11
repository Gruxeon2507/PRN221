﻿USE [master]
GO
/****** Object:  Database [PRN221_Spr22]    Script Date: 09/03/2022 8:41:59 CH ******/
CREATE DATABASE [PRN221_Spr22]
Go
ALTER DATABASE [PRN221_Spr22] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN221_Spr22].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN221_Spr22] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN221_Spr22] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN221_Spr22] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN221_Spr22] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN221_Spr22] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN221_Spr22] SET  MULTI_USER 
GO
ALTER DATABASE [PRN221_Spr22] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN221_Spr22] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN221_Spr22] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN221_Spr22] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PRN221_Spr22] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PRN221_Spr22]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 09/03/2022 8:41:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Gender] [nvarchar](10) NULL,
	[Dob] [date] NULL,
	[Phone] [varchar](15) NULL,
	[IDNumber] [varchar](12) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 09/03/2022 8:41:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rooms](
	[Title] [varchar](10) NOT NULL,
	[Square] [tinyint] NULL,
	[Floor] [tinyint] NULL,
	[Description] [ntext] NULL,
	[Comment] [ntext] NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Services]    Script Date: 09/03/2022 8:41:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomTitle] [varchar](10) NULL,
	[Month] [tinyint] NULL,
	[Year] [int] NULL,
	[FeeType] [nvarchar](50) NULL,
	[Amount] [money] NULL,
	[PaymentDate] [date] NULL,
	[Employee] [int] NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

GO
INSERT [dbo].[Employees] ([Id], [Name], [Gender], [Dob], [Phone], [IDNumber]) VALUES (1, N'Bùi Ngọc Huyền', N'Female', CAST(N'1993-11-04' AS Date), N'0977800234', N'035184000209')
GO
INSERT [dbo].[Employees] ([Id], [Name], [Gender], [Dob], [Phone], [IDNumber]) VALUES (2, N'Nguyễn Thu Thảo', N'Female', CAST(N'1988-09-05' AS Date), N'0904253601', N'011218982101')
GO
INSERT [dbo].[Employees] ([Id], [Name], [Gender], [Dob], [Phone], [IDNumber]) VALUES (3, N'Trần Nam Anh', N'Male', CAST(N'1987-02-17' AS Date), N'0972481765', N'012912199129')
GO
INSERT [dbo].[Employees] ([Id], [Name], [Gender], [Dob], [Phone], [IDNumber]) VALUES (4, N'Lê Bảo Nam', N'Male', CAST(N'1984-03-23' AS Date), N'0901291192', N'032122398120')
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'401', 133, 4, N'Căn hộ 01 - Tầng 4', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'402', 138, 4, N'Căn hộ 02 - Tầng 4', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'403', 154, 4, N'Căn hộ 03 - Tầng 4', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'404', 164, 4, N'Căn hộ 04 - Tầng 4', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'405', 180, 4, N'Căn hộ 05 - Tầng 4', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'501', 133, 5, N'Căn hộ 01 - Tầng 5', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'502', 138, 5, N'Căn hộ 02 - Tầng 5', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'503', 154, 5, N'Căn hộ 03 - Tầng 5', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'504', 164, 5, N'Căn hộ 04 - Tầng 5', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'601', 133, 6, N'Căn hộ 01 - Tầng 6', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'602', 138, 6, N'Căn hộ 02 - Tầng 6', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'603', 154, 6, N'Căn hộ 03 - Tầng 6', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'604', 164, 6, N'Căn hộ 04 - Tầng 6', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'605', 180, 6, N'Căn hộ 05- Tầng 6', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'701', 133, 7, N'Căn hộ 01 - Tầng 7', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'702', 138, 7, N'Căn hộ 02 - Tầng 7', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'703', 154, 7, N'Căn hộ 03 - Tầng 7', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'704', 164, 7, N'Căn hộ 04 - Tầng 7', NULL)
GO
INSERT [dbo].[Rooms] ([Title], [Square], [Floor], [Description], [Comment]) VALUES (N'705', 180, 7, N'Căn hộ 05 - Tầng 7', NULL)
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (10, N'601', 1, 2022, N'ManagementFee', 1596000.0000, CAST(N'2022-01-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (11, N'602', 1, 2022, N'ManagementFee', 1656000.0000, CAST(N'2022-01-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (12, N'603', 1, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-01-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (13, N'604', 1, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-01-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (14, N'605', 1, 2022, N'ManagementFee', 2160000.0000, CAST(N'2022-01-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (15, N'701', 1, 2022, N'ManagementFee', 1596000.0000, CAST(N'2022-01-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (16, N'702', 1, 2022, N'ManagementFee', 1656000.0000, CAST(N'2022-01-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (17, N'703', 1, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-01-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (18, N'704', 1, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-01-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (19, N'705', 1, 2022, N'ManagementFee', 2160000.0000, CAST(N'2022-01-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (20, N'401', 2, 2022, N'ManagementFee', 1596000.0000, CAST(N'2022-01-17' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (21, N'402', 2, 2022, N'ManagementFee', 1656000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (22, N'403', 2, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-02-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (23, N'404', 2, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-02-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (24, N'405', 2, 2022, N'ManagementFee', 2160000.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (25, N'501', 2, 2022, N'ManagementFee', 1596000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (26, N'502', 2, 2022, N'ManagementFee', 1656000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (27, N'503', 2, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-02-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (28, N'504', 2, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-02-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (29, N'601', 2, 2022, N'ManagementFee', 1596000.0000, CAST(N'2022-02-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (30, N'602', 2, 2022, N'ManagementFee', 1656000.0000, CAST(N'2022-02-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (31, N'603', 2, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-02-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (32, N'604', 2, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-02-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (33, N'605', 2, 2022, N'ManagementFee', 2160000.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (34, N'701', 2, 2022, N'ManagementFee', 1596000.0000, CAST(N'2022-02-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (35, N'702', 2, 2022, N'ManagementFee', 1656000.0000, CAST(N'2022-02-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (36, N'703', 2, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-02-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (37, N'704', 2, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-02-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (38, N'705', 2, 2022, N'ManagementFee', 2160000.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (39, N'401', 3, 2022, N'ManagementFee', 1596000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (40, N'402', 3, 2022, N'ManagementFee', 1656000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (41, N'403', 3, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-03-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (42, N'404', 3, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-03-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (43, N'405', 3, 2022, N'ManagementFee', 2160000.0000, CAST(N'2022-03-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (44, N'501', 3, 2022, N'ManagementFee', 1596000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (45, N'502', 3, 2022, N'ManagementFee', 1656000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (46, N'503', 3, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-03-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (47, N'504', 3, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-03-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (48, N'601', 3, 2022, N'ManagementFee', 1596000.0000, CAST(N'2022-03-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (49, N'602', 3, 2022, N'ManagementFee', 1656000.0000, CAST(N'2022-03-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (50, N'603', 3, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-03-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (51, N'604', 3, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-03-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (52, N'605', 3, 2022, N'ManagementFee', 2160000.0000, CAST(N'2022-03-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (53, N'701', 3, 2022, N'ManagementFee', 1596000.0000, CAST(N'2022-03-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (54, N'702', 3, 2022, N'ManagementFee', 1656000.0000, CAST(N'2022-03-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (55, N'703', 3, 2022, N'ManagementFee', 1848000.0000, CAST(N'2022-03-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (56, N'704', 3, 2022, N'ManagementFee', 1968000.0000, CAST(N'2022-03-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (57, N'705', 3, 2022, N'ManagementFee', 2160000.0000, CAST(N'2022-03-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (58, N'401', 1, 2022, N'ElectricityBill', 2832000.0000, CAST(N'2022-01-10' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (59, N'402', 1, 2022, N'ElectricityBill', 2844800.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (60, N'403', 1, 2022, N'ElectricityBill', 1603200.0000, CAST(N'2022-01-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (61, N'404', 1, 2022, N'ElectricityBill', 1625600.0000, CAST(N'2022-01-06' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (62, N'405', 1, 2022, N'ElectricityBill', 1664000.0000, CAST(N'2022-01-16' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (63, N'501', 1, 2022, N'ElectricityBill', 2832000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (64, N'502', 1, 2022, N'ElectricityBill', 2844800.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (65, N'503', 1, 2022, N'ElectricityBill', 1603200.0000, CAST(N'2022-01-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (66, N'504', 1, 2022, N'ElectricityBill', 1625600.0000, CAST(N'2022-01-06' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (67, N'601', 1, 2022, N'ElectricityBill', 2832000.0000, CAST(N'2022-01-13' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (68, N'602', 1, 2022, N'ElectricityBill', 2844800.0000, CAST(N'2022-01-16' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (69, N'603', 1, 2022, N'ElectricityBill', 1603200.0000, CAST(N'2022-01-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (70, N'604', 1, 2022, N'ElectricityBill', 1625600.0000, CAST(N'2022-01-06' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (71, N'605', 1, 2022, N'ElectricityBill', 1664000.0000, CAST(N'2022-01-16' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (72, N'701', 1, 2022, N'ElectricityBill', 2832000.0000, CAST(N'2022-01-13' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (73, N'702', 1, 2022, N'ElectricityBill', 2844800.0000, CAST(N'2022-01-16' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (74, N'703', 1, 2022, N'ElectricityBill', 1603200.0000, CAST(N'2022-01-14' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (75, N'704', 1, 2022, N'ElectricityBill', 1625600.0000, CAST(N'2022-01-06' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (76, N'705', 1, 2022, N'ElectricityBill', 1664000.0000, CAST(N'2022-01-16' AS Date), 3)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (77, N'401', 2, 2022, N'ElectricityBill', 1846400.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (78, N'402', 2, 2022, N'ElectricityBill', 1964800.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (79, N'403', 2, 2022, N'ElectricityBill', 2348800.0000, CAST(N'2022-02-13' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (80, N'404', 2, 2022, N'ElectricityBill', 2585600.0000, CAST(N'2022-02-19' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (81, N'405', 2, 2022, N'ElectricityBill', 1689600.0000, CAST(N'2022-02-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (82, N'501', 2, 2022, N'ElectricityBill', 1846400.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (83, N'502', 2, 2022, N'ElectricityBill', 1964800.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (84, N'503', 2, 2022, N'ElectricityBill', 2348800.0000, CAST(N'2022-02-13' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (85, N'504', 2, 2022, N'ElectricityBill', 2585600.0000, CAST(N'2022-02-19' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (86, N'601', 2, 2022, N'ElectricityBill', 1846400.0000, CAST(N'2022-02-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (87, N'602', 2, 2022, N'ElectricityBill', 1964800.0000, CAST(N'2022-02-10' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (88, N'603', 2, 2022, N'ElectricityBill', 2348800.0000, CAST(N'2022-02-13' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (89, N'604', 2, 2022, N'ElectricityBill', 2585600.0000, CAST(N'2022-02-19' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (90, N'605', 2, 2022, N'ElectricityBill', 1689600.0000, CAST(N'2022-02-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (91, N'701', 2, 2022, N'ElectricityBill', 1846400.0000, CAST(N'2022-02-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (92, N'702', 2, 2022, N'ElectricityBill', 1964800.0000, CAST(N'2022-02-10' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (93, N'703', 2, 2022, N'ElectricityBill', 2348800.0000, CAST(N'2022-02-13' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (94, N'704', 2, 2022, N'ElectricityBill', 2585600.0000, CAST(N'2022-02-19' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (95, N'705', 2, 2022, N'ElectricityBill', 1689600.0000, CAST(N'2022-02-08' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (96, N'401', 3, 2022, N'ElectricityBill', 2822400.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (97, N'402', 3, 2022, N'ElectricityBill', 2880000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (98, N'403', 3, 2022, N'ElectricityBill', 1792000.0000, CAST(N'2022-03-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (99, N'404', 3, 2022, N'ElectricityBill', 1910400.0000, CAST(N'2022-03-10' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (100, N'405', 3, 2022, N'ElectricityBill', 2102400.0000, CAST(N'2022-03-19' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (101, N'501', 3, 2022, N'ElectricityBill', 2822400.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (102, N'502', 3, 2022, N'ElectricityBill', 2880000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (103, N'503', 3, 2022, N'ElectricityBill', 1792000.0000, CAST(N'2022-03-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (104, N'504', 3, 2022, N'ElectricityBill', 1910400.0000, CAST(N'2022-03-10' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (105, N'601', 3, 2022, N'ElectricityBill', 2822400.0000, CAST(N'2022-03-10' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (106, N'602', 3, 2022, N'ElectricityBill', 2880000.0000, CAST(N'2022-03-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (107, N'603', 3, 2022, N'ElectricityBill', 1792000.0000, CAST(N'2022-03-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (108, N'604', 3, 2022, N'ElectricityBill', 1910400.0000, CAST(N'2022-03-10' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (109, N'605', 3, 2022, N'ElectricityBill', 2102400.0000, CAST(N'2022-03-19' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (110, N'701', 3, 2022, N'ElectricityBill', 2822400.0000, CAST(N'2022-03-10' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (111, N'702', 3, 2022, N'ElectricityBill', 2880000.0000, CAST(N'2022-03-11' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (112, N'703', 3, 2022, N'ElectricityBill', 1792000.0000, CAST(N'2022-03-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (113, N'704', 3, 2022, N'ElectricityBill', 1910400.0000, CAST(N'2022-03-10' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (114, N'705', 3, 2022, N'ElectricityBill', 2102400.0000, CAST(N'2022-03-19' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (115, N'401', 1, 2022, N'WaterBill', 93000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (116, N'402', 1, 2022, N'WaterBill', 93000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (117, N'403', 1, 2022, N'WaterBill', 68200.0000, CAST(N'2022-01-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (118, N'404', 1, 2022, N'WaterBill', 74400.0000, CAST(N'2022-01-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (119, N'405', 1, 2022, N'WaterBill', 74400.0000, CAST(N'2022-01-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (120, N'501', 1, 2022, N'WaterBill', 93000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (121, N'502', 1, 2022, N'WaterBill', 93000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (122, N'503', 1, 2022, N'WaterBill', 68200.0000, CAST(N'2022-01-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (123, N'504', 1, 2022, N'WaterBill', 74400.0000, CAST(N'2022-01-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (124, N'601', 1, 2022, N'WaterBill', 93000.0000, CAST(N'2022-01-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (125, N'602', 1, 2022, N'WaterBill', 93000.0000, CAST(N'2022-01-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (126, N'603', 1, 2022, N'WaterBill', 68200.0000, CAST(N'2022-01-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (127, N'604', 1, 2022, N'WaterBill', 74400.0000, CAST(N'2022-01-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (128, N'605', 1, 2022, N'WaterBill', 74400.0000, CAST(N'2022-01-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (129, N'701', 1, 2022, N'WaterBill', 93000.0000, CAST(N'2022-01-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (130, N'702', 1, 2022, N'WaterBill', 93000.0000, CAST(N'2022-01-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (131, N'703', 1, 2022, N'WaterBill', 68200.0000, CAST(N'2022-01-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (132, N'704', 1, 2022, N'WaterBill', 74400.0000, CAST(N'2022-01-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (133, N'705', 1, 2022, N'WaterBill', 74400.0000, CAST(N'2022-01-07' AS Date), 1)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (134, N'401', 2, 2022, N'WaterBill', 93000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (135, N'402', 2, 2022, N'WaterBill', 93000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (136, N'403', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (137, N'404', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (138, N'405', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (139, N'501', 2, 2022, N'WaterBill', 93000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (140, N'502', 2, 2022, N'WaterBill', 93000.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (141, N'503', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (142, N'504', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (143, N'601', 2, 2022, N'WaterBill', 93000.0000, CAST(N'2022-02-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (144, N'602', 2, 2022, N'WaterBill', 93000.0000, CAST(N'2022-02-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (145, N'603', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (146, N'604', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (147, N'605', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (148, N'701', 2, 2022, N'WaterBill', 93000.0000, CAST(N'2022-02-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (149, N'702', 2, 2022, N'WaterBill', 93000.0000, CAST(N'2022-02-12' AS Date), 2)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (150, N'703', 2, 2022, N'WaterBill', 68200.0000, CAST(N'2022-02-20' AS Date), 4)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (151, N'704', 2, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (152, N'705', 2, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (153, N'401', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (154, N'402', 3, 2022, N'WaterBill', 74400.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (155, N'403', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (156, N'404', 3, 2022, N'WaterBill', 80600.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (157, N'405', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (158, N'501', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (159, N'502', 3, 2022, N'WaterBill', 74400.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (160, N'503', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (161, N'504', 3, 2022, N'WaterBill', 80600.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (162, N'601', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (163, N'602', 3, 2022, N'WaterBill', 74400.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (164, N'603', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (165, N'604', 3, 2022, N'WaterBill', 80600.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (166, N'605', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (167, N'701', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (168, N'702', 3, 2022, N'WaterBill', 74400.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (169, N'703', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (170, N'704', 3, 2022, N'WaterBill', 80600.0000, NULL, NULL)
GO
INSERT [dbo].[Services] ([Id], [RoomTitle], [Month], [Year], [FeeType], [Amount], [PaymentDate], [Employee]) VALUES (171, N'705', 3, 2022, N'WaterBill', 68200.0000, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Employees] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Employees]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Rooms] FOREIGN KEY([RoomTitle])
REFERENCES [dbo].[Rooms] ([Title])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Rooms]
GO
USE [master]
GO
ALTER DATABASE [PRN221_Spr22] SET  READ_WRITE 
GO