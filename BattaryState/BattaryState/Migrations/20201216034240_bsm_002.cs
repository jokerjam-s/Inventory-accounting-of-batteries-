using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattaryState.Migrations
{
    public partial class bsm_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LastBatteryState_BatteryState_BatteryStateId",
                table: "LastBatteryState");

            migrationBuilder.DropIndex(
                name: "IX_LastBatteryState_BatteryStateId",
                table: "LastBatteryState");

            migrationBuilder.RenameColumn(
                name: "BatteryStateId",
                table: "LastBatteryState",
                newName: "endVoltage");

            migrationBuilder.AddColumn<DateTime>(
                name: "beginChangeTime",
                table: "LastBatteryState",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "beginPercent",
                table: "LastBatteryState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "beginVoltage",
                table: "LastBatteryState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "currency",
                table: "LastBatteryState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "endPercent",
                table: "LastBatteryState",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "beginChangeTime",
                table: "LastBatteryState");

            migrationBuilder.DropColumn(
                name: "beginPercent",
                table: "LastBatteryState");

            migrationBuilder.DropColumn(
                name: "beginVoltage",
                table: "LastBatteryState");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "LastBatteryState");

            migrationBuilder.DropColumn(
                name: "endPercent",
                table: "LastBatteryState");

            migrationBuilder.RenameColumn(
                name: "endVoltage",
                table: "LastBatteryState",
                newName: "BatteryStateId");

            migrationBuilder.CreateIndex(
                name: "IX_LastBatteryState_BatteryStateId",
                table: "LastBatteryState",
                column: "BatteryStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_LastBatteryState_BatteryState_BatteryStateId",
                table: "LastBatteryState",
                column: "BatteryStateId",
                principalTable: "BatteryState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
