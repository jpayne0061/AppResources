using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppResourcesWatcher.Migrations
{
    public partial class addDateTimeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeUTC",
                table: "MemorySnapshots",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeUTC",
                table: "MemorySnapshots");
        }
    }
}
