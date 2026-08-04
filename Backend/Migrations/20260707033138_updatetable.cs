using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intervoxa_application.Migrations
{
    /// <inheritdoc />
    public partial class updatetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Interviews_InterviewId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Candidates_CandidateId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Users_UserId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_CandidateId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_UserId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_InterviewId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "InterviewDate",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "MeetingLink",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Interviews");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Interviews",
                newName: "InterviewerName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Interviews",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "Round",
                table: "Interviews",
                newName: "Designation");

            migrationBuilder.RenameColumn(
                name: "MeetingType",
                table: "Interviews",
                newName: "Department");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ScheduleId",
                table: "Feedbacks",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CandidateId",
                table: "Schedules",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Schedules_ScheduleId",
                table: "Feedbacks",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Schedules_ScheduleId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ScheduleId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "InterviewerName",
                table: "Interviews",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Interviews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Interviews",
                newName: "Round");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Interviews",
                newName: "MeetingType");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Interviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InterviewDate",
                table: "Interviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MeetingLink",
                table: "Interviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Interviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CandidateId",
                table: "Interviews",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_UserId",
                table: "Interviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_InterviewId",
                table: "Feedbacks",
                column: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Interviews_InterviewId",
                table: "Feedbacks",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "InterviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Candidates_CandidateId",
                table: "Interviews",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Users_UserId",
                table: "Interviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
