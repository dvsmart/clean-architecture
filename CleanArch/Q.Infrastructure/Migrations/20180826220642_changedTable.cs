using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class changedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "CustomFieldTypes");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "CustomFieldTypes");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "CustomFieldTypes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "CustomFieldTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomFieldTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CustomFieldTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CustomFieldTypes");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "text");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "date");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "time");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "textarea");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "currency");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: "checkbox");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: "select");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: "numerical");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Type",
                value: "percent");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Type",
                value: "image");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Type",
                value: "phone");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Type",
                value: "email");

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Type",
                value: "richtextarea");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "CustomFieldTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "CustomFieldTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "CustomFieldTypes",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "CustomFieldTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CustomFieldTypes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 500, DateTimeKind.Local), "TextBox", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Calender", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Time", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "TextArea", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Currency", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Checkbox", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Picklist", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Numerical", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Percent", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Image", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Phone", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "Email", null });

            migrationBuilder.UpdateData(
                table: "CustomFieldTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AddedDate", "Caption", "Type" },
                values: new object[] { new DateTime(2018, 8, 26, 10, 14, 5, 502, DateTimeKind.Local), "RichTextEditor", null });

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
        }
    }
}
