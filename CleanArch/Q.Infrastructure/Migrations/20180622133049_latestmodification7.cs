using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class latestmodification7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuGroups_Users_UserId",
                table: "MenuGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_UserId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPriorities_Users_UserId",
                table: "TaskPriorities");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatuses_Users_UserId",
                table: "TaskStatuses");

            migrationBuilder.DropIndex(
                name: "IX_TaskStatuses_UserId",
                table: "TaskStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskPriorities_UserId",
                table: "TaskPriorities");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_UserId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuGroups_UserId",
                table: "MenuGroups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskPriorities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MenuGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TaskStatuses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TaskPriorities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MenuGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatuses_UserId",
                table: "TaskStatuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskPriorities_UserId",
                table: "TaskPriorities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_UserId",
                table: "MenuItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuGroups_UserId",
                table: "MenuGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuGroups_Users_UserId",
                table: "MenuGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Users_UserId",
                table: "MenuItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPriorities_Users_UserId",
                table: "TaskPriorities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatuses_Users_UserId",
                table: "TaskStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
