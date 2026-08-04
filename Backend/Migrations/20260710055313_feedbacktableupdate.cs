using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intervoxa_application.Migrations
{
    /// <inheritdoc />
    public partial class feedbacktableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ScheduleId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "comments",
                table: "Feedbacks",
                newName: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FeedbackDate",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ScheduleId",
                table: "Feedbacks",
                column: "ScheduleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ScheduleId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackDate",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Feedbacks",
                newName: "comments");

            migrationBuilder.AlterColumn<string>(
                name: "comments",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ScheduleId",
                table: "Feedbacks",
                column: "ScheduleId");
        }
    }
}
