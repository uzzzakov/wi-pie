using Microsoft.EntityFrameworkCore.Migrations;

namespace Khinkali.Migrations
{
    public partial class drinkvolumetypechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Volume",
                table: "drinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                table: "drinks",
                type: "decimal(18,1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
