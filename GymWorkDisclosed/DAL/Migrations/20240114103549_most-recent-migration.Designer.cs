﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(GymWorkoutDisclosedDBContext))]
    [Migration("20231027111932_LocalDatabase")]
    partial class LocalDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BusinessLogic.Entities.BodyPartEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("bodyParts");
                });

            modelBuilder.Entity("BusinessLogic.Entities.ExerciseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("exercises");
                });

            modelBuilder.Entity("BusinessLogic.Entities.GymGoerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("gymGoer");
                });

            modelBuilder.Entity("BusinessLogic.Entities.MuscleGroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BodyPartId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BodyPartId");

                    b.ToTable("muscleGroups");
                });

            modelBuilder.Entity("BusinessLogic.Entities.MuscleGroupExerciseEntity", b =>
                {
                    b.Property<Guid>("MuscleGroupId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("char(36)");

                    b.HasKey("MuscleGroupId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("MuscleGroupExerciseEntity");
                });

            modelBuilder.Entity("BusinessLogic.Entities.SetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("sets");
                });

            modelBuilder.Entity("BusinessLogic.Entities.WorkoutEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("GymGoerId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("GymGoerId");

                    b.ToTable("workouts");
                });

            modelBuilder.Entity("BusinessLogic.Entities.MuscleGroupEntity", b =>
                {
                    b.HasOne("BusinessLogic.Entities.BodyPartEntity", "BodyPartEntity")
                        .WithMany("MuscleGroups")
                        .HasForeignKey("BodyPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyPartEntity");
                });

            modelBuilder.Entity("BusinessLogic.Entities.MuscleGroupExerciseEntity", b =>
                {
                    b.HasOne("BusinessLogic.Entities.ExerciseEntity", "ExerciseEntity")
                        .WithMany("MuscleGroupExerciseEntities")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessLogic.Entities.MuscleGroupEntity", "MuscleGroupEntity")
                        .WithMany("MuscleGroupExerciseEntities")
                        .HasForeignKey("MuscleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseEntity");

                    b.Navigation("MuscleGroupEntity");
                });

            modelBuilder.Entity("BusinessLogic.Entities.SetEntity", b =>
                {
                    b.HasOne("BusinessLogic.Entities.WorkoutEntity", "WorkoutEntity")
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutEntity");
                });

            modelBuilder.Entity("BusinessLogic.Entities.WorkoutEntity", b =>
                {
                    b.HasOne("BusinessLogic.Entities.ExerciseEntity", "ExerciseEntity")
                        .WithMany("Workouts")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessLogic.Entities.GymGoerEntity", "GymGoerEntity")
                        .WithMany("Workouts")
                        .HasForeignKey("GymGoerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseEntity");

                    b.Navigation("GymGoerEntity");
                });

            modelBuilder.Entity("BusinessLogic.Entities.BodyPartEntity", b =>
                {
                    b.Navigation("MuscleGroups");
                });

            modelBuilder.Entity("BusinessLogic.Entities.ExerciseEntity", b =>
                {
                    b.Navigation("MuscleGroupExerciseEntities");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("BusinessLogic.Entities.GymGoerEntity", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("BusinessLogic.Entities.MuscleGroupEntity", b =>
                {
                    b.Navigation("MuscleGroupExerciseEntities");
                });

            modelBuilder.Entity("BusinessLogic.Entities.WorkoutEntity", b =>
                {
                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}