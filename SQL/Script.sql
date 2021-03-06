USE [WindowsServiceApp]
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCAS_UPDATE]    Script Date: 04-Nov-21 1:00:03 AM ******/
DROP PROCEDURE [dbo].[SP_MARCAS_UPDATE]
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCAS_INSERT]    Script Date: 04-Nov-21 1:00:03 AM ******/
DROP PROCEDURE [dbo].[SP_MARCAS_INSERT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCAS_GET]    Script Date: 04-Nov-21 1:00:03 AM ******/
DROP PROCEDURE [dbo].[SP_MARCAS_GET]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 04-Nov-21 1:00:03 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Marcas]') AND type in (N'U'))
DROP TABLE [dbo].[Marcas]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 04-Nov-21 1:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [datetime] NOT NULL,
	[MarcaUpdated] [datetime] NULL,
	[Guid] [varchar](50) NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCAS_GET]    Script Date: 04-Nov-21 1:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MARCAS_GET]
AS
BEGIN
	SELECT A.Id, A.Marca, A.MarcaUpdated, A.Guid FROM Marcas A
	WHERE A.MarcaUpdated IS NULL AND A.Guid IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCAS_INSERT]    Script Date: 04-Nov-21 1:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MARCAS_INSERT]
AS
BEGIN
	DECLARE @MARCA_TIMESTAMP DATETIME = GETDATE()

	SET NOCOUNT ON;

	INSERT INTO Marcas (Marca, MarcaUpdated, Guid) VALUES(@MARCA_TIMESTAMP, NULL, NULL);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MARCAS_UPDATE]    Script Date: 04-Nov-21 1:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MARCAS_UPDATE]
	@Id int,
    @Guid varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE Marcas SET MarcaUpdated=GETDATE(), Guid=@Guid
	WHERE Id = @Id
END
GO
