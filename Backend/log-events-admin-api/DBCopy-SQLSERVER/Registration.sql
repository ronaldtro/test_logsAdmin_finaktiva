USE [master]
GO
/****** Object:  Database [Registration]    Script Date: 19/05/2025 11:07:59 p. m. ******/
CREATE DATABASE [Registration]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Registration', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Registration.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Registration_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Registration_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Registration] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Registration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Registration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Registration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Registration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Registration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Registration] SET ARITHABORT OFF 
GO
ALTER DATABASE [Registration] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Registration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Registration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Registration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Registration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Registration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Registration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Registration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Registration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Registration] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Registration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Registration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Registration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Registration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Registration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Registration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Registration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Registration] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Registration] SET  MULTI_USER 
GO
ALTER DATABASE [Registration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Registration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Registration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Registration] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Registration] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Registration] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Registration] SET QUERY_STORE = ON
GO
ALTER DATABASE [Registration] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Registration]
GO
/****** Object:  Table [dbo].[event_log]    Script Date: 19/05/2025 11:07:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[event_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[event_date] [datetime] NULL,
	[event_description] [varchar](max) NULL,
	[event_type_id] [int] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[event_type]    Script Date: 19/05/2025 11:07:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[event_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[event_type_name] [varchar](40) NULL,
	[event_type_description] [varchar](max) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[event_type] ON 

INSERT [dbo].[event_type] ([id], [event_type_name], [event_type_description], [created_at], [updated_at]) VALUES (1, N'Manual', N'Ingreso del event log desde el formulario', CAST(N'2025-05-17T05:55:40.063' AS DateTime), CAST(N'2025-05-17T05:55:40.0632767' AS DateTime2))
INSERT [dbo].[event_type] ([id], [event_type_name], [event_type_description], [created_at], [updated_at]) VALUES (2, N'Api', N'Ingreso del event log desde la api', CAST(N'2025-05-17T05:56:40.680' AS DateTime), CAST(N'2025-05-17T05:56:40.6784203' AS DateTime2))
SET IDENTITY_INSERT [dbo].[event_type] OFF
GO
ALTER TABLE [dbo].[event_log] ADD  DEFAULT (sysdatetime()) FOR [created_at]
GO
ALTER TABLE [dbo].[event_log] ADD  DEFAULT (sysdatetime()) FOR [updated_at]
GO
ALTER TABLE [dbo].[event_type] ADD  DEFAULT (sysdatetime()) FOR [created_at]
GO
ALTER TABLE [dbo].[event_type] ADD  DEFAULT (sysdatetime()) FOR [updated_at]
GO
ALTER TABLE [dbo].[event_log]  WITH CHECK ADD  CONSTRAINT [fk_eventlog_eventtype] FOREIGN KEY([event_type_id])
REFERENCES [dbo].[event_type] ([id])
GO
ALTER TABLE [dbo].[event_log] CHECK CONSTRAINT [fk_eventlog_eventtype]
GO
USE [master]
GO
ALTER DATABASE [Registration] SET  READ_WRITE 
GO
