using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DokanyApp.DAL.Migrations
{
    public partial class UpdateCreationDateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                table: "Product",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);
        }
    }
}
