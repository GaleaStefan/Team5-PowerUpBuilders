using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerUpBuildersWeb.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeesTasks",
                columns: new[] { "EmployeeId", "TaskId", "ActualHours", "EstimatedHours", "Id" },
                values: new object[] { 1, 1, 10, 8, 1 });

            migrationBuilder.InsertData(
                table: "EmployeesTasks",
                columns: new[] { "EmployeeId", "TaskId", "ActualHours", "EstimatedHours", "Id" },
                values: new object[] { 2, 1, 10, 8, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeesTasks",
                keyColumns: new[] { "EmployeeId", "TaskId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeesTasks",
                keyColumns: new[] { "EmployeeId", "TaskId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
