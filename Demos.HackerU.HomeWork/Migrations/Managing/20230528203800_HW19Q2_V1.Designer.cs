﻿// <auto-generated />
using Demos.HackerU.HomeWork.HW_19;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demos.HackerU.HomeWork.Migrations.Managing
{
    [DbContext(typeof(ManagingContext))]
    [Migration("20230528203800_HW19Q2_V1")]
    partial class HW19Q2_V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demos.HackerU.HomeWork.HW_19.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Demos.HackerU.HomeWork.HW_19.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("managers");
                });

            modelBuilder.Entity("EmployeeManager", b =>
                {
                    b.Property<int>("employeesListId")
                        .HasColumnType("int");

                    b.Property<int>("managerssId")
                        .HasColumnType("int");

                    b.HasKey("employeesListId", "managerssId");

                    b.HasIndex("managerssId");

                    b.ToTable("EmployeeManager");
                });

            modelBuilder.Entity("EmployeeManager", b =>
                {
                    b.HasOne("Demos.HackerU.HomeWork.HW_19.Employee", null)
                        .WithMany()
                        .HasForeignKey("employeesListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demos.HackerU.HomeWork.HW_19.Manager", null)
                        .WithMany()
                        .HasForeignKey("managerssId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
