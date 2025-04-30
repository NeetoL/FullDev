USE [FullDev]
GO

/****** Object: Table [dbo].[USUARIOS] Script Date: 29/04/2025 22:58:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USUARIOS] (
    [cd_usuario]   INT            IDENTITY (1, 1) NOT NULL,
    [email]        NVARCHAR (255) NULL,
    [password]     NVARCHAR (255) NULL,
    [telefone]     NVARCHAR (50)  NULL,
    [endereco]     NVARCHAR (255) NULL,
    [nome]         NVARCHAR (255) NULL,
    [sobrenome]    NVARCHAR (255) NULL,
    [dh_timestamp] DATETIME       NULL
);


