USE [master]
GO
/****** Object:  Database [MacewanDatabase]    Script Date: 02/16/24 11:01:06 PM ******/
CREATE DATABASE [MacewanDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MacewanDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MacewanDatabase.mdf' , SIZE = 139264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MacewanDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MacewanDatabase_log.ldf' , SIZE = 532480KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MacewanDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MacewanDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MacewanDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MacewanDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MacewanDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MacewanDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MacewanDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [MacewanDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MacewanDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MacewanDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MacewanDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MacewanDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MacewanDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MacewanDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MacewanDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MacewanDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MacewanDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MacewanDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MacewanDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MacewanDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MacewanDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MacewanDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MacewanDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MacewanDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MacewanDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [MacewanDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [MacewanDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MacewanDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MacewanDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MacewanDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MacewanDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MacewanDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MacewanDatabase', N'ON'
GO
ALTER DATABASE [MacewanDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [MacewanDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MacewanDatabase]
GO
/****** Object:  Table [dbo].[cart]    Script Date: 02/16/24 11:01:06 PM ******/
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
/****** Object:  Table [dbo].[course]    Script Date: 02/16/24 11:01:06 PM ******/
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
/****** Object:  Table [dbo].[department]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[deptName] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[deptName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[instructor]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instructor](
	[instructorID] [nchar](10) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[deptName] [nvarchar](80) NOT NULL,
	[departmentHead] [nchar](10) NOT NULL,
 CONSTRAINT [PK_instructor] PRIMARY KEY CLUSTERED 
(
	[instructorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prereq]    Script Date: 02/16/24 11:01:06 PM ******/
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
/****** Object:  Table [dbo].[section]    Script Date: 02/16/24 11:01:06 PM ******/
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
 CONSTRAINT [PK_section] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC,
	[sectionID] ASC,
	[semester] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student]    Script Date: 02/16/24 11:01:06 PM ******/
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
/****** Object:  Table [dbo].[takes]    Script Date: 02/16/24 11:01:06 PM ******/
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
/****** Object:  Table [dbo].[timeSlot]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timeSlot](
	[timeSlotID] [nchar](10) NOT NULL,
	[day] [nchar](10) NOT NULL,
	[startTime] [time](7) NOT NULL,
	[endTime] [time](7) NOT NULL,
 CONSTRAINT [PK_timeSlot_1] PRIMARY KEY CLUSTERED 
(
	[timeSlotID] ASC
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
/****** Object:  StoredProcedure [dbo].[addToCart]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[addToCart]
    @studentID NVARCHAR(10),
    @courseID NVARCHAR(10),
    @sectionID NVARCHAR(10),
    @semester NVARCHAR(10),
    @year NVARCHAR(10)
AS
BEGIN
    -- Check for time slot conflicts
    DECLARE @newTimeSlotID NVARCHAR(10);
    SELECT @newTimeSlotID = timeSlotID
    FROM [dbo].[section]
    WHERE courseID = @courseID AND sectionID = @sectionID AND semester = @semester AND year = @year;

    IF EXISTS (
        SELECT 1
        FROM [dbo].[takes] t
        JOIN [dbo].[section] s ON t.courseID = s.courseID AND t.sectionID = s.sectionID
        WHERE t.studentID = @studentID AND s.timeSlotID = @newTimeSlotID AND t.semester = @semester AND t.year = @year
    )
    BEGIN
        RAISERROR('Cannot add this course to cart due to a schedule conflict.', 16, 1);
        RETURN;
    END

    -- Check for prerequisite completion
    IF EXISTS (
        SELECT 1
        FROM [dbo].[prereq] p
        WHERE p.courseID = @courseID AND NOT EXISTS (
            SELECT 1
            FROM [dbo].[takes] t
            WHERE t.studentID = @studentID AND t.courseID = p.prereqID AND t.grade IS NOT NULL
        )
    )
    BEGIN
        RAISERROR('Student has not completed all prerequisite courses.', 16, 1);
        RETURN;
    END

    -- Check if the course is already in the cart
    IF EXISTS (
        SELECT 1
        FROM [dbo].[cart]
        WHERE studentID = @studentID AND courseID = @courseID AND sectionID = @sectionID AND semester = @semester AND year = @year
    )
    BEGIN
        RAISERROR('Course already in cart for selected semester and year.', 16, 1);
        RETURN;
    END

    -- Insert the course into the cart
    INSERT INTO [dbo].[cart] (studentID, courseID, sectionID, semester, year)
    VALUES (@studentID, @courseID, @sectionID, @semester, @year);
END
GO
/****** Object:  StoredProcedure [dbo].[checkCourseAvailability]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[checkCourseAvailability]
    @courseID NVARCHAR(10),
    @sectionID NVARCHAR(10),
    @semester NVARCHAR(10),
    @year NVARCHAR(10)
AS
BEGIN
    SELECT 
        capacity,
        enrolledCount
    FROM [dbo].[section]
    WHERE courseID = @courseID
    AND sectionID = @sectionID
    AND semester = @semester
    AND year = @year;
END
GO
/****** Object:  StoredProcedure [dbo].[CheckPrerequisite]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckPrerequisite]
    @studentID NVARCHAR(50),
    @courseID NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PrerequisiteCompleted INT;

    -- Check if the student has completed the prerequisite course
    SELECT @PrerequisiteCompleted = COUNT(*)
    FROM [dbo].[takes] t
    JOIN [dbo].[prereq] p ON t.[courseID] = p.[prereqID]
    WHERE t.[studentID] = @studentID
    AND p.[courseID] = @courseID;

    IF @PrerequisiteCompleted > 0
    BEGIN
        -- Student has completed the prerequisite course
        SELECT 1 AS 'PrerequisiteMet';
    END
    ELSE
    BEGIN
        -- Student has not completed the prerequisite course
        SELECT 0 AS 'PrerequisiteMet';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[CheckPrerequisites]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckPrerequisites]
    @studentID NVARCHAR(50),
    @courseID NVARCHAR(50),
    @prerequisiteMet BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PrereqCount INT;
    
    -- Count the number of prerequisite courses for the given course
    SELECT @PrereqCount = COUNT(*) 
    FROM prereq 
    WHERE courseID = @courseID;

    IF @PrereqCount = 0
    BEGIN
        -- No prerequisites for the course, so set prerequisiteMet to true
        SET @prerequisiteMet = 1; -- True
        RETURN;
    END;

    -- Check if the student has taken all prerequisite courses
    SELECT @prerequisiteMet = CASE WHEN COUNT(*) = @PrereqCount THEN 1 ELSE 0 END
    FROM prereq p
    LEFT JOIN takes t ON p.prereqID = t.courseID 
                      AND t.studentID = @studentID 
                      AND t.active = 'INACTIVE'
    WHERE p.courseID = @courseID;

END
GO
/****** Object:  StoredProcedure [dbo].[checkStudentID]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[checkStudentID]
    @studentID VARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM student WHERE studentID = @studentID)
        SELECT 1 AS Result -- Found
    ELSE
        SELECT 0 AS Result -- Not Found
END
GO
/****** Object:  StoredProcedure [dbo].[enrolInSection]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[enrolInSection]
(
@studentID nvarchar(10) = NULL,
@courseID nvarchar(10) = NULL,
@sectionID nvarchar(10) = NULL,
@semester nvarchar(10) = NULL, 
@year nvarchar(10) = NULL,
@active nvarchar(10) = 'active'
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            print('begin')
            INSERT INTO takes(studentID, courseID, sectionID, semester, year, active)
            SELECT studentID, courseID, sectionID, semester, year, 'active'
            FROM cart
            WHERE cart.studentID = @studentID and cart.semester = @semester and cart.year = @year and cart.courseID = @courseID and cart.sectionID = @sectionID

            DELETE FROM cart
            WHERE cart.studentID = @studentID and cart.semester = @semester and cart.year = @year and cart.courseID = @courseID and cart.sectionID = @sectionID
            print('complete')
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        PRINT 'Error: ' + ERROR_MESSAGE()
        ROLLBACK TRANSACTION
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[getCourseInfo]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getCourseInfo]
    @courseID NVARCHAR(10),
    @sectionID NVARCHAR(10),
    @semester NVARCHAR(10),
    @year NVARCHAR(10)
AS
BEGIN
    SELECT 
        c.courseID, 
        c.courseName, 
        s.sectionID, 
        s.semester, 
        s.year, 
        s.capacity, 
        s.enrolledCount, 
        i.firstName + ' ' + i.lastName AS instructorName, 
        ts.day, 
        ts.startTime, 
        ts.endTime
    FROM [dbo].[section] s
    INNER JOIN [dbo].[course] c ON s.courseID = c.courseID
    LEFT JOIN [dbo].[instructor] i ON s.instructorID = i.instructorID
    LEFT JOIN [dbo].[timeSlot] ts ON s.timeSlotID = ts.timeSlotID
    WHERE s.courseID = @courseID AND s.sectionID = @sectionID 
    AND s.semester = @semester AND s.year = @year
END
GO
/****** Object:  StoredProcedure [dbo].[GetPrereq]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPrereq]
    @courseID NVARCHAR(10)
AS
BEGIN
    SET @courseID = REPLACE(REPLACE(LTRIM(RTRIM(@courseID)), CHAR(160), ' '), CHAR(32), ' ')
    SELECT * FROM prereq WHERE courseID = @courseID;
END;
GO
/****** Object:  StoredProcedure [dbo].[removeFromCart]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[removeFromCart]
    @studentID NVARCHAR(50),
    @courseID NVARCHAR(50),
    @sectionID NVARCHAR(50),
    @semester NVARCHAR(50),
    @year INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[cart]
    WHERE [studentID] = @studentID
    AND [courseID] = @courseID
    AND [sectionID] = @sectionID
    AND [semester] = @semester
    AND [year] = @year;
END
GO
/****** Object:  StoredProcedure [dbo].[showMyCart]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[showMyCart]
    @studentID NVARCHAR(10),
    @selectedSemester NVARCHAR(10) = NULL, -- Optional parameters
    @selectedYear NVARCHAR(10) = NULL
AS
BEGIN
    SELECT 
        s.courseID,
        co.courseName,
        s.sectionID,
        s.semester,
        s.year
    FROM [dbo].[cart] ca
    INNER JOIN [dbo].[section] s ON ca.courseID = s.courseID AND ca.sectionID = s.sectionID
    INNER JOIN [dbo].[course] co ON s.courseID = co.courseID
    WHERE ca.studentID = @studentID
    AND (@selectedSemester IS NULL OR s.semester = @selectedSemester)
    AND (@selectedYear IS NULL OR s.year = @selectedYear);
END
GO
/****** Object:  StoredProcedure [dbo].[showMyCourses]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[showMyCourses]
    @studentID nchar(10),
    @semester nchar(10) = NULL,
    @year nchar(10) = NULL
AS
BEGIN
    SELECT 
        c.courseID,
        c.courseName,
        s.sectionID,
        s.semester,
        s.year,
        s.capacity,
        s.enrolledCount,
        i.firstName + ' ' + i.lastName AS instructorName
    FROM takes t
    INNER JOIN course c ON t.courseID = c.courseID
    INNER JOIN section s ON c.courseID = s.courseID AND t.sectionID = s.sectionID
    LEFT JOIN instructor i ON s.instructorID = i.instructorID
    WHERE t.studentID = @studentID
    AND (@semester IS NULL OR s.semester = @semester)
    AND (@year IS NULL OR s.year = @year)
    AND t.active = 'ACTIVE';
END
GO
/****** Object:  StoredProcedure [dbo].[viewAvailableCourses]    Script Date: 02/16/24 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[viewAvailableCourses]
    @semester NVARCHAR(10),
    @year NVARCHAR(10),
    @courseIDPattern NVARCHAR(10) = NULL  -- Optional parameter to search by course ID pattern
AS
BEGIN
    SELECT s.courseID, c.courseName, s.sectionID, s.semester, s.year, s.capacity, s.enrolledCount, s.timeSlotID
    FROM [dbo].[section] s
    INNER JOIN [dbo].[course] c ON s.courseID = c.courseID
    WHERE s.semester = @semester AND s.year = @year
    AND (@courseIDPattern IS NULL OR s.courseID LIKE '%' + @courseIDPattern + '%')
END
GO
USE [master]
GO
ALTER DATABASE [MacewanDatabase] SET  READ_WRITE 
GO
