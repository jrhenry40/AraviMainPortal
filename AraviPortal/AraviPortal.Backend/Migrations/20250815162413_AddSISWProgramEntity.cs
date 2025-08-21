using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSISWProgramEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SISWProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orgid_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    siteid_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    source_SISWProgram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    partnumber_SISWProgram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description_SISWProgram = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    requestedby_SISWProgram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    category_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ponumber_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dodn_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    jcn_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maintcontrolno_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ordQty_SISWProgram = table.Column<int>(type: "int", nullable: true),
                    estunitprice_SISWProgram = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    percent_SISWProgram = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    lineprice_SISWProgram = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    aog_SISWProgram = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    priority_SISWProgram = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    markfor_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    shippingno_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    projectid_SISWProgram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cpacct_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bostatus_SISWProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    daysaging_SISWProgram = table.Column<int>(type: "int", nullable: true),
                    rejecteddate_SISWProgram = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rejectnotes_SISWProgram = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISWProgram", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SISWProgram");
        }
    }
}
