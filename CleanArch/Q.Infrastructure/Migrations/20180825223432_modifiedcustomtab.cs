using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class modifiedcustomtab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomTabs_CustomEntityDefinitions_CustomEntityId",
                table: "CustomTabs");

            migrationBuilder.AlterColumn<int>(
                name: "CustomEntityId",
                table: "CustomTabs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CustomFieldTypes",
                columns: new[] { "Id", "AddedBy", "AddedDate", "Caption", "IsArchived", "IsDeleted", "ModifiedBy", "ModifiedDate", "Type" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2018, 8, 25, 23, 34, 31, 664, DateTimeKind.Local), "TextBox", false, false, null, null, null },
                    { 2, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Calender", false, false, null, null, null },
                    { 3, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Time", false, false, null, null, null },
                    { 4, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "TextArea", false, false, null, null, null },
                    { 5, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Currency", false, false, null, null, null },
                    { 6, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Checkbox", false, false, null, null, null },
                    { 7, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Picklist", false, false, null, null, null },
                    { 8, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Numerical", false, false, null, null, null },
                    { 9, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Percent", false, false, null, null, null },
                    { 10, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Image", false, false, null, null, null },
                    { 11, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Phone", false, false, null, null, null },
                    { 12, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "Email", false, false, null, null, null },
                    { 13, 0, new DateTime(2018, 8, 25, 23, 34, 31, 673, DateTimeKind.Local), "RichTextEditor", false, false, null, null, null }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTabs_CustomEntityDefinitions_CustomEntityId",
                table: "CustomTabs",
                column: "CustomEntityId",
                principalTable: "CustomEntityDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomTabs_CustomEntityDefinitions_CustomEntityId",
                table: "CustomTabs");

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.AlterColumn<int>(
                name: "CustomEntityId",
                table: "CustomTabs",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTabs_CustomEntityDefinitions_CustomEntityId",
                table: "CustomTabs",
                column: "CustomEntityId",
                principalTable: "CustomEntityDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
