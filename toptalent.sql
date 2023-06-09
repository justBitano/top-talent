USE [master]
GO
/****** Object:  Database [TopTalent]    Script Date: 29/05/2023 8:43:29 CH ******/
CREATE DATABASE [TopTalent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TopTalent', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TopTalent.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TopTalent_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TopTalent_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TopTalent] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TopTalent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TopTalent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TopTalent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TopTalent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TopTalent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TopTalent] SET ARITHABORT OFF 
GO
ALTER DATABASE [TopTalent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TopTalent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TopTalent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TopTalent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TopTalent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TopTalent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TopTalent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TopTalent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TopTalent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TopTalent] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TopTalent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TopTalent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TopTalent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TopTalent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TopTalent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TopTalent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TopTalent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TopTalent] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TopTalent] SET  MULTI_USER 
GO
ALTER DATABASE [TopTalent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TopTalent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TopTalent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TopTalent] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TopTalent] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TopTalent] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TopTalent] SET QUERY_STORE = OFF
GO
USE [TopTalent]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 29/05/2023 8:43:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[bookingID] [int] IDENTITY(1,1) NOT NULL,
	[createDate] [datetime] NOT NULL,
	[bookingStatus] [int] NOT NULL,
	[description] [nvarchar](300) NOT NULL,
	[userID] [int] NOT NULL,
	[talentID] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[bookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingDetail]    Script Date: 29/05/2023 8:43:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetail](
	[bookingDetailID] [int] IDENTITY(1,1) NOT NULL,
	[startTime] [datetime] NOT NULL,
	[endTime] [datetime] NOT NULL,
	[cash] [float] NOT NULL,
	[bookingID] [int] NOT NULL,
 CONSTRAINT [PK_BookingDetail] PRIMARY KEY CLUSTERED 
(
	[bookingDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Talent]    Script Date: 29/05/2023 8:43:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talent](
	[talentID] [int] IDENTITY(1,1) NOT NULL,
	[talentEmail] [nvarchar](50) NOT NULL,
	[talentPassword] [nvarchar](50) NOT NULL,
	[talentName] [nvarchar](50) NOT NULL,
	[talentPhone] [int] NULL,
	[talentAddress] [nvarchar](50) NULL,
	[talentDescription] [nvarchar](300) NOT NULL,
	[talentStatus] [int] NOT NULL,
 CONSTRAINT [PK_Talent] PRIMARY KEY CLUSTERED 
(
	[talentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29/05/2023 8:43:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[userEmail] [nvarchar](50) NOT NULL,
	[userPassword] [nvarchar](50) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[userPhone] [int] NULL,
	[userAddress] [nvarchar](50) NULL,
	[userDescription] [nvarchar](300) NOT NULL,
	[userStatus] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([bookingID], [createDate], [bookingStatus], [description], [userID], [talentID]) VALUES (1, CAST(N'2023-05-29T00:00:00.000' AS DateTime), 1, N'làm đi được 5 xị', 1, 3)
INSERT [dbo].[Booking] ([bookingID], [createDate], [bookingStatus], [description], [userID], [talentID]) VALUES (2, CAST(N'2023-05-29T00:00:00.000' AS DateTime), 1, N'làm đi được 1 tỏi', 1, 1)
INSERT [dbo].[Booking] ([bookingID], [createDate], [bookingStatus], [description], [userID], [talentID]) VALUES (4, CAST(N'2023-05-29T00:00:00.000' AS DateTime), 1, N'làm đi được nổi tiếng', 2, 3)
INSERT [dbo].[Booking] ([bookingID], [createDate], [bookingStatus], [description], [userID], [talentID]) VALUES (5, CAST(N'2023-05-29T00:00:00.000' AS DateTime), 1, N'làm đi k cho gì hết', 2, 1)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingDetail] ON 

INSERT [dbo].[BookingDetail] ([bookingDetailID], [startTime], [endTime], [cash], [bookingID]) VALUES (1, CAST(N'2023-05-30T00:00:00.000' AS DateTime), CAST(N'2023-05-31T00:00:00.000' AS DateTime), 500, 1)
INSERT [dbo].[BookingDetail] ([bookingDetailID], [startTime], [endTime], [cash], [bookingID]) VALUES (2, CAST(N'2023-05-30T00:00:00.000' AS DateTime), CAST(N'2023-05-31T00:00:00.000' AS DateTime), 1000, 2)
INSERT [dbo].[BookingDetail] ([bookingDetailID], [startTime], [endTime], [cash], [bookingID]) VALUES (6, CAST(N'2023-05-30T00:00:00.000' AS DateTime), CAST(N'2023-05-30T00:00:00.000' AS DateTime), 1, 4)
INSERT [dbo].[BookingDetail] ([bookingDetailID], [startTime], [endTime], [cash], [bookingID]) VALUES (7, CAST(N'2023-05-30T00:00:00.000' AS DateTime), CAST(N'2023-05-30T00:00:00.000' AS DateTime), 0, 5)
SET IDENTITY_INSERT [dbo].[BookingDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Talent] ON 

INSERT [dbo].[Talent] ([talentID], [talentEmail], [talentPassword], [talentName], [talentPhone], [talentAddress], [talentDescription], [talentStatus]) VALUES (1, N'talent@gmail.com', N'talent', N'Talent', 0, N'0', N'mô tả công việc nè', 1)
INSERT [dbo].[Talent] ([talentID], [talentEmail], [talentPassword], [talentName], [talentPhone], [talentAddress], [talentDescription], [talentStatus]) VALUES (3, N'talent2@gmail.com', N'talent2', N'Talent 2', 0, N'0', N'mô tả công việc nè', 1)
SET IDENTITY_INSERT [dbo].[Talent] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([userID], [userEmail], [userPassword], [userName], [userPhone], [userAddress], [userDescription], [userStatus]) VALUES (1, N'user@gmail.com', N'user', N'User', 0, N'0', N'0', 1)
INSERT [dbo].[User] ([userID], [userEmail], [userPassword], [userName], [userPhone], [userAddress], [userDescription], [userStatus]) VALUES (2, N'user2@gmail.com', N'user', N'User', 0, N'0', N'0', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Talent] FOREIGN KEY([talentID])
REFERENCES [dbo].[Talent] ([talentID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Talent]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_User]
GO
ALTER TABLE [dbo].[BookingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetail_Booking] FOREIGN KEY([bookingID])
REFERENCES [dbo].[Booking] ([bookingID])
GO
ALTER TABLE [dbo].[BookingDetail] CHECK CONSTRAINT [FK_BookingDetail_Booking]
GO
USE [master]
GO
ALTER DATABASE [TopTalent] SET  READ_WRITE 
GO
