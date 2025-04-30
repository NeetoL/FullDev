USE [FullDev]
GO

/****** Object: SqlProcedure [dbo].[SPA_USUARIOS] Script Date: 29/04/2025 23:00:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE SPA_USUARIOS
    @Id INT,
    @Email VARCHAR(255),
    @Password VARCHAR(255),
    @Telefone VARCHAR(20),
    @Endereco VARCHAR(255),
    @Nome VARCHAR(100),
    @Sobrenome VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE usuarios
    SET 
        email = @Email,
        password = @Password,
        telefone = @Telefone,
        endereco = @Endereco,
        nome = @Nome,
        sobrenome = @Sobrenome
    WHERE cd_usuario = @Id;
END;
