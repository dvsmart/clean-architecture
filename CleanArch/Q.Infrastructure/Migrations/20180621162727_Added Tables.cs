using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Tasks",
                newName: "PriorityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "Tasks",
                newName: "Priority");
        }
    }
}
