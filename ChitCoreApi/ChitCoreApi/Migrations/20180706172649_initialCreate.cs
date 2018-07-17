using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChitCoreApi.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    NoOfMonths = table.Column<int>(nullable: false),
                    NoOfUsers = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    AuctionDate = table.Column<DateTime>(nullable: true),
                    Commission = table.Column<int>(nullable: false, defaultValue: 0),
                    ManagerId = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chits", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "Users",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Email = table.Column<string>(nullable: false),
                   Firstname = table.Column<string>(nullable: false),
                   Lastname = table.Column<string>(nullable: false),
                   MInitial = table.Column<string>(nullable: true),
                   PhoneNumber = table.Column<string>(nullable: false),
                   Address = table.Column<string>(nullable: false),
                   CreateDate = table.Column<DateTime>(nullable: false),
                   LastUpdatedDate = table.Column<DateTime>(nullable: false),
                   StatusId = table.Column<int>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Users", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "ChitUsers",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   ChitId = table.Column<int>(nullable: false),
                   UserId = table.Column<int>(nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ChitUsers", x => x.Id);
                   table.ForeignKey("FK_ChitUsers_Chits_ChitId", x => x.ChitId, "Chits", "Id");
                   table.ForeignKey("FK_ChitUsers_Users_UserId", x => x.UserId, "Users", "Id");
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chits");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ChitUsers");
        }
    }
}
