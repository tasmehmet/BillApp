﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BillApp.Data.Migrations
{
    public partial class add_bills_new4 : Migration
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
                name: "UserId",
                table: "Bills",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
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
