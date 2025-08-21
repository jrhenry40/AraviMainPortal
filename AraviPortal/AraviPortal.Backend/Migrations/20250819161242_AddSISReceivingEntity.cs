using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSISReceivingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SISReceiving",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendorid_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    receiptno_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    receipttype_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    mfgrpn_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    nsn_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description_SISReceiving = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    unitofissue_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    documentnumber_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    issuedocno_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    jobcontrolno_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    markfor_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    serialnumber_SISReceiving = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    receiptqty_SISReceiving = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    invoiceno_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    reclinedate_SISReceiving = table.Column<DateTime>(type: "datetime2", nullable: true),
                    processdate_SISReceiving = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cancelled_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_SISReceiving = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fkrepairlines_SISReceiving = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fkdolines_SISReceiving = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    notes_SISReceiving = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    warehouselocation_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fkpolines_SISReceiving = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    awbtrackno_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    assetid_SISReceiving = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tagnumber_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    siteid_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ponumber_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    polinekey_SISReceiving = table.Column<int>(type: "int", nullable: true),
                    applicationcode_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    receiptunits_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    shippedvia_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    partmodel_SISReceiving = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    location_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    localstockno_SISReceiving = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    vendorname_SISReceiving = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISReceiving", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SISReceiving");
        }
    }
}
