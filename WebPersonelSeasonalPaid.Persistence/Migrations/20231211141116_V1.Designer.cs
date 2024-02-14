﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebPersonelSeasonalPaid.Persistence;

#nullable disable

namespace WebPersonelSeasonalPaid.Persistence.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20231211141116_V1")]
    partial class V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebPersonelSeasonalPaid.Domain.Personel", b =>
                {
                    b.Property<Guid>("PersonelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonelId");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("WebPersonelSeasonalPaid.Domain.PersonelSeason", b =>
                {
                    b.Property<Guid>("PersonelSeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonelSeasonId");

                    b.HasIndex("PersonelId");

                    b.HasIndex("SeasonId");

                    b.ToTable("PersonelSeasons");
                });

            modelBuilder.Entity("WebPersonelSeasonalPaid.Domain.SalaryPrim", b =>
                {
                    b.Property<Guid>("SalaryPrimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrimAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SalaryPrimId");

                    b.HasIndex("PersonelId");

                    b.HasIndex("SeasonId");

                    b.ToTable("SalaryPrims");
                });

            modelBuilder.Entity("WebPersonelSeasonalPaid.Domain.Season", b =>
                {
                    b.Property<Guid>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SeasonEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SeasonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SeasonStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SeasonId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("WebPersonelSeasonalPaid.Domain.PersonelSeason", b =>
                {
                    b.HasOne("WebPersonelSeasonalPaid.Domain.Personel", "Personel")
                        .WithMany("ExistingSeason")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebPersonelSeasonalPaid.Domain.Season", "Season")
                        .WithMany("SeasonPersonel")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("WebPersonelSeasonalPaid.Domain.SalaryPrim", b =>
                {
                    b.HasOne("WebPersonelSeasonalPaid.Domain.Personel", "Personel")
                        .WithMany("SalaryPrim")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebPersonelSeasonalPaid.Domain.Season", "Season")
                        .WithMany("Paid")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("WebPersonelSeasonalPaid.Domain.Personel", b =>
                {
                    b.Navigation("ExistingSeason");

                    b.Navigation("SalaryPrim");
                });

            modelBuilder.Entity("WebPersonelSeasonalPaid.Domain.Season", b =>
                {
                    b.Navigation("Paid");

                    b.Navigation("SeasonPersonel");
                });
#pragma warning restore 612, 618
        }
    }
}
