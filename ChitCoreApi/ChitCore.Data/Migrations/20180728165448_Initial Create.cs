using Microsoft.EntityFrameworkCore.Migrations;

namespace ChitCore.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ChitUsers_Id",
                table: "ChitUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ChitAdministrator_Id",
                table: "ChitAdministrator");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_ChitId",
                table: "PaymentDetails",
                column: "ChitId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_UserId",
                table: "PaymentDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "AK_ChitUsers_Id",
                table: "ChitUsers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chits_ManagerId",
                table: "Chits",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "AK_ChitAdministrator_Id",
                table: "ChitAdministrator",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_ChitId",
                table: "AuctionDetails",
                column: "ChitId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_UserId",
                table: "AuctionDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_Chits_ChitId",
                table: "AuctionDetails",
                column: "ChitId",
                principalTable: "Chits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDetails_Users_UserId",
                table: "AuctionDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chits_Users_ManagerId",
                table: "Chits",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Chits_ChitId",
                table: "PaymentDetails",
                column: "ChitId",
                principalTable: "Chits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Users_UserId",
                table: "PaymentDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_Chits_ChitId",
                table: "AuctionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDetails_Users_UserId",
                table: "AuctionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Chits_Users_ManagerId",
                table: "Chits");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Chits_ChitId",
                table: "PaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Users_UserId",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_ChitId",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_UserId",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "AK_ChitUsers_Id",
                table: "ChitUsers");

            migrationBuilder.DropIndex(
                name: "IX_Chits_ManagerId",
                table: "Chits");

            migrationBuilder.DropIndex(
                name: "AK_ChitAdministrator_Id",
                table: "ChitAdministrator");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDetails_ChitId",
                table: "AuctionDetails");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDetails_UserId",
                table: "AuctionDetails");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ChitUsers_Id",
                table: "ChitUsers",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ChitAdministrator_Id",
                table: "ChitAdministrator",
                column: "Id");
        }
    }
}
