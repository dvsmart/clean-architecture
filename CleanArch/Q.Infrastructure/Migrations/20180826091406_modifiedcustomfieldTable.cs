using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class modifiedcustomfieldTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CustomFieldTypes_CustomFieldTypeId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomFieldTypeId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomFieldTypeId",
                table: "CustomFields");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 500, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 504, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 505, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 26, 10, 14, 5, 505, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_FieldTypeId",
                table: "CustomFields",
                column: "FieldTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CustomFieldTypes_FieldTypeId",
                table: "CustomFields",
                column: "FieldTypeId",
                principalTable: "CustomFieldTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CustomFieldTypes_FieldTypeId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_FieldTypeId",
                table: "CustomFields");

            migrationBuilder.AddColumn<int>(
                name: "CustomFieldTypeId",
                table: "CustomFields",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 664, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 676, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 676, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 25, 23, 34, 31, 676, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomFieldTypeId",
                table: "CustomFields",
                column: "CustomFieldTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CustomFieldTypes_CustomFieldTypeId",
                table: "CustomFields",
                column: "CustomFieldTypeId",
                principalTable: "CustomFieldTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
