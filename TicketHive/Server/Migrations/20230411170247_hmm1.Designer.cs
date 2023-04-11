﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketHive.Server.Data;

#nullable disable

namespace TicketHive.Server.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20230411170247_hmm1")]
    partial class hmm1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventModelUserModel", b =>
                {
                    b.Property<int>("BookingsId")
                        .HasColumnType("int");

                    b.Property<string>("VisitorsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BookingsId", "VisitorsId");

                    b.HasIndex("VisitorsId");

                    b.ToTable("EventModelUserModel");
                });

            modelBuilder.Entity("TicketHive.Shared.Models.EventModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTickets")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A concert featuring various artists in the local park",
                            EndTime = new DateTime(2023, 8, 1, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 0,
                            Host = "The local community council",
                            ImageUrl = "image 1.avif",
                            Location = "The local park",
                            Name = "Concert in the park",
                            NumberOfTickets = 1000,
                            Price = 350m,
                            StartTime = new DateTime(2023, 8, 1, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "A new exhibit featuring local artists",
                            EndTime = new DateTime(2023, 10, 14, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 1,
                            Host = "The local art museum",
                            ImageUrl = "~/images/event images/image 2.avif",
                            Location = "Center Art Museum",
                            Name = "Art exhibit opening",
                            NumberOfTickets = 500,
                            Price = 100m,
                            StartTime = new DateTime(2023, 10, 14, 19, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Description = "A wine tasting featuring local wineries",
                            EndTime = new DateTime(2023, 8, 20, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 2,
                            Host = "The Wine Association",
                            ImageUrl = "~/images/event images/image 3.avif",
                            Location = "Hillside Wine Garden",
                            Name = "Wine tasting",
                            NumberOfTickets = 300,
                            Price = 200m,
                            StartTime = new DateTime(2023, 8, 20, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Description = "A charity run to raise funds for local causes",
                            EndTime = new DateTime(2023, 12, 31, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 3,
                            Host = "The local sports association",
                            ImageUrl = "~/images/event images/image 4.avif",
                            Location = "Downtown",
                            Name = "Charity run",
                            NumberOfTickets = 2000,
                            Price = 800m,
                            StartTime = new DateTime(2023, 12, 31, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Description = "A comedy show featuring local comedians",
                            EndTime = new DateTime(2023, 11, 15, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 4,
                            Host = "The Comedy Club",
                            ImageUrl = "~/images/event images/image 5.avif",
                            Location = "Central Comedy Club House",
                            Name = "Comedy show",
                            NumberOfTickets = 500,
                            Price = 100m,
                            StartTime = new DateTime(2023, 11, 15, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Description = "A film festival showcasing international films",
                            EndTime = new DateTime(2023, 1, 5, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 5,
                            Host = "The Film Society",
                            ImageUrl = "~/images/event images/image 6.avif",
                            Location = "Film Society Cinema",
                            Name = "Film festival",
                            NumberOfTickets = 120,
                            Price = 300m,
                            StartTime = new DateTime(2023, 1, 5, 17, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Description = "A music festival featuring international musicians",
                            EndTime = new DateTime(2023, 9, 11, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 6,
                            Host = "Music Association",
                            ImageUrl = "~/images/event images/image 7.avif",
                            Location = "The local park",
                            Name = "Local music festival",
                            NumberOfTickets = 5000,
                            Price = 1500m,
                            StartTime = new DateTime(2023, 9, 11, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Description = "A fair featuring local artisans selling their crafts",
                            EndTime = new DateTime(2023, 5, 21, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 7,
                            Host = "Local artisans association",
                            ImageUrl = "~/images/event images/image 8.avif",
                            Location = "Downtown market place",
                            Name = "Artisan fair",
                            NumberOfTickets = 1000,
                            Price = 50m,
                            StartTime = new DateTime(2023, 5, 21, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Description = "A one day class on theater production of a classic play",
                            EndTime = new DateTime(2023, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 10,
                            Host = "Educate Theater Association",
                            ImageUrl = "~/images/event images/image 9.avif",
                            Location = "Central library",
                            Name = "Theater production",
                            NumberOfTickets = 100,
                            Price = 1200m,
                            StartTime = new DateTime(2023, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Description = "A day of family fun featuring various activities for kids and adults",
                            EndTime = new DateTime(2023, 7, 30, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 8,
                            Host = "The local community center",
                            ImageUrl = "~/images/event images/image 10.avif",
                            Location = "Community Hall",
                            Name = "Family fun day",
                            NumberOfTickets = 350,
                            Price = 80m,
                            StartTime = new DateTime(2023, 7, 30, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            Description = "A science fair featuring local scientists and their research",
                            EndTime = new DateTime(2023, 10, 18, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 9,
                            Host = "The local science museum",
                            ImageUrl = "~/images/event images/image 11.avif",
                            Location = "The Central Museum",
                            Name = "Science fair",
                            NumberOfTickets = 1000,
                            Price = 50m,
                            StartTime = new DateTime(2023, 10, 18, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            Description = "A fashion show featuring various international designers",
                            EndTime = new DateTime(2023, 12, 15, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 4,
                            Host = "The Fashion association",
                            ImageUrl = "~/images/event images/image 12.avif",
                            Location = "The Central Mall",
                            Name = "Fashion show",
                            NumberOfTickets = 300,
                            Price = 450m,
                            StartTime = new DateTime(2023, 12, 15, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 13,
                            Description = "A formal gala dinner featuring gourmet cuisine and live entertainment",
                            EndTime = new DateTime(2023, 6, 30, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 2,
                            Host = "Food&Wine Inc",
                            ImageUrl = "~/images/event images/image 13.avif",
                            Location = "Fine Food Restaurant",
                            Name = "Gala dinner",
                            NumberOfTickets = 300,
                            Price = 1500m,
                            StartTime = new DateTime(2023, 6, 30, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 14,
                            Description = "A lecture series featuring renowned speakers on various topics",
                            EndTime = new DateTime(2023, 9, 8, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 1,
                            Host = "The local university",
                            ImageUrl = "~/images/event images/image 14.avif",
                            Location = "Central Library",
                            Name = "Lecture series",
                            NumberOfTickets = 500,
                            Price = 90m,
                            StartTime = new DateTime(2023, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 15,
                            Description = "A tech meetup featuring local tech entrepreneurs and their startups",
                            EndTime = new DateTime(2023, 8, 17, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 11,
                            Host = "Local startup incubator",
                            ImageUrl = "~/images/event images/image 15.avif",
                            Location = "The House of Incubator",
                            Name = "Tech meetup",
                            NumberOfTickets = 50,
                            Price = 900m,
                            StartTime = new DateTime(2023, 8, 17, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 16,
                            Description = "A trivia night featuring various categories and fine prizes",
                            EndTime = new DateTime(2023, 10, 11, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 12,
                            Host = "The DownTown Pub",
                            ImageUrl = "~/images/event images/image 16.avif",
                            Location = "The DownTown Pub",
                            Name = "Trivia night",
                            NumberOfTickets = 70,
                            Price = 150m,
                            StartTime = new DateTime(2023, 10, 11, 19, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 17,
                            Description = "A party featuring international DJ:s and live entertainment",
                            EndTime = new DateTime(2023, 11, 25, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 13,
                            Host = "The local nightclub",
                            ImageUrl = "~/images/event images/image 17.avif",
                            Location = "The local nightclub",
                            Name = "DJ party",
                            NumberOfTickets = 400,
                            Price = 250m,
                            StartTime = new DateTime(2023, 11, 25, 21, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 18,
                            Description = "An art workshop featuring a local artist teaching a new technique",
                            EndTime = new DateTime(2023, 12, 9, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 14,
                            Host = "The local art school",
                            ImageUrl = "~/images/event images/image 18.avif",
                            Location = "The Central School of Art",
                            Name = "Art workshop",
                            NumberOfTickets = 50,
                            Price = 100m,
                            StartTime = new DateTime(2023, 12, 9, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 19,
                            Description = "A screening of a new surprise movie with Q&A session with the director",
                            EndTime = new DateTime(2023, 8, 5, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 5,
                            Host = "The local movie theatre",
                            ImageUrl = "~/images/event images/image 19.avif",
                            Location = "The DownTown Movie Theater",
                            Name = "Movie screening",
                            NumberOfTickets = 70,
                            Price = 200m,
                            StartTime = new DateTime(2023, 8, 5, 17, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 20,
                            Description = "A charity walk to raise funds for a local charity",
                            EndTime = new DateTime(2023, 10, 20, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 3,
                            Host = "Local community organizatio",
                            ImageUrl = "~/images/event images/image 20.avif",
                            Location = "Central town",
                            Name = "Charity walk",
                            NumberOfTickets = 1500,
                            Price = 0m,
                            StartTime = new DateTime(2023, 10, 20, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 21,
                            Description = "A night of stand-up comedy featuring local comedians",
                            EndTime = new DateTime(2023, 7, 28, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 4,
                            Host = "The HaveFun Comedy Club",
                            ImageUrl = "~/images/event images/image 21.avif",
                            Location = "The local comedy club",
                            Name = "Comedy night",
                            NumberOfTickets = 200,
                            Price = 250m,
                            StartTime = new DateTime(2023, 7, 28, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 22,
                            Description = "A wine tasting event featuring local wineries",
                            EndTime = new DateTime(2023, 5, 5, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 2,
                            Host = "The local wine association",
                            ImageUrl = "~/images/event images/image 22.avif",
                            Location = "The local park",
                            Name = "Wine tasting",
                            NumberOfTickets = 100,
                            Price = 300m,
                            StartTime = new DateTime(2023, 5, 5, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 23,
                            Description = "A fitness class featuring a local instructor",
                            EndTime = new DateTime(2023, 10, 12, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 15,
                            Host = "The local gym",
                            ImageUrl = "~/images/event images/image 23.avif",
                            Location = "The local park",
                            Name = "Fitness class",
                            NumberOfTickets = 80,
                            Price = 100m,
                            StartTime = new DateTime(2023, 10, 12, 19, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 24,
                            Description = "A tech workshop were you get to build your own miniature robot",
                            EndTime = new DateTime(2023, 8, 16, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 14,
                            Host = "International Robot Inc",
                            ImageUrl = "~/images/event images/image 24.avif",
                            Location = "The local university",
                            Name = "Build your own robot",
                            NumberOfTickets = 1000,
                            Price = 1500m,
                            StartTime = new DateTime(2023, 8, 16, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 25,
                            Description = "An unplugged concert featuring various artists in the local park",
                            EndTime = new DateTime(2023, 11, 5, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 0,
                            Host = "The local community council",
                            ImageUrl = "~/images/event images/image 25.avif",
                            Location = "The local park",
                            Name = "Unplugged concert",
                            NumberOfTickets = 1000,
                            Price = 350m,
                            StartTime = new DateTime(2023, 11, 5, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 26,
                            Description = "An art exhibition featuring international works of art",
                            EndTime = new DateTime(2023, 9, 17, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            EventType = 1,
                            Host = "Fine Arts Association",
                            ImageUrl = "~/images/event images/image 26.avif",
                            Location = "The local arts gallery",
                            Name = "Contemporary Art Show",
                            NumberOfTickets = 200,
                            Price = 300m,
                            StartTime = new DateTime(2023, 9, 17, 17, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TicketHive.Shared.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventModelUserModel", b =>
                {
                    b.HasOne("TicketHive.Shared.Models.EventModel", null)
                        .WithMany()
                        .HasForeignKey("BookingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketHive.Shared.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("VisitorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}