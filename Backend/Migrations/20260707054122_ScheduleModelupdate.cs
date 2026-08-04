using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intervoxa_application.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleModelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_UserId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Schedules",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Schedules",
                newName: "InterviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                newName: "IX_Schedules_InterviewId");

            migrationBuilder.AddColumn<int>(
                name: "UserModelUserId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserModelUserId",
                table: "Schedules",
                column: "UserModelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Interviews_InterviewId",
                table: "Schedules",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "InterviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_UserModelUserId",
                table: "Schedules",
                column: "UserModelUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Interviews_InterviewId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_UserModelUserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_UserModelUserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "UserModelUserId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Schedules",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "InterviewId",
                table: "Schedules",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_InterviewId",
                table: "Schedules",
                newName: "IX_Schedules_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
