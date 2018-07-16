using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChitCoreApi.Migrations
{
    public partial class modifychit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AuctionDate",
                table: "Chits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Commission",
                table: "Chits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Chits",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuctionDate",
                table: "Chits");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "Chits");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Chits");
        }
    }
}
