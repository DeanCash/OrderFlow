﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderFlow.Data;

#nullable disable

namespace OrderFlow.Migrations
{
    [DbContext(typeof(DatabaseDbContext))]
    [Migration("20240227205325_idwuuPLS")]
    partial class idwuuPLS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OrderFlow.Data.Tables.Consumable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Consumables");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ProcessedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.OrderedConsumable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConsumableId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumableId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderedConsumables");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.QR_Code", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("QR_Codes");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TableCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.Order", b =>
                {
                    b.HasOne("OrderFlow.Data.Tables.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.OrderedConsumable", b =>
                {
                    b.HasOne("OrderFlow.Data.Tables.Consumable", "Consumable")
                        .WithMany("OrderedConsumables")
                        .HasForeignKey("ConsumableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderFlow.Data.Tables.Order", "Order")
                        .WithMany("OrderedConsumables")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consumable");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.QR_Code", b =>
                {
                    b.HasOne("OrderFlow.Data.Tables.Table", "Table")
                        .WithOne("QRCode")
                        .HasForeignKey("OrderFlow.Data.Tables.QR_Code", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.Consumable", b =>
                {
                    b.Navigation("OrderedConsumables");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.Order", b =>
                {
                    b.Navigation("OrderedConsumables");
                });

            modelBuilder.Entity("OrderFlow.Data.Tables.Table", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("QRCode")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
