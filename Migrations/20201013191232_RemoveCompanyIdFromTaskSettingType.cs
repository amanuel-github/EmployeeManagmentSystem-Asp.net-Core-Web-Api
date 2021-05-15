using Microsoft.EntityFrameworkCore.Migrations;

namespace Ezana.ShiftManagment.API.Migrations
{
    public partial class RemoveCompanyIdFromTaskSettingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "TaskSettingTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "TaskSettingTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
