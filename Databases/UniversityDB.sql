USE [master]
GO
/****** Object:  Database [UniversityDB]    Script Date: 1/3/2024 3:44:03 PM ******/
CREATE DATABASE [UniversityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityDB', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\UniversityDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniversityDB_log', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\UniversityDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UniversityDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniversityDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniversityDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UniversityDB] SET QUERY_STORE = OFF
GO
USE [UniversityDB]
GO
/****** Object:  Table [dbo].[Major]    Script Date: 1/3/2024 3:44:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Major](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[credit] [nvarchar](50) NULL,
	[comment] [nvarchar](100) NULL,
 CONSTRAINT [PK_Major] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/3/2024 3:44:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[dob] [date] NULL,
	[gender] [bit] NULL,
	[Phone] [nvarchar](50) NULL,
	[major] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studentif]    Script Date: 1/3/2024 3:44:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studentif](
	[Rollnumber] [nchar](10) NOT NULL,
	[studentName] [nvarchar](50) NULL,
	[dateofbirth] [date] NULL,
	[address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Studentif] PRIMARY KEY CLUSTERED 
(
	[Rollnumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Major] ON 

INSERT [dbo].[Major] ([Id], [Name], [credit], [comment]) VALUES (1, N'Information Technolofy', N'140', N'no')
INSERT [dbo].[Major] ([Id], [Name], [credit], [comment]) VALUES (2, N'Security', N'140', N'no')
INSERT [dbo].[Major] ([Id], [Name], [credit], [comment]) VALUES (3, N'Iot', N'140', N'no')
INSERT [dbo].[Major] ([Id], [Name], [credit], [comment]) VALUES (4, N'AI', N'144', N'no')
SET IDENTITY_INSERT [dbo].[Major] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [dob], [gender], [Phone], [major]) VALUES (1, N'Lê Văn Chung', CAST(N'1984-08-25' AS Date), 1, N'0988311658', 1)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[Studentif] ([Rollnumber], [studentName], [dateofbirth], [address]) VALUES (N'HE161777  ', N'Lê Công Danh', CAST(N'2001-07-06' AS Date), N'Ha Noi')
INSERT [dbo].[Studentif] ([Rollnumber], [studentName], [dateofbirth], [address]) VALUES (N'HE161797  ', N'Lê Công hà', CAST(N'2001-07-01' AS Date), N'Ha Tay')
INSERT [dbo].[Studentif] ([Rollnumber], [studentName], [dateofbirth], [address]) VALUES (N'HE171001  ', N'Nguyen Huu Hoa', CAST(N'1990-12-05' AS Date), N'No 030-0074321 Hang bun')
INSERT [dbo].[Studentif] ([Rollnumber], [studentName], [dateofbirth], [address]) VALUES (N'HE171002  ', N'Le Quang Liem', CAST(N'1988-03-22' AS Date), N'No 030-0074321 Hang bun')
INSERT [dbo].[Studentif] ([Rollnumber], [studentName], [dateofbirth], [address]) VALUES (N'HE1710022 ', N'Nguyen Huu Hue', CAST(N'1986-12-05' AS Date), N'No 030-0074321 Hang bun')
INSERT [dbo].[Studentif] ([Rollnumber], [studentName], [dateofbirth], [address]) VALUES (N'HE1710033 ', N'Nguyen Huu Hoan', CAST(N'1984-12-05' AS Date), N'No 030-0074321 Hang bun')
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Major] FOREIGN KEY([major])
REFERENCES [dbo].[Major] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Major]
GO
USE [master]
GO
ALTER DATABASE [UniversityDB] SET  READ_WRITE 
GO
