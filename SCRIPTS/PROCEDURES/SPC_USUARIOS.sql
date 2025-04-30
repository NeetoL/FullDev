USE [FullDev]
GO

/****** Object: SqlProcedure [dbo].[SPC_USUARIOS] Script Date: 29/04/2025 23:01:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE SPC_USUARIOS
    @Id INT = NULL,               -- Parâmetro para filtrar pelo id do usuário
    @Email VARCHAR(255) = NULL     -- Parâmetro para filtrar pelo email do usuário
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        cd_usuario, 
        email, 
        password, 
        telefone, 
        endereco, 
        nome, 
        sobrenome
    FROM usuarios
    WHERE (@Id IS NULL OR cd_usuario = @Id)  -- Filtra pelo id se fornecido
    AND (@Email IS NULL OR email = @Email); -- Filtra pelo email se fornecido
END;
