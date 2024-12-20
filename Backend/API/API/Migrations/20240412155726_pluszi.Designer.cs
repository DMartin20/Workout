﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240412155726_pluszi")]
    partial class pluszi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Domain.Difficulty", b =>
                {
                    b.Property<int>("DifficultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DifficultyId"));

                    b.Property<string>("DifficultyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DifficultyId");

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("API.Models.Domain.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseId"));

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseId");

                    b.HasIndex("DifficultyId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("API.Models.Domain.ExerciseType", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("ExerciseTypes");
                });

            modelBuilder.Entity("API.Models.Domain.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("API.Models.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.Domain.WorkoutExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutExercises");
                });

            modelBuilder.Entity("API.Models.Domain.WorkoutPlan", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutId"));

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Rest")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WorkoutName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkoutId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutPlans");
                });

            modelBuilder.Entity("API.Models.Domain.Exercise", b =>
                {
                    b.HasOne("API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany("Exercises")
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");
                });

            modelBuilder.Entity("API.Models.Domain.ExerciseType", b =>
                {
                    b.HasOne("API.Models.Domain.Exercise", "Exercise")
                        .WithMany("ExerciseTypes")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Domain.Type", "Type")
                        .WithMany("ExerciseTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("API.Models.Domain.WorkoutExercise", b =>
                {
                    b.HasOne("API.Models.Domain.Exercise", "Exercise")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Domain.WorkoutPlan", "WorkoutPlan")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("WorkoutPlan");
                });

            modelBuilder.Entity("API.Models.Domain.WorkoutPlan", b =>
                {
                    b.HasOne("API.Models.Domain.User", "User")
                        .WithMany("WorkoutPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.Domain.Difficulty", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("API.Models.Domain.Exercise", b =>
                {
                    b.Navigation("ExerciseTypes");

                    b.Navigation("WorkoutExercises");
                });

            modelBuilder.Entity("API.Models.Domain.Type", b =>
                {
                    b.Navigation("ExerciseTypes");
                });

            modelBuilder.Entity("API.Models.Domain.User", b =>
                {
                    b.Navigation("WorkoutPlans");
                });

            modelBuilder.Entity("API.Models.Domain.WorkoutPlan", b =>
                {
                    b.Navigation("WorkoutExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
