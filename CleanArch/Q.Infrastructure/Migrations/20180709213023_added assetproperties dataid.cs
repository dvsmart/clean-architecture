using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class addedassetpropertiesdataid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataId",
                table: "AssetProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataId",
                table: "AssetProperties");
        }
    }
}
