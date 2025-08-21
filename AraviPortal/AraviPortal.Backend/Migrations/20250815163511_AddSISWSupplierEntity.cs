using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSISWSupplierEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SISWSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orgid_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    siteid_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    source_SISWSupplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    requestedby_SISWSupplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    priority_SISWSupplier = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    projectid_SISWSupplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cpacct_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    requesttype_SISWSupplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    potype_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    markfor_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    aog_SISWSupplier = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    rod_SISWSupplier = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ponumber_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    polinenumber_SISWSupplier = table.Column<int>(type: "int", nullable: true),
                    vendorid_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vendorname_SISWSupplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    niin_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dodn_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    partnumber_SISWSupplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    serialnumber_SISWSupplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description_SISWSupplier = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rvsc_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bostatus_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pricetype_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    polinestatus_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    orddate_SISWSupplier = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ordqty_SISWSupplier = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    dueqty_SISWSupplier = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    pouom_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    niinuom_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rdd_SISWSupplier = table.Column<DateTime>(type: "datetime2", nullable: true),
                    edd_SISWSupplier = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dayslate_SISWSupplier = table.Column<int>(type: "int", nullable: true),
                    estimatedunitprice_SISWSupplier = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    percent_SISWSupplier = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    estimatedtotalpricedue_SISWSupplier = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    supplierawb_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    suppliershippeddate_SISWSupplier = table.Column<DateTime>(type: "datetime2", nullable: true),
                    siteawb_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    siteshippeddate_SISWSupplier = table.Column<DateTime>(type: "datetime2", nullable: true),
                    shippingno_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    jcn_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maintcontrolno_SISWSupplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    buyer_SISWSupplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    notes_SISWSupplier = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    backlog_SISWSupplier = table.Column<int>(type: "int", nullable: true),
                    ttdays_SISWSupplier = table.Column<int>(type: "int", nullable: true),
                    tthours_SISWSupplier = table.Column<int>(type: "int", nullable: true),
                    expeditornotes_SISWSupplier = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISWSupplier", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SISWSupplier");
        }
    }
}
