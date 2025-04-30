USE [FullDev]
GO

/****** Object: SqlProcedure [dbo].[SPA_ESQUECI_A_SENHA] Script Date: 29/04/2025 22:59:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- Se quiser, você pode fazer DROP antes se já existir
-- DROP PROCEDURE IF EXISTS SPA_ESQUECI_A_SENHA;

CREATE PROCEDURE SPA_ESQUECI_A_SENHA
    @EMAIL VARCHAR(255),
    @NOVA_PASSWORD VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    -- Atualiza a senha do usuário pelo email
    UPDATE USUARIOS
    SET PASSWORD = @NOVA_PASSWORD
    WHERE EMAIL = @EMAIL;

    -- Retorna o resultado
    IF @@ROWCOUNT > 0
    BEGIN
        SELECT 'Senha atualizada com sucesso!' AS Mensagem;
    END
    ELSE
    BEGIN
        SELECT 'Usuário não encontrado!' AS Mensagem;
    END
END;
