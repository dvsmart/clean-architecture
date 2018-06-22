using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class latestmodification3 : Migration
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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TaskStatuses",
                newName: "AddedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatuses_UserId",
                table: "TaskStatuses",
                newName: "IX_TaskStatuses_AddedByUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tasks",
                newName: "AddedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                newName: "IX_Tasks_AddedByUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TaskPriorities",
                newName: "AddedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPriorities_UserId",
                table: "TaskPriorities",
                newName: "IX_TaskPriorities_AddedByUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MenuItems",
                newName: "AddedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_UserId",
                table: "MenuItems",
                newName: "IX_MenuItems_AddedByUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MenuGroups",
                newName: "AddedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuGroups_UserId",
                table: "MenuGroups",
                newName: "IX_MenuGroups_AddedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuGroups_Users_AddedByUserId",
                table: "MenuGroups",
                column: "AddedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Users_AddedByUserId",
                table: "MenuItems",
                column: "AddedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPriorities_Users_AddedByUserId",
                table: "TaskPriorities",
                column: "AddedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AddedByUserId",
                table: "Tasks",
                column: "AddedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatuses_Users_AddedByUserId",
                table: "TaskStatuses",
                column: "AddedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuGroups_Users_AddedByUserId",
                table: "MenuGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_AddedByUserId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPriorities_Users_AddedByUserId",
                table: "TaskPriorities");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AddedByUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatuses_Users_AddedByUserId",
                table: "TaskStatuses");

            migrationBuilder.RenameColumn(
                name: "AddedByUserId",
                table: "TaskStatuses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatuses_AddedByUserId",
                table: "TaskStatuses",
                newName: "IX_TaskStatuses_UserId");

            migrationBuilder.RenameColumn(
                name: "AddedByUserId",
                table: "Tasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AddedByUserId",
                table: "Tasks",
                newName: "IX_Tasks_UserId");

            migrationBuilder.RenameColumn(
                name: "AddedByUserId",
                table: "TaskPriorities",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPriorities_AddedByUserId",
                table: "TaskPriorities",
                newName: "IX_TaskPriorities_UserId");

            migrationBuilder.RenameColumn(
                name: "AddedByUserId",
                table: "MenuItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_AddedByUserId",
                table: "MenuItems",
                newName: "IX_MenuItems_UserId");

            migrationBuilder.RenameColumn(
                name: "AddedByUserId",
                table: "MenuGroups",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuGroups_AddedByUserId",
                table: "MenuGroups",
                newName: "IX_MenuGroups_UserId");

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
