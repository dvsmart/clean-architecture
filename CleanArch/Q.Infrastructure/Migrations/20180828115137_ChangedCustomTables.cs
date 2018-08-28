using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class ChangedCustomTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomEntityInstances_CustomEntityDefinitions_CustomEntityId",
                table: "CustomEntityInstances");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "CustomEntityInstances");

            migrationBuilder.RenameColumn(
                name: "InstanceId",
                table: "CustomEntityInstances",
                newName: "DataId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomEntityId",
                table: "CustomEntityInstances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 28, 12, 51, 37, 749, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 28, 12, 51, 37, 750, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 28, 12, 51, 37, 750, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomEntityInstances_CustomEntityDefinitions_CustomEntityId",
                table: "CustomEntityInstances",
                column: "CustomEntityId",
                principalTable: "CustomEntityDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomEntityInstances_CustomEntityDefinitions_CustomEntityId",
                table: "CustomEntityInstances");

            migrationBuilder.RenameColumn(
                name: "DataId",
                table: "CustomEntityInstances",
                newName: "InstanceId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomEntityId",
                table: "CustomEntityInstances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "CustomEntityInstances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 23, 6, 42, 506, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 23, 6, 42, 506, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 23, 6, 42, 506, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomEntityInstances_CustomEntityDefinitions_CustomEntityId",
                table: "CustomEntityInstances",
                column: "CustomEntityId",
                principalTable: "CustomEntityDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
