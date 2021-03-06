USE [EConcierge]
GO
/****** Object:  Table [dbo].[TransportationTaxi]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationTaxi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TranspotationId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TransportationTaxi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transportation]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[TransportationType] [int] NOT NULL,
 CONSTRAINT [PK_Transportation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PointOfInterest]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PointOfInterest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Photo] [image] NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_PointOfInterest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mall]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mall](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Photo] [image] NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_Mall] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cafe]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cafe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Photo] [image] NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_Cafe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ATM]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ATM](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Photo] [image] NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_ATM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiningCategory]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiningCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_DiningCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventCalendarCategory]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventCalendarCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_EventCalendarCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiningSubCategory]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiningSubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_DiningSubCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DELETECafe]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETECafe](@Id int)
AS
DELETE FROM [Cafe]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[DELETEATM]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETEATM](@Id int)
AS
DELETE FROM [ATM]
WHERE [Id]=@Id
GO
/****** Object:  Table [dbo].[CalendarEvent]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarEvent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Photo] [image] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Location] [nvarchar](200) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_CalendarEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DELETETransportation]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETETransportation](@Id int)
AS
DELETE FROM [Transportation]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[DELETEPointOfInterest]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETEPointOfInterest](@Id int)
AS
DELETE FROM [PointOfInterest]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[DELETEMall]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETEMall](@Id int)
AS
DELETE FROM [Mall]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[DELETEEventCalendarCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETEEventCalendarCategory](@Id int)
AS
DELETE FROM [EventCalendarCategory]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[DELETEDiningCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETEDiningCategory](@Id int)
AS
DELETE FROM [DiningCategory]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[DELETETransportationTaxi]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETETransportationTaxi](@Id int)
AS
DELETE FROM [TransportationTaxi]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[INSERTCafe]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTCafe](@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
INSERT INTO [Cafe]([Title] ,[Description] ,[Photo] ,[Address] ,[Phone] ,[Latitude] ,[Longitude] )
VALUES(@Title,@Description,@Photo,@Address,@Phone,@Latitude,@Longitude)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[INSERTATM]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTATM](@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
INSERT INTO [ATM]([Title] ,[Description] ,[Photo] ,[Address] ,[Phone] ,[Latitude] ,[Longitude] )
VALUES(@Title,@Description,@Photo,@Address,@Phone,@Latitude,@Longitude)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[INSERTTransportationTaxi]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTTransportationTaxi](@TranspotationId int,@Title nvarchar(100),@Phone nvarchar(50))
AS
INSERT INTO [TransportationTaxi]([TranspotationId] ,[Title] ,[Phone] )
VALUES(@TranspotationId,@Title,@Phone)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  Table [dbo].[TransportationMonorail]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationMonorail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TranportationId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Photo] [image] NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_TransportationMonorail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UPDATECafe]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATECafe](@Id int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
UPDATE [Cafe] SET [Title]=@Title,[Description]=@Description,[Photo]=@Photo,[Address]=@Address,[Phone]=@Phone,[Latitude]=@Latitude,[Longitude]=@Longitude
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATEATM]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEATM](@Id int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
UPDATE [ATM] SET [Title]=@Title,[Description]=@Description,[Photo]=@Photo,[Address]=@Address,[Phone]=@Phone,[Latitude]=@Latitude,[Longitude]=@Longitude
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[INSERTDiningCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTDiningCategory](@Title nvarchar(100),@Description nvarchar(200))
AS
INSERT INTO [DiningCategory]([Title] ,[Description] )
VALUES(@Title,@Description)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[INSERTTransportation]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTTransportation](@Title nvarchar(100),@Description nvarchar(200),@TransportationType int)
AS
INSERT INTO [Transportation]([Title] ,[Description] ,[TransportationType] )
VALUES(@Title,@Description,@TransportationType)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[INSERTPointOfInterest]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTPointOfInterest](@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
INSERT INTO [PointOfInterest]([Title] ,[Description] ,[Photo] ,[Address] ,[Phone] ,[Latitude] ,[Longitude] )
VALUES(@Title,@Description,@Photo,@Address,@Phone,@Latitude,@Longitude)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[INSERTMall]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTMall](@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
INSERT INTO [Mall]([Title] ,[Description] ,[Photo] ,[Address] ,[Phone] ,[Latitude] ,[Longitude] )
VALUES(@Title,@Description,@Photo,@Address,@Phone,@Latitude,@Longitude)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[INSERTEventCalendarCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTEventCalendarCategory](@Name nvarchar(100),@Description nvarchar(200))
AS
INSERT INTO [EventCalendarCategory]([Name] ,[Description] )
VALUES(@Name,@Description)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[UPDATEDiningCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEDiningCategory](@Id int,@Title nvarchar(100),@Description nvarchar(200))
AS
UPDATE [DiningCategory] SET [Title]=@Title,[Description]=@Description
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATETransportationTaxi]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATETransportationTaxi](@Id int,@TranspotationId int,@Title nvarchar(100),@Phone nvarchar(50))
AS
UPDATE [TransportationTaxi] SET [TranspotationId]=@TranspotationId,[Title]=@Title,[Phone]=@Phone
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATETransportation]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATETransportation](@Id int,@Title nvarchar(100),@Description nvarchar(200),@TransportationType int)
AS
UPDATE [Transportation] SET [Title]=@Title,[Description]=@Description,[TransportationType]=@TransportationType
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATEPointOfInterest]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEPointOfInterest](@Id int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
UPDATE [PointOfInterest] SET [Title]=@Title,[Description]=@Description,[Photo]=@Photo,[Address]=@Address,[Phone]=@Phone,[Latitude]=@Latitude,[Longitude]=@Longitude
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATEMall]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEMall](@Id int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
UPDATE [Mall] SET [Title]=@Title,[Description]=@Description,[Photo]=@Photo,[Address]=@Address,[Phone]=@Phone,[Latitude]=@Latitude,[Longitude]=@Longitude
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATEEventCalendarCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEEventCalendarCategory](@Id int,@Name nvarchar(100),@Description nvarchar(200))
AS
UPDATE [EventCalendarCategory] SET [Name]=@Name,[Description]=@Description
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATECalendarEvent]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATECalendarEvent](@Id int,@CategoryId int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@StartDate datetime,@EndDate datetime,@Location nvarchar(200),@Latitude float,@Longitude nchar(10))
AS
UPDATE [CalendarEvent] SET [CategoryId]=@CategoryId,[Title]=@Title,[Description]=@Description,[Photo]=@Photo,[StartDate]=@StartDate,[EndDate]=@EndDate,[Location]=@Location,[Latitude]=@Latitude,[Longitude]=@Longitude
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATEDiningSubCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEDiningSubCategory](@Id int,@CategoryId int,@Title nvarchar(100),@Description nvarchar(100))
AS
UPDATE [DiningSubCategory] SET [CategoryId]=@CategoryId,[Title]=@Title,[Description]=@Description
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATETransportationMonorail]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATETransportationMonorail](@Id int,@TranportationId int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
UPDATE [TransportationMonorail] SET [TranportationId]=@TranportationId,[Title]=@Title,[Description]=@Description,[Photo]=@Photo,[Address]=@Address,[Phone]=@Phone,[Latitude]=@Latitude,[Longitude]=@Longitude
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[INSERTDiningSubCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTDiningSubCategory](@CategoryId int,@Title nvarchar(100),@Description nvarchar(100))
AS
INSERT INTO [DiningSubCategory]([CategoryId] ,[Title] ,[Description] )
VALUES(@CategoryId,@Title,@Description)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[INSERTTransportationMonorail]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTTransportationMonorail](@TranportationId int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(200),@Phone nvarchar(50),@Latitude float,@Longitude float)
AS
INSERT INTO [TransportationMonorail]([TranportationId] ,[Title] ,[Description] ,[Photo] ,[Address] ,[Phone] ,[Latitude] ,[Longitude] )
VALUES(@TranportationId,@Title,@Description,@Photo,@Address,@Phone,@Latitude,@Longitude)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[INSERTCalendarEvent]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTCalendarEvent](@CategoryId int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@StartDate datetime,@EndDate datetime,@Location nvarchar(200),@Latitude float,@Longitude float)
AS
INSERT INTO [CalendarEvent]([CategoryId] ,[Title] ,[Description] ,[Photo] ,[StartDate] ,[EndDate] ,[Location] ,[Latitude] ,[Longitude] )
VALUES(@CategoryId,@Title,@Description,@Photo,@StartDate,@EndDate,@Location,@Latitude,@Longitude)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[DELETECalendarEvent]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETECalendarEvent](@Id int)
AS
DELETE FROM [CalendarEvent]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[DELETETransportationMonorail]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETETransportationMonorail](@Id int)
AS
DELETE FROM [TransportationMonorail]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[DELETEDiningSubCategory]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETEDiningSubCategory](@Id int)
AS
DELETE FROM [DiningSubCategory]
WHERE [Id]=@Id
GO
/****** Object:  Table [dbo].[Dining]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dining](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Photo] [image] NULL,
	[Address] [nvarchar](100) NULL,
	[Telephone] [nvarchar](50) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_Dining] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiningMenu]    Script Date: 11/28/2010 20:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiningMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiningId] [int] NOT NULL,
	[Photo] [image] NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DiningMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DELETEDining]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETEDining](@Id int)
AS
DELETE FROM [Dining]
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[INSERTDining]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTDining](@SubCategoryId int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(100),@Telephone nvarchar(50),@Latitude float,@Longitude float)
AS
INSERT INTO [Dining]([SubCategoryId] ,[Title] ,[Description] ,[Photo] ,[Address] ,[Telephone] ,[Latitude] ,[Longitude] )
VALUES(@SubCategoryId,@Title,@Description,@Photo,@Address,@Telephone,@Latitude,@Longitude)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[UPDATEDining]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEDining](@Id int,@SubCategoryId int,@Title nvarchar(100),@Description nvarchar(200),@Photo image,@Address nvarchar(100),@Telephone nvarchar(50),@Latitude float,@Longitude float)
AS
UPDATE [Dining] SET [SubCategoryId]=@SubCategoryId,[Title]=@Title,[Description]=@Description,[Photo]=@Photo,[Address]=@Address,[Telephone]=@Telephone,[Latitude]=@Latitude,[Longitude]=@Longitude
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[UPDATEDiningMenu]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEDiningMenu](@Id int,@DiningId int,@Photo image,@FileName nvarchar(50))
AS
UPDATE [DiningMenu] SET [DiningId]=@DiningId,[Photo]=@Photo,[FileName]=@FileName
WHERE [Id]=@Id
GO
/****** Object:  StoredProcedure [dbo].[INSERTDiningMenu]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTDiningMenu](@DiningId int,@Photo image,@FileName nvarchar(50))
AS
INSERT INTO [DiningMenu]([DiningId] ,[Photo] ,[FileName] )
VALUES(@DiningId,@Photo,@FileName)
SELECT SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[DELETEDiningMenu]    Script Date: 11/28/2010 20:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETEDiningMenu](@Id int)
AS
DELETE FROM [DiningMenu]
WHERE [Id]=@Id
GO
/****** Object:  ForeignKey [FK_CalendarEvent_EventCalendarCategory]    Script Date: 11/28/2010 20:43:12 ******/
ALTER TABLE [dbo].[CalendarEvent]  WITH CHECK ADD  CONSTRAINT [FK_CalendarEvent_EventCalendarCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[EventCalendarCategory] ([Id])
GO
ALTER TABLE [dbo].[CalendarEvent] CHECK CONSTRAINT [FK_CalendarEvent_EventCalendarCategory]
GO
/****** Object:  ForeignKey [FK_Dining_DiningSubCategory]    Script Date: 11/28/2010 20:43:12 ******/
ALTER TABLE [dbo].[Dining]  WITH CHECK ADD  CONSTRAINT [FK_Dining_DiningSubCategory] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[DiningSubCategory] ([Id])
GO
ALTER TABLE [dbo].[Dining] CHECK CONSTRAINT [FK_Dining_DiningSubCategory]
GO
/****** Object:  ForeignKey [FK_DiningMenu_Dining]    Script Date: 11/28/2010 20:43:12 ******/
ALTER TABLE [dbo].[DiningMenu]  WITH CHECK ADD  CONSTRAINT [FK_DiningMenu_Dining] FOREIGN KEY([DiningId])
REFERENCES [dbo].[Dining] ([Id])
GO
ALTER TABLE [dbo].[DiningMenu] CHECK CONSTRAINT [FK_DiningMenu_Dining]
GO
/****** Object:  ForeignKey [FK_DiningSubCategory_DiningCategory]    Script Date: 11/28/2010 20:43:12 ******/
ALTER TABLE [dbo].[DiningSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_DiningSubCategory_DiningCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[DiningCategory] ([Id])
GO
ALTER TABLE [dbo].[DiningSubCategory] CHECK CONSTRAINT [FK_DiningSubCategory_DiningCategory]
GO
/****** Object:  ForeignKey [FK_TransportationMonorail_Transportation]    Script Date: 11/28/2010 20:43:12 ******/
ALTER TABLE [dbo].[TransportationMonorail]  WITH CHECK ADD  CONSTRAINT [FK_TransportationMonorail_Transportation] FOREIGN KEY([TranportationId])
REFERENCES [dbo].[Transportation] ([Id])
GO
ALTER TABLE [dbo].[TransportationMonorail] CHECK CONSTRAINT [FK_TransportationMonorail_Transportation]
GO
