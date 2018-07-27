using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class addedFewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AssessmentTypes_AssessmentTypeId",
                table: "Assessments");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "UserTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "UserRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "UserProfile",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserProfile",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "TaskStatuses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TaskStatuses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CompletedBy",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceTypeId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "TaskPriorities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TaskPriorities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "MenuItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "MenuGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "CustomTabs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "CustomFieldValues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomFieldValues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "CustomFieldTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomFieldTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "CustomFields",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomEntityInstances",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "CustomEntityGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomEntityGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "CustomEntityDefinitions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomEntityDefinitions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AssetTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssetTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "DataId",
                table: "AssetProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldComputedColumnSql: "ARId");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AssetProperties",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssetProperties",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AssessmentTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssessmentTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AssessmentStatuses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssessmentStatuses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AssessmentScopes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssessmentScopes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "DataId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldComputedColumnSql: "AMId");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentTypeId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentScopeId",
                table: "Assessments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "AssessmentDate",
                table: "Assessments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssessorUserId",
                table: "Assessments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "Assessments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperseded",
                table: "Assessments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceTypeId",
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

            migrationBuilder.CreateTable(
                name: "RecurrenceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RecurrenceNumber = table.Column<short>(nullable: false),
                    DatePart = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurrenceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskComments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RecurrenceTypeId",
                table: "Tasks",
                column: "RecurrenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_RecurrenceTypeId",
                table: "Assessments",
                column: "RecurrenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskId",
                table: "TaskComments",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                table: "Assessments",
                column: "AssessmentScopeId",
                principalTable: "AssessmentScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AssessmentTypes_AssessmentTypeId",
                table: "Assessments",
                column: "AssessmentTypeId",
                principalTable: "AssessmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_RecurrenceTypes_RecurrenceTypeId",
                table: "Assessments",
                column: "RecurrenceTypeId",
                principalTable: "RecurrenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RecurrenceTypes_RecurrenceTypeId",
                table: "Tasks",
                column: "RecurrenceTypeId",
                principalTable: "RecurrenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AssessmentTypes_AssessmentTypeId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_RecurrenceTypes_RecurrenceTypeId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RecurrenceTypes_RecurrenceTypeId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "RecurrenceTypes");

            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RecurrenceTypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_RecurrenceTypeId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "CompletedBy",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RecurrenceTypeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "TaskPriorities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TaskPriorities");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "MenuGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuGroups");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "CustomTabs");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "CustomFieldValues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomFieldValues");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "CustomFieldTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomFieldTypes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomEntityInstances");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "CustomEntityGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomEntityGroups");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "CustomEntityDefinitions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomEntityDefinitions");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssetTypes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AssetProperties");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssetProperties");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AssessmentTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssessmentTypes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AssessmentStatuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssessmentStatuses");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AssessmentScopes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssessmentScopes");

            migrationBuilder.DropColumn(
                name: "AssessmentDate",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "AssessorUserId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "IsSuperseded",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "RecurrenceTypeId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "ScopeId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Assessments");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentTypeId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentScopeId",
                table: "Assessments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataId",
                table: "AssetProperties",
                nullable: true,
                computedColumnSql: "ARId",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataId",
                table: "Assessments",
                nullable: true,
                computedColumnSql: "AMId",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                table: "Assessments",
                column: "AssessmentScopeId",
                principalTable: "AssessmentScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AssessmentTypes_AssessmentTypeId",
                table: "Assessments",
                column: "AssessmentTypeId",
                principalTable: "AssessmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
