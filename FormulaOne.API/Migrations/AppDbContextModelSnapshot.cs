﻿// <auto-generated />
using System;
using FormulaOne.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormulaOne.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("FormulaOne.API.Models.Acheivement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AcheivementName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DriverId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Acheives");
                });

            modelBuilder.Entity("FormulaOne.API.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DriverNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("FormulaOne.API.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Silverstone",
                            Name = "British GrandPrix"
                        });
                });

            modelBuilder.Entity("FormulaOne.API.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TicketLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Ticket");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4300),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 2,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4312),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 3,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4313),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 4,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4314),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 5,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4315),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 6,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4318),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 7,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4319),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 8,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4319),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 9,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4320),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 10,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4322),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 11,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4323),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 12,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4323),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 13,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4324),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 14,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4325),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 15,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4325),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 16,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4326),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 17,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4327),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 18,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4328),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 19,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4329),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 20,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4330),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 21,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4330),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 22,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4331),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 23,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4332),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 24,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4375),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 25,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4376),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 26,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4377),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 27,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4378),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 28,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4378),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 29,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4379),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        },
                        new
                        {
                            Id = 30,
                            EventDate = new DateTime(2023, 11, 13, 19, 33, 45, 410, DateTimeKind.Utc).AddTicks(4380),
                            EventId = 1,
                            Price = 100.0,
                            Status = 1,
                            TicketLevel = "Bronze"
                        });
                });

            modelBuilder.Entity("FormulaOne.API.Models.Acheivement", b =>
                {
                    b.HasOne("FormulaOne.API.Models.Driver", "Driver")
                        .WithMany("Acheivements")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Acheivement_Driver");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("FormulaOne.API.Models.Ticket", b =>
                {
                    b.HasOne("FormulaOne.API.Models.Event", null)
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormulaOne.API.Models.Driver", b =>
                {
                    b.Navigation("Acheivements");
                });

            modelBuilder.Entity("FormulaOne.API.Models.Event", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
