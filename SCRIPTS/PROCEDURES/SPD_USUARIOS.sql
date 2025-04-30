USE [FullDev]
GO

/****** Object: SqlProcedure [dbo].[SPD_USUARIOS] Script Date: 29/04/2025 23:02:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE SPD_USUARIOS
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM usuarios
    WHERE cd_usuario = @Id;
END;
