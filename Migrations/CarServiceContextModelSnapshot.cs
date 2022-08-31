﻿// <auto-generated />
using System;
using CarService.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarService.Migrations
{
    [DbContext(typeof(CarServiceContext))]
    partial class CarServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarService.Models.Entities.CarEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BRAND");

                    b.Property<float?>("EngineVolume")
                        .HasColumnType("real")
                        .HasColumnName("EMGINE_VOLUME");

                    b.Property<int?>("Mileage")
                        .HasColumnType("int")
                        .HasColumnName("MILEAGE");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MODEL");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint")
                        .HasColumnName("ID_OWNER");

                    b.Property<string>("StateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("STATE_NUMBER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("CARS");
                });

            modelBuilder.Entity("CarService.Models.Entities.CarOwnerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ADDRESS");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PASSPORT_NUMBER");

                    b.Property<string>("PassportSeries")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PASSPORT_SERIES");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PHONE_NUMBER");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SURNAME");

                    b.Property<string>("ThirdName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("THIRDNAME");

                    b.HasKey("Id");

                    b.ToTable("CAR_OWNERS");
                });

            modelBuilder.Entity("CarService.Models.Entities.MasterEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PHONE_NUMBER");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SURNAME");

                    b.Property<string>("ThirdName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("THIRDNAME");

                    b.Property<int>("WorkExperience")
                        .HasColumnType("int")
                        .HasColumnName("WORK_EXPERIENCE");

                    b.HasKey("Id");

                    b.ToTable("MASTERS");
                });

            modelBuilder.Entity("CarService.Models.Entities.RepairServiceEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CarId")
                        .HasColumnType("bigint")
                        .HasColumnName("ID_CAR");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("COMPLETION_DATE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<long>("MasterId")
                        .HasColumnType("bigint")
                        .HasColumnName("ID_MASTER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("START_DATE");

                    b.Property<decimal?>("WorkPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("WORK_PRICE");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("MasterId");

                    b.ToTable("REPAIR_SERVICES");
                });

            modelBuilder.Entity("CarService.Models.Entities.CarEntity", b =>
                {
                    b.HasOne("CarService.Models.Entities.CarOwnerEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarService.Models.Entities.RepairServiceEntity", b =>
                {
                    b.HasOne("CarService.Models.Entities.CarEntity", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarService.Models.Entities.MasterEntity", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Master");
                });
#pragma warning restore 612, 618
        }
    }
}
