using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class ChangedTabTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomEntityDefinitions_CustomEntityGroups_CustomEntityGroupId",
                table: "CustomEntityDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_CustomEntityDefinitions_CustomEntityGroupId",
                table: "CustomEntityDefinitions");

            migrationBuilder.DropColumn(
                name: "CustomEntityGroupId",
                table: "CustomEntityDefinitions");

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 24, 16, 10, 50, 687, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 24, 16, 10, 50, 688, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 24, 16, 10, 50, 688, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CustomEntityDefinitions_EntityGroupId",
                table: "CustomEntityDefinitions",
                column: "EntityGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomEntityDefinitions_CustomEntityGroups_EntityGroupId",
                table: "CustomEntityDefinitions",
                column: "EntityGroupId",
                principalTable: "CustomEntityGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomEntityDefinitions_CustomEntityGroups_EntityGroupId",
                table: "CustomEntityDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_CustomEntityDefinitions_EntityGroupId",
                table: "CustomEntityDefinitions");

            migrationBuilder.AddColumn<int>(
                name: "CustomEntityGroupId",
                table: "CustomEntityDefinitions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 21, 16, 9, 3, 372, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 21, 16, 9, 3, 372, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 21, 16, 9, 3, 372, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CustomEntityDefinitions_CustomEntityGroupId",
                table: "CustomEntityDefinitions",
                column: "CustomEntityGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomEntityDefinitions_CustomEntityGroups_CustomEntityGroupId",
                table: "CustomEntityDefinitions",
                column: "CustomEntityGroupId",
                principalTable: "CustomEntityGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
