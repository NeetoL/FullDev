USE [FullDev]
GO

/****** Object: Table [dbo].[GRUPO_USUARIO] Script Date: 29/04/2025 22:57:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GRUPO_USUARIO] (
    [cd_grupo_usuario] INT      IDENTITY (1, 1) NOT NULL,
    [cd_usuario]       INT      NOT NULL,
    [cd_grupo]         INT      NOT NULL,
    [dh_timestamp]     DATETIME NULL
);


