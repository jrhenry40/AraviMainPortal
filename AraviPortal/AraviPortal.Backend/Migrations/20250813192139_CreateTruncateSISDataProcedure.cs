using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateTruncateSISDataProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                CREATE PROCEDURE TruncateSISData
                    @TableName NVARCHAR(128)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    IF @TableName IS NULL OR @TableName = ''
                    BEGIN
                        RAISERROR('El nombre de la tabla no puede ser nulo o vacío.', 16, 1);
                        RETURN;
                    END

                    EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'

                    DECLARE @SQL NVARCHAR(MAX);
                    SET @SQL = N'TRUNCATE TABLE ' + QUOTENAME(@TableName);
                    EXEC sp_executesql @SQL;

                    EXEC sp_MSforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
                END
            ";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE TruncateSISData");
        }
    }
}