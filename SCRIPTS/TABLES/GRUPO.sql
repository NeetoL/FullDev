USE [FullDev]
GO

/****** Object: Table [dbo].[GRUPO] Script Date: 29/04/2025 22:56:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GRUPO] (
    [cd_grupo]     INT            IDENTITY (1, 1) NOT NULL,
    [nm_grupo]     NVARCHAR (100) NOT NULL,
    [cd_status]    INT            NOT NULL,
    [dh_timestamp] DATETIME       NULL
);


