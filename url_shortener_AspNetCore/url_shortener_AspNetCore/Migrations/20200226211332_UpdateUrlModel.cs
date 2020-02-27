using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace url_shortener_AspNetCore.Migrations
{
    public partial class UpdateUrlModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrignalUrl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrignalUrl");
        }
    }
}
