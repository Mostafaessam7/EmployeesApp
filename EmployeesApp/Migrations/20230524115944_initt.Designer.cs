﻿// <auto-generated />
using System;
using EmployeesApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeesApp.Migrations
{
    [DbContext(typeof(HrDatabaseContext))]
    [Migration("20230524115944_initt")]
    partial class initt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeesApp.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentAbbr")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", "dbo");
                });

            modelBuilder.Entity("EmployeesApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<decimal>("GrossSalary")
                        .HasColumnType("decimal(12,2)");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NetSalary")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee", "dbo");
                });

            modelBuilder.Entity("EmployeesApp.Models.Employee", b =>
                {
                    b.HasOne("EmployeesApp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
