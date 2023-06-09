﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OffsureAssessment.Context;

#nullable disable

namespace OffsureAssessment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230607134317_OptionalOneToOnes")]
    partial class OptionalOneToOnes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OffsureAssessment.Model.CarListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<double>("DriveAwayPrice")
                        .HasColumnType("double precision");

                    b.Property<double>("ExcludingGovernmentCharges")
                        .HasColumnType("double precision");

                    b.Property<string>("Make")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CarListings");
                });

            modelBuilder.Entity("OffsureAssessment.Model.DealerProperties", b =>
                {
                    b.Property<int>("DealerPropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DealerPropertyId"));

                    b.Property<string>("ABN")
                        .HasColumnType("text");

                    b.Property<int?>("ListingId")
                        .HasColumnType("integer");

                    b.HasKey("DealerPropertyId");

                    b.HasIndex("ListingId")
                        .IsUnique();

                    b.ToTable("DealerProperties");
                });

            modelBuilder.Entity("OffsureAssessment.Model.NonDealerProperties", b =>
                {
                    b.Property<int>("NonDealerPropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NonDealerPropertyId"));

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("ListingId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("NonDealerPropertyId");

                    b.HasIndex("ListingId")
                        .IsUnique();

                    b.ToTable("NonDealerProperties");
                });

            modelBuilder.Entity("OffsureAssessment.Model.DealerProperties", b =>
                {
                    b.HasOne("OffsureAssessment.Model.CarListing", "CarListing")
                        .WithOne("DealerProperties")
                        .HasForeignKey("OffsureAssessment.Model.DealerProperties", "ListingId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("CarListing");
                });

            modelBuilder.Entity("OffsureAssessment.Model.NonDealerProperties", b =>
                {
                    b.HasOne("OffsureAssessment.Model.CarListing", "CarListing")
                        .WithOne("NonDealerProperties")
                        .HasForeignKey("OffsureAssessment.Model.NonDealerProperties", "ListingId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("CarListing");
                });

            modelBuilder.Entity("OffsureAssessment.Model.CarListing", b =>
                {
                    b.Navigation("DealerProperties");

                    b.Navigation("NonDealerProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
