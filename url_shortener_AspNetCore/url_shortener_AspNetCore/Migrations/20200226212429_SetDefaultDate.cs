using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace url_shortener_AspNetCore.Migrations
{
    public partial class SetDefaultDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrignalUrl",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrignalUrl",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");
        }
    }
}
