using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class addEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RecurrenceTypes_RecurrenceTypeId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "RecurrenceTypeId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    RecurrenceTypeId = table.Column<int>(nullable: true),
                    AllDayEvent = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_RecurrenceTypes_RecurrenceTypeId",
                        column: x => x.RecurrenceTypeId,
                        principalTable: "RecurrenceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2018, 8, 13, 14, 44, 40, 283, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2018, 8, 13, 14, 44, 40, 283, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "RecurrenceTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2018, 8, 13, 14, 44, 40, 283, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_Events_RecurrenceTypeId",
                table: "Events",
                column: "RecurrenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RecurrenceTypes_RecurrenceTypeId",
                table: "Tasks",
                column: "RecurrenceTypeId",
                principalTable: "RecurrenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RecurrenceTypes_RecurrenceTypeId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "RecurrenceTypeId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RecurrenceTypes_RecurrenceTypeId",
                table: "Tasks",
                column: "RecurrenceTypeId",
                principalTable: "RecurrenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
