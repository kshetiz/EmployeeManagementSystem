﻿// <auto-generated />
using System;
using EmployeeManagement.Web.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220629071031_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Data.Entities.EmployeeJobHisstories", b =>
                {
                    b.Property<int>("EmployeeJobHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("EmployeeJobHistoryId"));

                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PositionsPostionId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("EmployeeJobHistoryId");

                    b.HasIndex("EmployeesEmployeeId");

                    b.HasIndex("PositionsPostionId");

                    b.ToTable("EmployeeJobHisstories");
                });

            modelBuilder.Entity("WebApplication1.Data.Entities.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("EmployeeCode")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<int>("PeoplePersonId")
                        .HasColumnType("integer");

                    b.Property<int>("PositionsPostionId")
                        .HasColumnType("integer");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PeoplePersonId");

                    b.HasIndex("PositionsPostionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApplication1.Data.Entities.People", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PersonId");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("WebApplication1.Data.Entities.Positions", b =>
                {
                    b.Property<int>("PostionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("PostionId"));

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PostionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("WebApplication1.Data.Entities.EmployeeJobHisstories", b =>
                {
                    b.HasOne("WebApplication1.Data.Entities.Employees", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Entities.Positions", "Positions")
                        .WithMany()
                        .HasForeignKey("PositionsPostionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Positions");
                });

            modelBuilder.Entity("WebApplication1.Data.Entities.Employees", b =>
                {
                    b.HasOne("WebApplication1.Data.Entities.People", "People")
                        .WithMany()
                        .HasForeignKey("PeoplePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Entities.Positions", "Positions")
                        .WithMany()
                        .HasForeignKey("PositionsPostionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");

                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
