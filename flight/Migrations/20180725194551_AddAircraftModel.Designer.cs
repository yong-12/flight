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
    [Migration("20180725194551_AddAircraftModel")]
    partial class AddAircraftModel
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

                    b.Property<string>("Name");

                    b.HasKey("AircraftId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("flight.Data.Model.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });
#pragma warning restore 612, 618
        }
    }
}
