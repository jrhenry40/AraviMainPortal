using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraviPortal.Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSISUcsAmmsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "assetid_SISUcsAmms",
                table: "SISUcsAmms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "qtyawb_SISUcsAmms",
                table: "SISUcsAmms",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "assetid_SISUcsAmms",
                table: "SISUcsAmms");

            migrationBuilder.DropColumn(
                name: "qtyawb_SISUcsAmms",
                table: "SISUcsAmms");
        }
    }
}
