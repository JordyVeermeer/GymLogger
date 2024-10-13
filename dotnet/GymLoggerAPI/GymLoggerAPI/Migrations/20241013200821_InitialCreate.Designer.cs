﻿// <auto-generated />
using GymLoggerAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymLoggerAPI.Migrations
{
    [DbContext(typeof(GymLoggerContext))]
    [Migration("20241013200821_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymLoggerAPI.Models.Exercise", b =>
                {
                    b.Property<long>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ExerciseId"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ExerciseId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Exercise", (string)null);

                    b.HasData(
                        new
                        {
                            ExerciseId = 1L,
                            Description = "Push bar upwards with arms",
                            Name = "Bench Press"
                        },
                        new
                        {
                            ExerciseId = 2L,
                            Description = "Push bar upwards with legs",
                            Name = "Barbell Squat"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
