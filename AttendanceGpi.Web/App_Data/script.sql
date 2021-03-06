USE [master]
GO
/****** Object:  Database [SimpleAttendance]    Script Date: 09/21/2018 5:30:50 PM ******/
CREATE DATABASE [SimpleAttendance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimpleAttendance', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SimpleAttendance.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SimpleAttendance_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SimpleAttendance_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SimpleAttendance] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimpleAttendance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimpleAttendance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SimpleAttendance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SimpleAttendance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SimpleAttendance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SimpleAttendance] SET ARITHABORT OFF 
GO
ALTER DATABASE [SimpleAttendance] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SimpleAttendance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SimpleAttendance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SimpleAttendance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SimpleAttendance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SimpleAttendance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SimpleAttendance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SimpleAttendance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SimpleAttendance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SimpleAttendance] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SimpleAttendance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SimpleAttendance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SimpleAttendance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SimpleAttendance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SimpleAttendance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SimpleAttendance] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SimpleAttendance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SimpleAttendance] SET RECOVERY FULL 
GO
ALTER DATABASE [SimpleAttendance] SET  MULTI_USER 
GO
ALTER DATABASE [SimpleAttendance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SimpleAttendance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SimpleAttendance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SimpleAttendance] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SimpleAttendance] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SimpleAttendance', N'ON'
GO
ALTER DATABASE [SimpleAttendance] SET QUERY_STORE = OFF
GO
USE [SimpleAttendance]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SimpleAttendance]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 09/21/2018 5:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 09/21/2018 5:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 09/21/2018 5:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 09/21/2018 5:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 09/21/2018 5:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[SchedId] [int] NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeesInfo]    Script Date: 09/21/2018 5:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesInfo](
	[UserId] [varchar](max) NOT NULL,
	[Name] [varchar](max) NULL,
	[Picture] [varchar](max) NULL,
	[Position] [varchar](max) NULL,
	[CardNo] [varchar](max) NULL,
	[IsResigned] [tinyint] NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Deleted] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 09/21/2018 5:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](max) NULL,
	[SchedId] [int] NULL,
	[TimeIn] [datetime] NOT NULL,
	[TimeOut] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 09/21/2018 5:30:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[SchedId] [int] IDENTITY(1,1) NOT NULL,
	[SchedName] [varchar](max) NULL,
	[SchedStart] [varchar](max) NULL,
	[SchedEnd] [varchar](max) NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[SchedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'eb0d4307-52b2-41c4-8c8a-37a4ab23204b', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'63e13c1c-0324-48e6-849b-282932c39c39', N'Employee')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8bf74119-2112-4ac3-a9ff-f2a0f26eb816', N'63e13c1c-0324-48e6-849b-282932c39c39')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f4a7ffcf-5ce2-4ef1-93cc-54fa0ded047d', N'eb0d4307-52b2-41c4-8c8a-37a4ab23204b')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [SchedId]) VALUES (N'8bf74119-2112-4ac3-a9ff-f2a0f26eb816', N'jio_qzn@yahoo.com', NULL, 0, N'ACt6+HLt63Jd26F9ZhtXC/POjKLArWMkr/P31n8w8Z26S+5EOtk/hntdF+ShCX1qIg==', N'5d4d9c71-dc29-477f-a775-fcaf051ca88b', NULL, 0, 0, NULL, 0, 0, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [SchedId]) VALUES (N'f4a7ffcf-5ce2-4ef1-93cc-54fa0ded047d', N'Admin', NULL, 0, N'AOySUhN6g3U25mPz6NIey6dlkzQHQAva/GYHeSIsedkoNB5ilHrx5vVbxSlJ12/8HQ==', N'69c4d332-69ed-4f26-a144-a5edf0160b89', NULL, 0, 0, NULL, 0, 0, 1)
INSERT [dbo].[EmployeesInfo] ([UserId], [Name], [Picture], [Position], [CardNo], [IsResigned], [Created], [Updated], [Deleted]) VALUES (N'8bf74119-2112-4ac3-a9ff-f2a0f26eb816', N'Justine Joshua Quiazon', N'5692552.png', N'Software Developer', N'123456', 0, CAST(N'2018-09-21T17:08:02.000' AS DateTime), CAST(N'2018-09-21T17:26:23.500' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([LogId], [UserId], [SchedId], [TimeIn], [TimeOut]) VALUES (1, N'0', 1, CAST(N'2018-09-21T17:08:02.617' AS DateTime), CAST(N'2018-09-21T17:08:02.617' AS DateTime))
INSERT [dbo].[Logs] ([LogId], [UserId], [SchedId], [TimeIn], [TimeOut]) VALUES (2, N'8bf74119-2112-4ac3-a9ff-f2a0f26eb816', 1, CAST(N'2018-09-21T17:20:14.567' AS DateTime), CAST(N'2018-09-21T17:20:18.363' AS DateTime))
INSERT [dbo].[Logs] ([LogId], [UserId], [SchedId], [TimeIn], [TimeOut]) VALUES (3, N'8bf74119-2112-4ac3-a9ff-f2a0f26eb816', 1, CAST(N'2018-09-21T17:21:52.267' AS DateTime), CAST(N'2018-09-21T17:22:52.000' AS DateTime))
INSERT [dbo].[Logs] ([LogId], [UserId], [SchedId], [TimeIn], [TimeOut]) VALUES (4, N'8bf74119-2112-4ac3-a9ff-f2a0f26eb816', 1, CAST(N'2018-09-21T17:23:33.663' AS DateTime), CAST(N'2018-09-21T17:23:40.637' AS DateTime))
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Schedules] ON 

INSERT [dbo].[Schedules] ([SchedId], [SchedName], [SchedStart], [SchedEnd]) VALUES (1, N'Default', N'08:00', N'05:00')
SET IDENTITY_INSERT [dbo].[Schedules] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 09/21/2018 5:30:50 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 09/21/2018 5:30:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 09/21/2018 5:30:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 09/21/2018 5:30:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 09/21/2018 5:30:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 09/21/2018 5:30:50 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_SchedId]  DEFAULT ((0)) FOR [SchedId]
GO
ALTER TABLE [dbo].[EmployeesInfo] ADD  CONSTRAINT [DF_EmployeesInfo_IsResigned]  DEFAULT ((0)) FOR [IsResigned]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [SimpleAttendance] SET  READ_WRITE 
GO
