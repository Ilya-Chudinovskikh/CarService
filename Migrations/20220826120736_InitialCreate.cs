using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAR_OWNERS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSPORT_SERIES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSPORT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    THIRDNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_OWNERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MASTERS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WORK_EXPERIENCE = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    THIRDNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MASTERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CARS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_OWNER = table.Column<long>(type: "bigint", nullable: false),
                    BRAND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODEL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MILEAGE = table.Column<int>(type: "int", nullable: true),
                    EMGINE_VOLUME = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARS_CAR_OWNERS_ID_OWNER",
                        column: x => x.ID_OWNER,
                        principalTable: "CAR_OWNERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REPAIR_SERVICES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CAR = table.Column<long>(type: "bigint", nullable: false),
                    ID_MASTER = table.Column<long>(type: "bigint", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WORK_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COMPLETION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPAIR_SERVICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REPAIR_SERVICES_CARS_ID_CAR",
                        column: x => x.ID_CAR,
                        principalTable: "CARS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REPAIR_SERVICES_MASTERS_ID_MASTER",
                        column: x => x.ID_MASTER,
                        principalTable: "MASTERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARS_ID_OWNER",
                table: "CARS",
                column: "ID_OWNER");

            migrationBuilder.CreateIndex(
                name: "IX_REPAIR_SERVICES_ID_CAR",
                table: "REPAIR_SERVICES",
                column: "ID_CAR");

            migrationBuilder.CreateIndex(
                name: "IX_REPAIR_SERVICES_ID_MASTER",
                table: "REPAIR_SERVICES",
                column: "ID_MASTER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "REPAIR_SERVICES");

            migrationBuilder.DropTable(
                name: "CARS");

            migrationBuilder.DropTable(
                name: "MASTERS");

            migrationBuilder.DropTable(
                name: "CAR_OWNERS");
        }
    }
}
