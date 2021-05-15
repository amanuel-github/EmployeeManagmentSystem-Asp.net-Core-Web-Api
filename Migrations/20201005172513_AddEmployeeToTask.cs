using Microsoft.EntityFrameworkCore.Migrations;

namespace Ezana.ShiftManagment.API.Migrations
{
    public partial class AddEmployeeToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Task");

            migrationBuilder.AddColumn<int>(
                name: "AppTaskStatusId",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Task",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppTaskStatusId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Task",
                type: "text",
                nullable: true);
        }
    }
}
