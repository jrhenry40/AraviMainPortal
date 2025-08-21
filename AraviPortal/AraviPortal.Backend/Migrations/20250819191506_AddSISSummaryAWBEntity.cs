using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSISSummaryAWBEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SISSummaryAWB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_SISSummaryAWB = table.Column<int>(type: "int", nullable: true),
                    po_SISSummaryAWB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pr_SISSummaryAWB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    partnumber_SISSummaryAWB = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    description_SISSummaryAWB = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    prioridad_SISSummaryAWB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    altern_SISSummaryAWB = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    nsn_SISSummaryAWB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sn_SISSummaryAWB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cnd_SISSummaryAWB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    qty_SISSummaryAWB = table.Column<int>(type: "int", nullable: true),
                    unit_SISSummaryAWB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    sap_SISSummaryAWB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ubic_SISSummaryAWB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    unitprice_SISSummaryAWB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    unitcop_SISSummaryAWB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    subtotalusd_SISSummaryAWB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    totalcop_SISSummaryAWB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    remarks_SISSummaryAWB = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    oh_SISSummaryAWB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    requestedby_SISSummaryAWB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    awb_SISSummaryAWB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    datereceived_SISSummaryAWB = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISSummaryAWB", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SISSummaryAWB");
        }
    }
}
