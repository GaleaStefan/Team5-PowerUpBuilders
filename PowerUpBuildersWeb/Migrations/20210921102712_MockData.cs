using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerUpBuildersWeb.Migrations
{
    public partial class MockData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "TaskLocalFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Stefan" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "ProjectId", "Status", "TaskNumber" },
                values: new object[] { 1, 1, 0, "TK20190101_01" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "TaskLocalFiles");
        }
    }
}
