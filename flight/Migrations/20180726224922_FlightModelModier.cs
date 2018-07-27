using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace flight.Migrations
{
    public partial class FlightModelModier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportDepartAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportDestinAirportId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirportDepartAirportId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirportDestinAirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirportDepartAirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirportDestinAirportId",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "AircraftId",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AirportDepartId",
                table: "Flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AirportDestinId",
                table: "Flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Aircrafts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportDepartId",
                table: "Flights",
                column: "AirportDepartId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportDestinId",
                table: "Flights",
                column: "AirportDestinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_AirportDepartId",
                table: "Flights",
                column: "AirportDepartId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_AirportDestinId",
                table: "Flights",
                column: "AirportDestinId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportDepartId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportDestinId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirportDepartId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirportDestinId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirportDepartId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirportDestinId",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "AircraftId",
                table: "Flights",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AirportDepartAirportId",
                table: "Flights",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AirportDestinAirportId",
                table: "Flights",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Aircrafts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportDepartAirportId",
                table: "Flights",
                column: "AirportDepartAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportDestinAirportId",
                table: "Flights",
                column: "AirportDestinAirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_AirportDepartAirportId",
                table: "Flights",
                column: "AirportDepartAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_AirportDestinAirportId",
                table: "Flights",
                column: "AirportDestinAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
