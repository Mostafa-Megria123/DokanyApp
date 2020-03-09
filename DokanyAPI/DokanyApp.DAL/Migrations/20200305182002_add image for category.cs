using Microsoft.EntityFrameworkCore.Migrations;

namespace DokanyApp.DAL.Migrations
{
    public partial class addimageforcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Category");
        }
    }
}
