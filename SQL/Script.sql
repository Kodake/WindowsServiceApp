USE [WindowsServiceApp]
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCAS_INSERT]    Script Date: 03-Nov-21 1:23:07 PM ******/
DROP PROCEDURE [dbo].[SP_MARCAS_INSERT]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 03-Nov-21 1:23:07 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Marcas]') AND type in (N'U'))
DROP TABLE [dbo].[Marcas]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 03-Nov-21 1:23:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [datetime] NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (1, CAST(N'2021-11-03T12:56:45.000' AS DateTime))
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (2, CAST(N'2021-11-03T12:56:50.000' AS DateTime))
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (3, CAST(N'2021-11-03T12:56:55.000' AS DateTime))
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (4, CAST(N'2021-11-03T12:57:00.000' AS DateTime))
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (5, CAST(N'2021-11-03T12:57:05.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCAS_INSERT]    Script Date: 03-Nov-21 1:23:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MARCAS_INSERT]
AS
BEGIN
	DECLARE @MARCA_TIMESTAMP DATETIME = GETDATE()

	SET NOCOUNT ON;

	INSERT INTO Marcas VALUES(@MARCA_TIMESTAMP);
END
GO
