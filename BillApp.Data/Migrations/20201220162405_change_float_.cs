using Microsoft.EntityFrameworkCore.Migrations;

namespace BillApp.Data.Migrations
{
    public partial class change_float_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "KdvRate",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "KdvRate",
                table: "Bills",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
