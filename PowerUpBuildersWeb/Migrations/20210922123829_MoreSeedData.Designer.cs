﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210922123829_MoreSeedData")]
    partial class MoreSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PowerUpBuildersWeb.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pop Constantin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Popescu Ion"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Aurel Vlad"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Popescu Ana"
                        });
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.EmployeeTask", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("ActualHours")
                        .HasColumnType("int");

                    b.Property<int>("EstimatedHours")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("EmployeesTasks");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            TaskId = 1,
                            ActualHours = 10,
                            EstimatedHours = 8,
                            Id = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            TaskId = 1,
                            ActualHours = 10,
                            EstimatedHours = 8,
                            Id = 2
                        });
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "TestProj"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Test2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Project num 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Proj4"
                        });
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaskNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "TaskDescription",
                            ProjectId = 1,
                            Status = 0,
                            TaskNumber = "TK20190101_01",
                            Title = "TaskTitle"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Do this",
                            ProjectId = 1,
                            Status = 1,
                            TaskNumber = "TK202109091100_01",
                            Title = "Task2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Do that",
                            ProjectId = 1,
                            Status = 2,
                            TaskNumber = "TK202109091100_02",
                            Title = "Task3"
                        });
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.TaskLocalFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskLocalFiles");
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.EmployeeTask", b =>
                {
                    b.HasOne("PowerUpBuildersWeb.Models.Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PowerUpBuildersWeb.Models.Task", "Task")
                        .WithMany("Employees")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.Task", b =>
                {
                    b.HasOne("PowerUpBuildersWeb.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.TaskLocalFile", b =>
                {
                    b.HasOne("PowerUpBuildersWeb.Models.Task", "Task")
                        .WithMany("Files")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.Employee", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("PowerUpBuildersWeb.Models.Task", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
