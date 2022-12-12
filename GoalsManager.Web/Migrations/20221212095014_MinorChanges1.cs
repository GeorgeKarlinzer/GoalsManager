using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalsManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class MinorChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeadLine",
                table: "RecurringSingleTasks",
                newName: "Deadline");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompleteDate",
                table: "GoalSteps",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "GoalSteps",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "GoalSteps");

            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "RecurringSingleTasks",
                newName: "DeadLine");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompleteDate",
                table: "GoalSteps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
