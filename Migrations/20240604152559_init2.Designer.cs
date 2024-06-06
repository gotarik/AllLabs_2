﻿// <auto-generated />
using System;
using AllLabs_2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllLabs_2.Migrations
{
    [DbContext(typeof(carsystemDBcontext))]
    [Migration("20240604152559_init2")]
    partial class init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdministratorIdPK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RentalSystemIdFK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RentalSystemIdFK");

                    b.ToTable("Administrators");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<Guid>("CarIdPK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RentalSystemIdFK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CarIdPK");

                    b.HasIndex("RentalSystemIdFK");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientIdPk")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RentalSystemIdFK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RentalSystemIdFK");

                    b.ToTable("Clients");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<Guid>("OrderIdPK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarIdFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientIdFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DamageDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectionReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentalPeriod")
                        .HasColumnType("int");

                    b.Property<Guid?>("RentalSystemIdPK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderIdPK");

                    b.HasIndex("CarIdFK")
                        .IsUnique();

                    b.HasIndex("ClientIdFK");

                    b.HasIndex("RentalSystemIdPK");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RentalSystem", b =>
                {
                    b.Property<Guid>("RentalSystemIdPK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RentalSystemIdPK");

                    b.ToTable("RentalSystems");
                });

            modelBuilder.Entity("Administrator", b =>
                {
                    b.HasOne("RentalSystem", "RentalSystems")
                        .WithMany("Administrators")
                        .HasForeignKey("RentalSystemIdFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RentalSystems");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.HasOne("RentalSystem", "RentalSystems")
                        .WithMany("Cars")
                        .HasForeignKey("RentalSystemIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentalSystems");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.HasOne("RentalSystem", "RentalSystems")
                        .WithMany("Clients")
                        .HasForeignKey("RentalSystemIdFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RentalSystems");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("Car", "Car")
                        .WithOne("Order")
                        .HasForeignKey("Order", "CarIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalSystem", null)
                        .WithMany("Orders")
                        .HasForeignKey("RentalSystemIdPK");

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RentalSystem", b =>
                {
                    b.Navigation("Administrators");

                    b.Navigation("Cars");

                    b.Navigation("Clients");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
