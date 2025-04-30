USE [FullDev]
GO

/****** Object: Table [dbo].[Postagens] Script Date: 29/04/2025 22:58:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[POSTAGENS] (
    [cd_postagem]  INT           IDENTITY (1, 1) NOT NULL,
    [titulo]       VARCHAR (255) NOT NULL,
    [postagem]     TEXT          NOT NULL,
    [cd_usuario]   INT           NOT NULL,
    [imagem]       VARCHAR (255) NULL,
    [dh_timestamp] DATETIME      NULL,
    [status]       VARCHAR (20)  NULL,
    [updated_at]   DATETIME      NULL
);


