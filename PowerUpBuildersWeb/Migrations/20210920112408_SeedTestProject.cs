using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerUpBuildersWeb.Migrations
{
    public partial class SeedTestProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLocalFile_Tasks_TaskId",
                table: "TaskLocalFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLocalFile",
                table: "TaskLocalFile");

            migrationBuilder.RenameTable(
                name: "TaskLocalFile",
                newName: "TaskLocalFiles");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLocalFile_TaskId",
                table: "TaskLocalFiles",
                newName: "IX_TaskLocalFiles_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLocalFiles",
                table: "TaskLocalFiles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "TestProj" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Test2" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLocalFiles_Tasks_TaskId",
                table: "TaskLocalFiles",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLocalFiles_Tasks_TaskId",
                table: "TaskLocalFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLocalFiles",
                table: "TaskLocalFiles");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "TaskLocalFiles",
                newName: "TaskLocalFile");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLocalFiles_TaskId",
                table: "TaskLocalFile",
                newName: "IX_TaskLocalFile_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLocalFile",
                table: "TaskLocalFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLocalFile_Tasks_TaskId",
                table: "TaskLocalFile",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
