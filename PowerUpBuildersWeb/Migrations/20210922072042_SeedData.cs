using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerUpBuildersWeb.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Pop Constantin");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Popescu Ion" },
                    { 3, "Aurel Vlad" },
                    { 4, "Popescu Ana" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Project num 3" },
                    { 4, "Proj4" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "ProjectId", "Status", "TaskNumber", "Title" },
                values: new object[,]
                {
                    { 2, "Do this", 1, 1, "TK202109091100_01", "Task2" },
                    { 3, "Do that", 1, 2, "TK202109091100_02", "Task3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Stefan");
        }
    }
}
