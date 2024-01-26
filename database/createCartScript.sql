USE [391project1]
GO

/****** Object:  Table [dbo].[cart]    Script Date: 2024-01-26 2:35:03 PM ******/
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


