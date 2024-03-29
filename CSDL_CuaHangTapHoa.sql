USE [master]
GO
/****** Object:  Database [CHTapHoa]    Script Date: 5/18/2017 9:28:50 PM ******/
CREATE DATABASE [CHTapHoa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CHTapHoa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.DUONG\MSSQL\DATA\CHTapHoa.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CHTapHoa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.DUONG\MSSQL\DATA\CHTapHoa_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CHTapHoa] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CHTapHoa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CHTapHoa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CHTapHoa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CHTapHoa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CHTapHoa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CHTapHoa] SET ARITHABORT OFF 
GO
ALTER DATABASE [CHTapHoa] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CHTapHoa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CHTapHoa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CHTapHoa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CHTapHoa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CHTapHoa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CHTapHoa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CHTapHoa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CHTapHoa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CHTapHoa] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CHTapHoa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CHTapHoa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CHTapHoa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CHTapHoa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CHTapHoa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CHTapHoa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CHTapHoa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CHTapHoa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CHTapHoa] SET  MULTI_USER 
GO
ALTER DATABASE [CHTapHoa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CHTapHoa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CHTapHoa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CHTapHoa] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CHTapHoa] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CHTapHoa]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 5/18/2017 9:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL DEFAULT (N'Danh mục chưa có tên'),
	[content] [nvarchar](255) NULL,
	[hide] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 5/18/2017 9:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[content] [nvarchar](255) NULL,
	[gia] [float] NOT NULL DEFAULT ((0)),
	[typegia] [int] NOT NULL DEFAULT ((0)),
	[starttime] [date] NULL DEFAULT (getdate()),
	[endtime] [date] NULL DEFAULT (getdate()),
	[hide] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KMInfo]    Script Date: 5/18/2017 9:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KMInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idKM] [int] NOT NULL,
	[idMH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MatHang]    Script Date: 5/18/2017 9:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDM] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL DEFAULT (N'Chưa có tên'),
	[soluong] [int] NOT NULL DEFAULT ((0)),
	[gianhap] [float] NOT NULL DEFAULT ((0)),
	[giaban] [float] NOT NULL DEFAULT ((0)),
	[hide] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 5/18/2017 9:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL CONSTRAINT [DF__NhaCungCap__name__1920BF5C]  DEFAULT (N'Chưa có tên'),
	[content] [nvarchar](255) NULL,
	[sdt] [varchar](11) NOT NULL,
	[diachi] [nvarchar](255) NOT NULL,
	[hide] [int] NOT NULL CONSTRAINT [DF__NhaCungCap__hide__1A14E395]  DEFAULT ((0)),
 CONSTRAINT [PK__NhaCungC__3213E83F8365041D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/18/2017 9:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[chucvu] [nvarchar](255) NOT NULL DEFAULT ((1)),
	[gioitinh] [int] NOT NULL DEFAULT ((0)),
	[diachi] [nvarchar](255) NOT NULL,
	[sdt] [varchar](10) NULL,
	[hide] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhapHang]    Script Date: 5/18/2017 9:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhapHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idMH] [int] NOT NULL,
	[idNCC] [int] NOT NULL,
	[idNV] [int] NOT NULL,
	[soluong] [int] NOT NULL DEFAULT ((0)),
	[thanhtien] [float] NOT NULL DEFAULT ((0)),
	[ngaynhap] [date] NOT NULL DEFAULT (getdate()),
	[hide] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[XuatHang]    Script Date: 5/18/2017 9:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XuatHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idMH] [int] NOT NULL,
	[idNV] [int] NOT NULL,
	[soluong] [int] NULL DEFAULT ((0)),
	[thanhtien] [float] NOT NULL DEFAULT ((0)),
	[ngayxuat] [date] NOT NULL DEFAULT (getdate()),
	[hide] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[KMInfo]  WITH CHECK ADD FOREIGN KEY([idKM])
REFERENCES [dbo].[KhuyenMai] ([id])
GO
ALTER TABLE [dbo].[KMInfo]  WITH CHECK ADD FOREIGN KEY([idMH])
REFERENCES [dbo].[MatHang] ([id])
GO
ALTER TABLE [dbo].[MatHang]  WITH CHECK ADD FOREIGN KEY([idDM])
REFERENCES [dbo].[DanhMuc] ([id])
GO
ALTER TABLE [dbo].[NhapHang]  WITH CHECK ADD FOREIGN KEY([idMH])
REFERENCES [dbo].[MatHang] ([id])
GO
ALTER TABLE [dbo].[NhapHang]  WITH CHECK ADD  CONSTRAINT [FK__NhapHang__idNCC__30F848ED] FOREIGN KEY([idNCC])
REFERENCES [dbo].[NhaCungCap] ([id])
GO
ALTER TABLE [dbo].[NhapHang] CHECK CONSTRAINT [FK__NhapHang__idNCC__30F848ED]
GO
ALTER TABLE [dbo].[NhapHang]  WITH CHECK ADD FOREIGN KEY([idNV])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[XuatHang]  WITH CHECK ADD FOREIGN KEY([idMH])
REFERENCES [dbo].[MatHang] ([id])
GO
ALTER TABLE [dbo].[XuatHang]  WITH CHECK ADD FOREIGN KEY([idNV])
REFERENCES [dbo].[NhanVien] ([id])
GO
USE [master]
GO
ALTER DATABASE [CHTapHoa] SET  READ_WRITE 
GO
