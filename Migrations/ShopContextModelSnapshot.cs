﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebBerberUygulamasi.Models;

#nullable disable

namespace WebBerberUygulamasi.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebBerberUygulamasi.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<bool>("AppointmentConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("ServiceID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ServiceID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("UserID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("UserID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ServicePrice")
                        .HasColumnType("float");

                    b.Property<int>("ServiceTime")
                        .HasColumnType("int");

                    b.HasKey("ServiceID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<string>("UserSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Appointment", b =>
                {
                    b.HasOne("WebBerberUygulamasi.Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBerberUygulamasi.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Customer", b =>
                {
                    b.HasOne("WebBerberUygulamasi.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Employee", b =>
                {
                    b.HasOne("WebBerberUygulamasi.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Service", b =>
                {
                    b.HasOne("WebBerberUygulamasi.Models.Employee", "Employee")
                        .WithMany("Services")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("WebBerberUygulamasi.Models.Employee", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}