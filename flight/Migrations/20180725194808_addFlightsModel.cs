using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace flight.Migrations
{
    public partial class addFlightsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftId = table.Column<int>(nullable: true),
                    AirportDepartAirportId = table.Column<int>(nullable: true),
                    AirportDestinAirportId = table.Column<int>(nullable: true),
                    Distance = table.Column<double>(nullable: false),
                    FuelNeeded = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportDepartAirportId",
                        column: x => x.AirportDepartAirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportDestinAirportId",
                        column: x => x.AirportDestinAirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftId",
                table: "Flights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportDepartAirportId",
                table: "Flights",
                column: "AirportDepartAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportDestinAirportId",
                table: "Flights",
                column: "AirportDestinAirportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
