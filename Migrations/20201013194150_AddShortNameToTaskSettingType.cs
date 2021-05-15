using Microsoft.EntityFrameworkCore.Migrations;

namespace Ezana.ShiftManagment.API.Migrations
{
    public partial class AddShortNameToTaskSettingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "TaskSettingTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "TaskSettingTypes");
        }
    }
}
