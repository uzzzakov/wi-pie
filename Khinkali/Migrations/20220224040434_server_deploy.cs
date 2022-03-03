using Microsoft.EntityFrameworkCore.Migrations;

namespace Khinkali.Migrations
{
    public partial class server_deploy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "orders",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "OrderDetails",
                table: "orders",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "orders",
                newName: "Date");

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "orders",
                newName: "PhoneNo");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "orders",
                newName: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "orders",
                newName: "OrderDate");

            migrationBuilder.AddColumn<string>(
                name: "OrderNo",
                table: "orders",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
