﻿// <auto-generated />
using System;
using EfcDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfcDataAccess.Migrations
{
    [DbContext(typeof(DbContext))]
    partial class DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Domain.Models.CustomerInfo", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<char>("Tlf")
                        .HasColumnType("TEXT");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeliveryMethod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("PurchaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ExpireDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("IMGUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Shine")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surface")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.HasOne("Domain.Models.CustomerInfo", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.HasOne("Domain.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}