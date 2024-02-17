USE [391project1]
GO

ALTER PROCEDURE checkStudentID
    @studentID VARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM student WHERE studentID = @studentID)
        SELECT 1 AS Result
    ELSE
        SELECT 0 AS Result
END
GO

EXEC checkStudentID @StudentID = 3899840;

GO

ALTER PROCEDURE [dbo].[viewAvailableCourses]
    @semester NVARCHAR(10),
    @year NVARCHAR(10),
    @courseIDPattern NVARCHAR(10) = NULL
AS
BEGIN
    SELECT s.courseID, c.courseName, s.sectionID, s.semester, s.year, s.capacity, s.enrolledCount, s.timeSlotID
    FROM [dbo].[section] s
    INNER JOIN [dbo].[course] c ON s.courseID = c.courseID
    WHERE s.semester = @semester AND s.year = @year
    AND (@courseIDPattern IS NULL OR s.courseID LIKE '%' + @courseIDPattern + '%')
END
GO

CREATE PROCEDURE [dbo].[getCourseInfo]
    @courseID NVARCHAR(10),
    @sectionID NVARCHAR(10),
    @semester NVARCHAR(10),
    @year NVARCHAR(10)
AS
BEGIN
    SELECT c.courseID, c.courseName, s.sectionID, s.semester, s.year, s.capacity, s.enrolledCount, 
           i.firstName + ' ' + i.lastName AS instructorName, ts.day, ts.startTime, ts.endTime
    FROM [dbo].[section] s
    INNER JOIN [dbo].[course] c ON s.courseID = c.courseID
    LEFT JOIN [dbo].[instructor] i ON s.instructorID = i.instructorID
    LEFT JOIN [dbo].[timeSlot] ts ON s.timeSlotID = ts.timeSlotID
    WHERE s.courseID = @courseID AND s.sectionID = @sectionID 
    AND s.semester = @semester AND s.year = @year
END
GO

CREATE PROCEDURE [dbo].[showMyCart]
    @studentID NVARCHAR(10)
AS
BEGIN
    SELECT courseID, sectionID, semester, year
    FROM [dbo].[cart]
    WHERE studentID = @studentID;
END
GO

ALTER PROCEDURE [dbo].[addToCart]
    @studentID NVARCHAR(10),
    @courseID NVARCHAR(10),
    @sectionID NVARCHAR(10),
    @semester NVARCHAR(10), 
    @year NVARCHAR(10)
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM [dbo].[cart]
        WHERE studentID = @studentID
        AND courseID = @courseID
        AND sectionID = @sectionID
        AND semester = @semester
        AND year = @year
    )
    BEGIN
        INSERT INTO [dbo].[cart] (studentID, courseID, sectionID, semester, year)
        VALUES (@studentID, @courseID, @sectionID, @semester, @year)
    END
    ELSE
    BEGIN
        RAISERROR('Course already in cart for selected semester and year', 16, 1);
    END
END
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

CREATE PROCEDURE removeFromCart
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

CREATE PROCEDURE CheckPrerequisites
    @studentID NVARCHAR(50),
    @courseID NVARCHAR(50),
    @prerequisiteMet BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PrereqCount INT;
    
    SELECT @PrereqCount = COUNT(*) 
    FROM prereq 
    WHERE courseID = @courseID;

    IF @PrereqCount = 0
    BEGIN
        SET @prerequisiteMet = 1; -- True
        RETURN;
    END;

    SELECT @prerequisiteMet = CASE WHEN COUNT(*) = @PrereqCount THEN 1 ELSE 0 END
    FROM prereq p
    LEFT JOIN takes t ON p.prereqID = t.courseID 
                      AND t.studentID = @studentID 
                      AND t.active = 'INACTIVE'
    WHERE p.courseID = @courseID;

END
GO

ALTER PROCEDURE GetPrereq
    @courseID NVARCHAR(10)
AS
BEGIN
    SET @courseID = REPLACE(REPLACE(LTRIM(RTRIM(@courseID)), CHAR(160), ' '), CHAR(32), ' ')
    SELECT * FROM prereq WHERE courseID = @courseID;
END;