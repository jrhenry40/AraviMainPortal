using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSISShippingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SISShipping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    headerid_SISShipping = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    lineid_SISShipping = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    siteid_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    documentnumber_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    issuedocno_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    jobcontrolno_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fkassetlcf_SISShipping = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fkpartslcf_SISShipping = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    serialnumber_SISShipping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    warehousereceipt_SISShipping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ownerid_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mfgrpn_SISShipping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    nsn_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description_SISShipping = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mfgrcode_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    unitofissue_SISShipping = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    awbtrackingno_SISShipping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    mawb_SISShipping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    donumber_SISShipping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    shippeddatetime_SISShipping = table.Column<DateTime>(type: "datetime2", nullable: true),
                    priority_SISShipping = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    linestatus_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    shippedqty_SISShipping = table.Column<int>(type: "int", nullable: true),
                    tagnumber_SISShipping = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    shippedunits_SISShipping = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    claimno_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    type_SISShipping = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    shiptositeid_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trackurlfmt_SISShipping = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    countryofmanu_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    itar_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    harmonized_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    usmleccn_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    impharmonized_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    itarlicense_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sealnum_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    containernum_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    applicationcode_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bookingno_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tmstatus_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    backorderid_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    loadnumber_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tracingno_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    partmodel_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    localstockno_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    shippingprogress_SISShipping = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISShipping", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SISShipping");
        }
    }
}
