using Microsoft.EntityFrameworkCore.Migrations;

namespace BillApp.Data.Migrations
{
    public partial class add_bills_new6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_UserIdId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_UserIdId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Bills");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Bills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IdentityUserId",
                table: "Bills",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_IdentityUserId",
                table: "Bills",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_IdentityUserId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_IdentityUserId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Bills");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Bills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserIdId",
                table: "Bills",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_UserIdId",
                table: "Bills",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
