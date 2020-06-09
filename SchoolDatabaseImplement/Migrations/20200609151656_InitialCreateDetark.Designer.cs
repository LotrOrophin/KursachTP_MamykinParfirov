﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolDatabaseImplement;

namespace SchoolDatabaseImplement.Migrations
{
    [DbContext(typeof(SchoolDatabase))]
    [Migration("20200609151656_InitialCreateDetark")]
    partial class InitialCreateDetark
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Circle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CircleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Circles");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.CircleSchoolSupplie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CircleId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("SchoolSupplieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CircleId");

                    b.HasIndex("SchoolSupplieId");

                    b.ToTable("CircleSchoolSupplies");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CircleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CircleId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.RequestSchoolSupplie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CircleId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<bool>("Inres")
                        .HasColumnType("bit");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("SchoolSupplieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CircleId");

                    b.HasIndex("RequestId");

                    b.HasIndex("SchoolSupplieId");

                    b.ToTable("RequestsSchoolSupplies");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.SchoolSupplie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SchoolSupplieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SchoolSupplies");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.WareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WareHouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("WareHouses");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.WareHouseSchoolSupplie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Free")
                        .HasColumnType("int");

                    b.Property<int>("IsReserved")
                        .HasColumnType("int");

                    b.Property<int>("SchoolSupplieId")
                        .HasColumnType("int");

                    b.Property<int>("WareHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolSupplieId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("WareHouseSchoolSupplies");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.CircleSchoolSupplie", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Circle", "Circle")
                        .WithMany("CircleSchoolSupplies")
                        .HasForeignKey("CircleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDatabaseImplement.Models.SchoolSupplie", "SchoolSupplie")
                        .WithMany()
                        .HasForeignKey("SchoolSupplieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Circle", "Circle")
                        .WithMany()
                        .HasForeignKey("CircleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Request", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Supplier", "Supplier")
                        .WithMany("Requests")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.RequestSchoolSupplie", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Circle", null)
                        .WithMany("RequestSchoolSupplies")
                        .HasForeignKey("CircleId");

                    b.HasOne("SchoolDatabaseImplement.Models.Request", "Request")
                        .WithMany("RequestFoods")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDatabaseImplement.Models.SchoolSupplie", "SchoolSupplie")
                        .WithMany("RequestSchoolSupplie")
                        .HasForeignKey("SchoolSupplieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.WareHouse", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Supplier", "Supplier")
                        .WithMany("WareHouses")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.WareHouseSchoolSupplie", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.SchoolSupplie", "SchoolSupplie")
                        .WithMany("WareHouseSchoolSupplies")
                        .HasForeignKey("SchoolSupplieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDatabaseImplement.Models.WareHouse", "WareHouse")
                        .WithMany("WareHouseSchoolSupplies")
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
