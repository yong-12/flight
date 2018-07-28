﻿// <auto-generated />
using flight.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace flight.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180727231248_AddValidation")]
    partial class AddValidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("flight.Data.Model.Aircraft", b =>
                {
                    b.Property<int>("AircraftId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("FuelComsumption");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("AircraftId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("flight.Data.Model.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("flight.Data.Model.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AircraftId");

                    b.Property<int>("AirportDepartId");

                    b.Property<int>("AirportDestinationId");

                    b.Property<double>("Distance");

                    b.Property<double>("FuelNeeded");

                    b.HasKey("FlightId");

                    b.HasIndex("AircraftId");

                    b.HasIndex("AirportDepartId");

                    b.HasIndex("AirportDestinationId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("flight.Data.Model.Flight", b =>
                {
                    b.HasOne("flight.Data.Model.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("flight.Data.Model.Airport", "AirportDepart")
                        .WithMany()
                        .HasForeignKey("AirportDepartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("flight.Data.Model.Airport", "AirportDestination")
                        .WithMany()
                        .HasForeignKey("AirportDestinationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
