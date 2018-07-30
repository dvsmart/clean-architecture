using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class AddedRecurrenceData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RecurrenceTypes",
                columns: new[] { "Id", "AddedBy", "AddedDate", "DatePart", "IsActive", "IsArchived", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "RecurrenceNumber" },
                values: new object[] { 1, 1, new DateTime(2018, 7, 30, 14, 24, 18, 461, DateTimeKind.Local), "yy", true, false, false, null, null, "Annually", (short)1 });

            migrationBuilder.InsertData(
                table: "RecurrenceTypes",
                columns: new[] { "Id", "AddedBy", "AddedDate", "DatePart", "IsActive", "IsArchived", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "RecurrenceNumber" },
                values: new object[] { 2, 1, new DateTime(2018, 7, 30, 14, 24, 18, 462, DateTimeKind.Local), "MM", true, false, false, null, null, "Monthly", (short)1 });

            migrationBuilder.InsertData(
                table: "RecurrenceTypes",
                columns: new[] { "Id", "AddedBy", "AddedDate", "DatePart", "IsActive", "IsArchived", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "RecurrenceNumber" },
                values: new object[] { 3, 1, new DateTime(2018, 7, 30, 14, 24, 18, 462, DateTimeKind.Local), "dd", true, false, false, null, null, "Daily", (short)1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
