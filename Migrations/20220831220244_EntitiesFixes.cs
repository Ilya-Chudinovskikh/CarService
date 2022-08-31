using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarService.Migrations
{
    public partial class EntitiesFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REPAIR_SERVICES_MASTERS_ID_MASTER",
                table: "REPAIR_SERVICES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "START_DATE",
                table: "REPAIR_SERVICES",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ID_MASTER",
                table: "REPAIR_SERVICES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_REPAIR_SERVICES_MASTERS_ID_MASTER",
                table: "REPAIR_SERVICES",
                column: "ID_MASTER",
                principalTable: "MASTERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REPAIR_SERVICES_MASTERS_ID_MASTER",
                table: "REPAIR_SERVICES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "START_DATE",
                table: "REPAIR_SERVICES",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "ID_MASTER",
                table: "REPAIR_SERVICES",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_REPAIR_SERVICES_MASTERS_ID_MASTER",
                table: "REPAIR_SERVICES",
                column: "ID_MASTER",
                principalTable: "MASTERS",
                principalColumn: "Id");
        }
    }
}
