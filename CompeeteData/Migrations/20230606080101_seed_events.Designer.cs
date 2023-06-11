﻿// <auto-generated />
using System;
using CompeeteData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompeeteData.Migrations
{
    [DbContext(typeof(CompeeteDBContext))]
    [Migration("20230606080101_seed_events")]
    partial class seed_events
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CompeeteData.Models.Constraint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AgeMax")
                        .HasColumnType("int");

                    b.Property<int?>("AgeMin")
                        .HasColumnType("int");

                    b.Property<int?>("MaxNumber")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Constraints");
                });

            modelBuilder.Entity("CompeeteData.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "123 rue du test",
                            Description = "Un petit evenement bon pour les cochons",
                            End = new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "next1",
                            Start = new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 2,
                            Adress = "123 rue du test",
                            Description = "Un petit evenement bon pour les cochons",
                            End = new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "previous1",
                            Start = new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 3,
                            Adress = "123 rue du test",
                            Description = "Un petit evenement bon pour les cochons",
                            End = new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "next2",
                            Start = new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 4,
                            Adress = "123 rue du test",
                            Description = "Un petit evenement bon pour les cochons",
                            End = new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "previous2",
                            Start = new DateTime(2023, 5, 26, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("CompeeteData.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Chrono")
                        .HasColumnType("int");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.HasIndex("UserId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("CompeeteData.Models.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Boxe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Judo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lutte"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Natation"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Badminton"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Plongeon"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Tennis"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Tennis de Table"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Cyclisme"
                        });
                });

            modelBuilder.Entity("CompeeteData.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConstraintId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ConstraintId");

                    b.HasIndex("EventId");

                    b.HasIndex("SportId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("CompeeteData.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TournamentUser", b =>
                {
                    b.Property<int>("TournamentsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("TournamentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TournamentUser");
                });

            modelBuilder.Entity("CompeeteData.Models.Result", b =>
                {
                    b.HasOne("CompeeteData.Models.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId");

                    b.HasOne("CompeeteData.Models.User", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserId");

                    b.Navigation("Tournament");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CompeeteData.Models.Tournament", b =>
                {
                    b.HasOne("CompeeteData.Models.Constraint", "Constraint")
                        .WithMany()
                        .HasForeignKey("ConstraintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompeeteData.Models.Event", "Event")
                        .WithMany("Tournaments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompeeteData.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constraint");

                    b.Navigation("Event");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("TournamentUser", b =>
                {
                    b.HasOne("CompeeteData.Models.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompeeteData.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompeeteData.Models.Event", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("CompeeteData.Models.User", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
