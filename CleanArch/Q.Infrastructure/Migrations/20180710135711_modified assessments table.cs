using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class modifiedassessmentstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                table: "Assessments");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentScopeId",
                table: "Assessments",
                nullable: true  ,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                table: "Assessments",
                column: "AssessmentScopeId",
                principalTable: "AssessmentScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                table: "Assessments");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentScopeId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                table: "Assessments",
                column: "AssessmentScopeId",
                principalTable: "AssessmentScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
