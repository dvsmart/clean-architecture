using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class addedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 9, 21, 17, 15, 47, 966, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 9, 21, 17, 15, 47, 966, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 9, 21, 17, 15, 47, 966, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "AddedBy", "AddedDate", "IsArchived", "IsDeleted", "ModifiedBy", "ModifiedDate", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 9, 21, 16, 15, 47, 966, DateTimeKind.Utc), false, false, null, null, "Admin" },
                    { 2, 1, new DateTime(2018, 9, 21, 16, 15, 47, 966, DateTimeKind.Utc), false, false, null, null, "user" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "AddedBy", "AddedDate", "IsArchived", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 9, 21, 16, 15, 47, 966, DateTimeKind.Utc), false, false, null, null, "Visitor" },
                    { 2, 1, new DateTime(2018, 9, 21, 16, 15, 47, 966, DateTimeKind.Utc), false, false, null, null, "Reporter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2);

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
        }
    }
}
