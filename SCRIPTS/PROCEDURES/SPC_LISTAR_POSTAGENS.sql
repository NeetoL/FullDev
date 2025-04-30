USE [FullDev]
GO

/****** Object: SqlProcedure [dbo].[SPC_LISTAR_POSTAGENS] Script Date: 29/04/2025 23:01:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SPC_LISTAR_POSTAGENS
    @CdUsuario INT = NULL,      -- Filtra postagens de um usuário específico (opcional)
    @Status VARCHAR(20) = NULL   -- Filtra postagens com o status específico (opcional)
AS
BEGIN
    SET NOCOUNT ON;

    -- Seleciona as postagens de acordo com os filtros fornecidos
    SELECT 
        p.cd_postagem, 
        p.titulo, 
        p.postagem, 
        p.cd_usuario, 
        p.imagem, 
        p.dh_timestamp, 
        p.status, 
        p.updated_at,
        u.nome AS nome_usuario      -- Nome do usuário relacionado à postagem
    FROM 
        Postagens p
    INNER JOIN 
        Usuarios u ON p.cd_usuario = u.cd_usuario
    WHERE 
        (@CdUsuario IS NULL OR p.cd_usuario = @CdUsuario)  -- Se CdUsuario for nulo, não filtra
        AND (@Status IS NULL OR p.status = @Status)         -- Se Status for nulo, não filtra
    ORDER BY 
        p.dh_timestamp DESC; -- Ordena as postagens pela data de criação (mais recentes primeiro)
END;
