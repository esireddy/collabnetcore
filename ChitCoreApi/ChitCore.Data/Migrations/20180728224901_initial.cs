using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChitCore.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    MInitial = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    UserTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    NoOfMonths = table.Column<int>(nullable: false),
                    NoOfUsers = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    ManagerId = table.Column<int>(nullable: true),
                    Commission = table.Column<int>(nullable: false),
                    AuctionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chits_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChitId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ActionedDate = table.Column<DateTime>(nullable: false),
                    BidAmount = table.Column<decimal>(nullable: false),
                    AmountDueBy = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionDetails_Chits_ChitId",
                        column: x => x.ChitId,
                        principalTable: "Chits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChitAdministrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ChitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitAdministrator", x => new { x.ChitId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ChitAdministrator_Chits_ChitId",
                        column: x => x.ChitId,
                        principalTable: "Chits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitAdministrator_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChitUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChitId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ChitUserTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitUsers", x => new { x.ChitId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ChitUsers_Chits_ChitId",
                        column: x => x.ChitId,
                        principalTable: "Chits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ChitId = table.Column<int>(nullable: false),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Chits_ChitId",
                        column: x => x.ChitId,
                        principalTable: "Chits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_ChitId",
                table: "AuctionDetails",
                column: "ChitId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_UserId",
                table: "AuctionDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitAdministrator_ChitId",
                table: "ChitAdministrator",
                column: "ChitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ChitAdministrator_Id",
                table: "ChitAdministrator",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChitAdministrator_UserId",
                table: "ChitAdministrator",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chits_ManagerId",
                table: "Chits",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "AK_ChitUsers_Id",
                table: "ChitUsers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChitUsers_UserId",
                table: "ChitUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_ChitId",
                table: "PaymentDetails",
                column: "ChitId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_UserId",
                table: "PaymentDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionDetails");

            migrationBuilder.DropTable(
                name: "ChitAdministrator");

            migrationBuilder.DropTable(
                name: "ChitUsers");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "Chits");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
