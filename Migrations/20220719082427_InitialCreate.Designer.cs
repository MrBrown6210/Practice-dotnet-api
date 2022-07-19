﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using travel_api.Module.Stores;

#nullable disable

namespace travel_api.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20220719082427_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("travel_api.Module.Stores.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StoreId"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("travel_api.Module.Stores.StoreProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("ProductId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("travel_api.Module.Stores.StoreProductItem", b =>
                {
                    b.Property<int>("StoreProductItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StoreProductItemId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("StoreId")
                        .HasColumnType("integer");

                    b.HasKey("StoreProductItemId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreProductItems");
                });

            modelBuilder.Entity("travel_api.Module.Stores.StoreProductItem", b =>
                {
                    b.HasOne("travel_api.Module.Stores.StoreProduct", "product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("travel_api.Module.Stores.Store", null)
                        .WithMany("ProductItems")
                        .HasForeignKey("StoreId");

                    b.Navigation("product");
                });

            modelBuilder.Entity("travel_api.Module.Stores.Store", b =>
                {
                    b.Navigation("ProductItems");
                });
#pragma warning restore 612, 618
        }
    }
}
