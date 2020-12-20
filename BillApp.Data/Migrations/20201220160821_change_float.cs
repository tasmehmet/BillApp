using Microsoft.EntityFrameworkCore.Migrations;

namespace BillApp.Data.Migrations
{
    public partial class change_float : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "KdvRate",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "KdvRate",
                table: "Bills",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
