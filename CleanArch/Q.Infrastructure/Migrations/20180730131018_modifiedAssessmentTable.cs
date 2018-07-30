using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class modifiedAssessmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "ScopeId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Assessments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "Assessments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScopeId",
                table: "Assessments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Assessments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
