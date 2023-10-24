using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FormulaOne.API.Migrations
{
    /// <inheritdoc />
    public partial class first_commit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DriverNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acheives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AcheivementName = table.Column<string>(type: "TEXT", nullable: false),
                    DriverId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acheives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acheivement_Driver",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    TicketLevel = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 1, "Silverstone", "British GrandPrix" });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "EventDate", "EventId", "Price", "Status", "TicketLevel" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4300), 1, 100.0, 1, "Bronze" },
                    { 2, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4312), 1, 100.0, 1, "Bronze" },
                    { 3, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4313), 1, 100.0, 1, "Bronze" },
                    { 4, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4314), 1, 100.0, 1, "Bronze" },
                    { 5, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4315), 1, 100.0, 1, "Bronze" },
                    { 6, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4318), 1, 100.0, 1, "Bronze" },
                    { 7, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4319), 1, 100.0, 1, "Bronze" },
                    { 8, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4319), 1, 100.0, 1, "Bronze" },
                    { 9, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4320), 1, 100.0, 1, "Bronze" },
                    { 10, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4322), 1, 100.0, 1, "Bronze" },
                    { 11, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4323), 1, 100.0, 1, "Bronze" },
                    { 12, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4323), 1, 100.0, 1, "Bronze" },
                    { 13, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4324), 1, 100.0, 1, "Bronze" },
                    { 14, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4325), 1, 100.0, 1, "Bronze" },
                    { 15, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4325), 1, 100.0, 1, "Bronze" },
                    { 16, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4326), 1, 100.0, 1, "Bronze" },
                    { 17, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4327), 1, 100.0, 1, "Bronze" },
                    { 18, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4328), 1, 100.0, 1, "Bronze" },
                    { 19, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4329), 1, 100.0, 1, "Bronze" },
                    { 20, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4330), 1, 100.0, 1, "Bronze" },
                    { 21, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4330), 1, 100.0, 1, "Bronze" },
                    { 22, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4331), 1, 100.0, 1, "Bronze" },
                    { 23, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4332), 1, 100.0, 1, "Bronze" },
                    { 24, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4375), 1, 100.0, 1, "Bronze" },
                    { 25, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4376), 1, 100.0, 1, "Bronze" },
                    { 26, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4377), 1, 100.0, 1, "Bronze" },
                    { 27, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4378), 1, 100.0, 1, "Bronze" },
                    { 28, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4378), 1, 100.0, 1, "Bronze" },
                    { 29, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4379), 1, 100.0, 1, "Bronze" },
                    { 30, new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4380), 1, 100.0, 1, "Bronze" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acheives_DriverId",
                table: "Acheives",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EventId",
                table: "Ticket",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acheives");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
