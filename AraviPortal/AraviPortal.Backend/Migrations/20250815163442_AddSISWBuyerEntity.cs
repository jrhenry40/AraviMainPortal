using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSISWBuyerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SISWBuyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orgid_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    siteid_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    source_SISWBuyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    buyer_SISWBuyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    daysapproved_SISWBuyer = table.Column<int>(type: "int", nullable: true),
                    requestedby_SISWBuyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    priority_SISWBuyer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    projectid_SISWBuyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cpacct_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    requesttype_SISWBuyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    potype_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    markfor_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    aog_SISWBuyer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ponumber_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    polinenumber_SISWBuyer = table.Column<int>(type: "int", nullable: true),
                    vendorid_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vendorname_SISWBuyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    niin_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dodn_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    partnumber_SISWBuyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    serialnumber_SISWBuyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description_SISWBuyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rvsc_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bostatus_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quoteduedateutc_SISWBuyer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pricetype_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    approveddate_SISWBuyer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    polinestatus_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    orddate_SISWBuyer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ordqty_SISWBuyer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    dueqty_SISWBuyer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    pouom_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    niinuom_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rdd_SISWBuyer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    edd_SISWBuyer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estimatedunitprice_SISWBuyer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    percent_SISWBuyer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    estimatedtotalpricedue_SISWBuyer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    siteawb_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    siteshippeddate_SISWBuyer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    shippingno_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    jcn_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maintcontrolno_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    reqgroupno_SISWBuyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    notes_SISWBuyer = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    obligated_SISWBuyer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISWBuyer", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SISWBuyer");
        }
    }
}
