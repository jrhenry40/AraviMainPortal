using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUcsAmmsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SISUcsAmms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requisition_SISUcsAmms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    type_SISUcsAmms = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    priority_SISUcsAmms = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    partnumber_SISUcsAmms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description_SISUcsAmms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    alternatepn_SISUcsAmms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sn_SISUcsAmms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    requestedby_SISUcsAmms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    requireddate_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    purchaseunit_SISUcsAmms = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    pureqqty_SISUcsAmms = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    logremarks_SISUcsAmms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    requisitiondate_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    repremarks_SISUcsAmms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appremarks_SISUcsAmms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    site_SISUcsAmms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    partinvcost_SISUcsAmms = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    extendcost_SISUcsAmms = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    orderstatus_SISUcsAmms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    purchasecondition_SISUcsAmms = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    enduse_SISUcsAmms = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    name_SISUcsAmms = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    vendorname_SISUcsAmms = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    vendorcode_SISUcsAmms = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    company_SISUcsAmms = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    createdinmro_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    datesentapp_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    datercvdapp_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ponumber_SISUcsAmms = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    podate_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    edd_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    awb_SISUcsAmms = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    dateexptovendor_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    receiveddateff_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estdatedeparturet4_SISUcsAmms = table.Column<DateTime>(type: "datetime2", nullable: true),
                    buyer_SISUcsAmms = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    lasteditedby_SISUcsAmms = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    budgete_SISUcsAmms = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    earecinffinbound_SISUcsAmms = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISUcsAmms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SISUcsAmms");
        }
    }
}
