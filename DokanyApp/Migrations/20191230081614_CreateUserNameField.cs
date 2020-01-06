using Microsoft.EntityFrameworkCore.Migrations;

namespace DokanyApp.Migrations
{
    public partial class CreateUserNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Trader",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Customer",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Trader",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customer",
                newName: "FullName");
        }
    }
}
