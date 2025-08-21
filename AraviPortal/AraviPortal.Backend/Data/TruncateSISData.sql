CREATE PROCEDURE TruncateSISData
    @TableName NVARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar el nombre de la tabla
    IF @TableName IS NULL OR @TableName = ''
    BEGIN
        RAISERROR('El nombre de la tabla no puede ser nulo o vacío.', 16, 1);
        RETURN;
    END

    -- Desactivar temporalmente las restricciones de clave externa para permitir TRUNCATE
    EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'

    -- Construir el comando SQL de forma segura para evitar SQL Injection
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = N'TRUNCATE TABLE ' + QUOTENAME(@TableName);

    -- Ejecutar el TRUNCATE en la tabla específica
    EXEC sp_executesql @SQL;

    -- Reactivar las restricciones de clave externa
    EXEC sp_MSforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
END
GO