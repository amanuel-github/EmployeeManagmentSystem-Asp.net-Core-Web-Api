using Microsoft.EntityFrameworkCore.Migrations;

namespace Ezana.ShiftManagment.API.Migrations
{
    public partial class RemoveTextCategoryInTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Catagory",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Catagory",
                table: "Task",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Task",
                type: "text",
                nullable: true);
        }
    }
}
