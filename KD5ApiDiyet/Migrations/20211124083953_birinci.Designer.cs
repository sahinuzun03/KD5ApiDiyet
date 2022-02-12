﻿// <auto-generated />
using System;
using KD5ApiDiyet.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KD5ApiDiyet.Migrations
{
    [DbContext(typeof(DiyetDBContext))]
    [Migration("20211124083953_birinci")]
    partial class birinci
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KD5ApiDiyet.Models.Ogun", b =>
                {
                    b.Property<DateTime>("Day")
                        .HasColumnType("date");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.HasKey("Day", "Hour");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("KD5ApiDiyet.Models.Yiyecek", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kalori")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Foods");

                    b.HasCheckConstraint("CHK_Yiyecek_KolariSifirdanBüyük", "[kalori]>0");
                });

            modelBuilder.Entity("OgunYiyecek", b =>
                {
                    b.Property<int>("FoodsID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MealsDay")
                        .HasColumnType("date");

                    b.Property<int>("MealsHour")
                        .HasColumnType("int");

                    b.HasKey("FoodsID", "MealsDay", "MealsHour");

                    b.HasIndex("MealsDay", "MealsHour");

                    b.ToTable("OgunYiyecek");
                });

            modelBuilder.Entity("OgunYiyecek", b =>
                {
                    b.HasOne("KD5ApiDiyet.Models.Yiyecek", null)
                        .WithMany()
                        .HasForeignKey("FoodsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KD5ApiDiyet.Models.Ogun", null)
                        .WithMany()
                        .HasForeignKey("MealsDay", "MealsHour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
