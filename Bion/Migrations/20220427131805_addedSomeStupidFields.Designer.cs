﻿// <auto-generated />
using Bion.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bion.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20220427131805_addedSomeStupidFields")]
    partial class addedSomeStupidFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bion.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CinemaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CinemaName = "Poor man cinema"
                        },
                        new
                        {
                            Id = 2,
                            CinemaName = "Fancy Cinema"
                        });
                });

            modelBuilder.Entity("Bion.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RunTimeInHours")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RunTimeInHours = 2,
                            Title = "Die Hard"
                        },
                        new
                        {
                            Id = 2,
                            RunTimeInHours = 3,
                            Title = "Lord Of The Rings II"
                        });
                });

            modelBuilder.Entity("Bion.Models.MovieShowTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("MaxNumberSeats")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<double>("MovieScreeningTime")
                        .HasColumnType("float")
                        .HasColumnName("Run Time");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieShowTimes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableSeats = 50,
                            CinemaId = 1,
                            MaxNumberSeats = 50,
                            MovieId = 1,
                            MovieScreeningTime = 13.0
                        },
                        new
                        {
                            Id = 2,
                            AvailableSeats = 50,
                            CinemaId = 1,
                            MaxNumberSeats = 50,
                            MovieId = 2,
                            MovieScreeningTime = 15.0
                        },
                        new
                        {
                            Id = 3,
                            AvailableSeats = 50,
                            CinemaId = 1,
                            MaxNumberSeats = 50,
                            MovieId = 1,
                            MovieScreeningTime = 18.0
                        },
                        new
                        {
                            Id = 4,
                            AvailableSeats = 100,
                            CinemaId = 2,
                            MaxNumberSeats = 100,
                            MovieId = 1,
                            MovieScreeningTime = 18.0
                        },
                        new
                        {
                            Id = 5,
                            AvailableSeats = 100,
                            CinemaId = 2,
                            MaxNumberSeats = 100,
                            MovieId = 2,
                            MovieScreeningTime = 20.0
                        },
                        new
                        {
                            Id = 6,
                            AvailableSeats = 100,
                            CinemaId = 2,
                            MaxNumberSeats = 100,
                            MovieId = 1,
                            MovieScreeningTime = 23.0
                        });
                });

            modelBuilder.Entity("Bion.Models.TicketOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BookingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SalongName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TicketOrders");
                });

            modelBuilder.Entity("Bion.Models.MovieShowTime", b =>
                {
                    b.HasOne("Bion.Models.Cinema", "Cinema")
                        .WithMany("ShowTimes")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bion.Models.Movie", "Movie")
                        .WithMany("ShowTimes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Bion.Models.Cinema", b =>
                {
                    b.Navigation("ShowTimes");
                });

            modelBuilder.Entity("Bion.Models.Movie", b =>
                {
                    b.Navigation("ShowTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
