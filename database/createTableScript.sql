/** Database Creation **/	

CREATE DATABASE [391project1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'391project1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\391project1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'391project1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\391project1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [391project1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [391project1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [391project1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [391project1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [391project1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [391project1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [391project1] SET ARITHABORT OFF 
GO
ALTER DATABASE [391project1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [391project1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [391project1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [391project1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [391project1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [391project1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [391project1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [391project1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [391project1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [391project1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [391project1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [391project1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [391project1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [391project1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [391project1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [391project1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [391project1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [391project1] SET RECOVERY FULL 
GO
ALTER DATABASE [391project1] SET  MULTI_USER 
GO
ALTER DATABASE [391project1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [391project1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [391project1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [391project1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [391project1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [391project1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'391project1', N'ON'
GO
ALTER DATABASE [391project1] SET QUERY_STORE = ON
GO
ALTER DATABASE [391project1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO



/** Table Creation **/	
USE [391project1]
GO
/****** Object:  Table [dbo].[cart]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart](
	[studentID] [nchar](10) NOT NULL,
	[courseID] [nchar](10) NOT NULL,
	[sectionID] [nchar](10) NOT NULL,
	[semester] [nchar](10) NOT NULL,
	[year] [nchar](10) NOT NULL,
 CONSTRAINT [PK_cart] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC,
	[courseID] ASC,
	[sectionID] ASC,
	[semester] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[course]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course](
	[courseID] [nchar](10) NOT NULL,
	[courseName] [nvarchar](50) NULL,
	[deptName] [nvarchar](80) NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[department]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	/** Updated from 50 to 80 cahrs **/ 
	[deptName] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[deptName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[instructor]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instructor](
	[instructorID] [nchar](10) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[deptName] [nvarchar](80) NOT NULL,
	[departmentHead] [nchar](80) NOT NULL,
 CONSTRAINT [PK_instructor] PRIMARY KEY CLUSTERED 
(
	[instructorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prereq]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prereq](
	[courseID] [nchar](10) NOT NULL,
	[prereqID] [nchar](10) NOT NULL,
 CONSTRAINT [PK_prereq] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC,
	[prereqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[section]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[section](
	[courseID] [nchar](10) NOT NULL,
	[sectionID] [nchar](10) NOT NULL,
	[semester] [nchar](10) NOT NULL,
	[year] [nchar](10) NOT NULL,
	[capacity] [nchar](10) NOT NULL,
	[enrolledCount] [nchar](10) NOT NULL,
	[instructorID] [nchar](10) NULL,
	[timeSlotID] [nchar](10) NULL,
	[day] [nchar](10) NULL,
	[startTime] [time](7) NULL,
 CONSTRAINT [PK_section] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC,
	[sectionID] ASC,
	[semester] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[studentID] [nchar](10) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[buildingNo] [nvarchar](50) NOT NULL,
	[street] [nvarchar](50) NOT NULL,
	[city] [nvarchar](50) NOT NULL,
	[province] [nvarchar](50) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
	[postalCode] [nchar](10) NOT NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[takes]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[takes](
	[studentID] [nchar](10) NOT NULL,
	[courseID] [nchar](10) NOT NULL,
	[sectionID] [nchar](10) NOT NULL,
	[semester] [nchar](10) NOT NULL,
	[year] [nchar](10) NOT NULL,
	[grade] [nchar](10) NULL,
	[active] [nchar](10) NOT NULL,
 CONSTRAINT [PK_takes] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC,
	[courseID] ASC,
	[sectionID] ASC,
	[semester] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[timeSlot]    Script Date: 2024-01-26 7:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timeSlot](
	[timeSlotID] [nchar](10) NOT NULL,
	[day] [nchar](10) NOT NULL,
	[startTime] [time](7) NOT NULL,
	[endTime] [time](7) NOT NULL,
 CONSTRAINT [PK_timeSlot] PRIMARY KEY CLUSTERED 
(
	[timeSlotID] ASC,
	[day] ASC,
	[startTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cart]  WITH CHECK ADD  CONSTRAINT [FK_cart_section] FOREIGN KEY([courseID], [sectionID], [semester], [year])
REFERENCES [dbo].[section] ([courseID], [sectionID], [semester], [year])
GO
ALTER TABLE [dbo].[cart] CHECK CONSTRAINT [FK_cart_section]
GO
ALTER TABLE [dbo].[cart]  WITH CHECK ADD  CONSTRAINT [FK_cart_student] FOREIGN KEY([studentID])
REFERENCES [dbo].[student] ([studentID])
GO
ALTER TABLE [dbo].[cart] CHECK CONSTRAINT [FK_cart_student]
GO
ALTER TABLE [dbo].[course]  WITH CHECK ADD  CONSTRAINT [FK_course_course] FOREIGN KEY([deptName])
REFERENCES [dbo].[department] ([deptName])
GO
ALTER TABLE [dbo].[course] CHECK CONSTRAINT [FK_course_course]
GO
ALTER TABLE [dbo].[instructor]  WITH CHECK ADD  CONSTRAINT [FK_instructor_department] FOREIGN KEY([deptName])
REFERENCES [dbo].[department] ([deptName])
GO
ALTER TABLE [dbo].[instructor] CHECK CONSTRAINT [FK_instructor_department]
GO
ALTER TABLE [dbo].[section]  WITH CHECK ADD  CONSTRAINT [FK_section_course] FOREIGN KEY([courseID])
REFERENCES [dbo].[course] ([courseID])
GO
ALTER TABLE [dbo].[section] CHECK CONSTRAINT [FK_section_course]
GO
ALTER TABLE [dbo].[section]  WITH CHECK ADD  CONSTRAINT [FK_section_instructor] FOREIGN KEY([instructorID])
REFERENCES [dbo].[instructor] ([instructorID])
GO
ALTER TABLE [dbo].[section] CHECK CONSTRAINT [FK_section_instructor]
GO
ALTER TABLE [dbo].[section]  WITH CHECK ADD  CONSTRAINT [FK_section_timeSlot] FOREIGN KEY([timeSlotID], [day], [startTime])
REFERENCES [dbo].[timeSlot] ([timeSlotID], [day], [startTime])
GO
ALTER TABLE [dbo].[section] CHECK CONSTRAINT [FK_section_timeSlot]
GO
ALTER TABLE [dbo].[takes]  WITH CHECK ADD  CONSTRAINT [FK_takes_section] FOREIGN KEY([courseID], [sectionID], [semester], [year])
REFERENCES [dbo].[section] ([courseID], [sectionID], [semester], [year])
GO
ALTER TABLE [dbo].[takes] CHECK CONSTRAINT [FK_takes_section]
GO
ALTER TABLE [dbo].[takes]  WITH CHECK ADD  CONSTRAINT [FK_takes_student] FOREIGN KEY([studentID])
REFERENCES [dbo].[student] ([studentID])
GO
ALTER TABLE [dbo].[takes] CHECK CONSTRAINT [FK_takes_student]
GO

ALTER DATABASE [391project1] SET  READ_WRITE 
GO
