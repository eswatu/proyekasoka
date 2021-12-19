﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using serverside.Data;

namespace serverside.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211217132542_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("serverside.Core.Models.JobTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Laporan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TrackTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JobTracks");
                });

            modelBuilder.Entity("serverside.Core.Models.Joborder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdKoordinator")
                        .HasColumnType("int");

                    b.Property<int?>("KoordinatorId")
                        .HasColumnType("int");

                    b.Property<string>("NamaKlien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorSurat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TanggalSurat")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KoordinatorId");

                    b.ToTable("Joborders");
                });

            modelBuilder.Entity("serverside.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("serverside.Core.Models.Joborder", b =>
                {
                    b.HasOne("serverside.Core.Models.User", "Koordinator")
                        .WithMany()
                        .HasForeignKey("KoordinatorId");

                    b.Navigation("Koordinator");
                });
#pragma warning restore 612, 618
        }
    }
}
