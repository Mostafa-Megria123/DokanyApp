using Microsoft.EntityFrameworkCore.Migrations;

namespace DokanyApp.Migrations
{
    public partial class UpdateFieldFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Trader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "CustomerService",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Trader");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "CustomerService");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Customer");
        }
    }
}
