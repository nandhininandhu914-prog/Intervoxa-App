using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intervoxa_application.Migrations
{
    /// <inheritdoc />
    public partial class updateschedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InterviewTitle",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterviewTitle",
                table: "Schedules");
        }
    }
}
