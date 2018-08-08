using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class menutablechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconName",
                table: "MenuItems",
                newName: "Translate");

            migrationBuilder.RenameColumn(
                name: "ClassName",
                table: "MenuItems",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "MenuItems",
                newName: "Icon");

            migrationBuilder.AddColumn<string>(
                name: "Classess",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ExactMatch",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalUrl",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OpenInNewTab",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 8, 11, 34, 0, 42, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 8, 11, 34, 0, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 8, 11, 34, 0, 43, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classess",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ExactMatch",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ExternalUrl",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "OpenInNewTab",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "Translate",
                table: "MenuItems",
                newName: "IconName");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "MenuItems",
                newName: "ClassName");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "MenuItems",
                newName: "Caption");

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 7, 30, 14, 24, 18, 461, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 7, 30, 14, 24, 18, 462, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 7, 30, 14, 24, 18, 462, DateTimeKind.Local));
        }
    }
}
