﻿// <auto-generated />
using System;
using ISFitnessCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ISFitnessCenter.Migrations
{
    [DbContext(typeof(FitnessContext))]
    [Migration("20231210211131_End")]
    partial class End
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ISFitnessCenter.Models.Adress", b =>
                {
                    b.Property<int>("AdressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdressId"));

                    b.Property<string>("mainAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdressId");

                    b.ToTable("adresses");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<bool>("Aerobic")
                        .HasColumnType("bit");

                    b.Property<bool>("Dance")
                        .HasColumnType("bit");

                    b.Property<string>("FIOclient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pool")
                        .HasColumnType("bit");

                    b.Property<bool>("Ring")
                        .HasColumnType("bit");

                    b.Property<bool>("trampoline")
                        .HasColumnType("bit");

                    b.HasKey("ClientId");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<bool>("Ftiday")
                        .HasColumnType("bit");

                    b.Property<bool>("Mondeay")
                        .HasColumnType("bit");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<int>("TrenerId")
                        .HasColumnType("int");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.HasKey("ScheduleId");

                    b.HasIndex("TrenerId");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Specialtiy", b =>
                {
                    b.Property<int>("specialtiyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("specialtiyId"));

                    b.Property<int>("ZalsId")
                        .HasColumnType("int");

                    b.Property<int>("gruppa")
                        .HasColumnType("int");

                    b.Property<string>("specialityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("specialtiyId");

                    b.HasIndex("ZalsId");

                    b.ToTable("specialtiys");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Specialyty_Trener", b =>
                {
                    b.Property<int>("Specialyty_TrenerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Specialyty_TrenerId"));

                    b.Property<int>("TrenerId")
                        .HasColumnType("int");

                    b.Property<int>("specialtiyId")
                        .HasColumnType("int");

                    b.HasKey("Specialyty_TrenerId");

                    b.HasIndex("TrenerId");

                    b.HasIndex("specialtiyId");

                    b.ToTable("specialyty_Treners");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Time", b =>
                {
                    b.Property<int>("TimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeId"));

                    b.Property<string>("dateEnd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dateFirst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("shift")
                        .HasColumnType("int");

                    b.HasKey("TimeId");

                    b.ToTable("times");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Trener", b =>
                {
                    b.Property<int>("TrenerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrenerId"));

                    b.Property<int>("AdressTrenerAdressId")
                        .HasColumnType("int");

                    b.Property<string>("FIOtrener")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrenerId");

                    b.HasIndex("AdressTrenerAdressId");

                    b.ToTable("treners");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Trener_Client", b =>
                {
                    b.Property<int>("trener_ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trener_ClientId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.Property<int>("TrenerId")
                        .HasColumnType("int");

                    b.Property<int>("specialtiyId1")
                        .HasColumnType("int");

                    b.Property<int>("weekId")
                        .HasColumnType("int");

                    b.HasKey("trener_ClientId");

                    b.HasIndex("ClientId");

                    b.HasIndex("TimeId");

                    b.HasIndex("TrenerId");

                    b.HasIndex("specialtiyId1");

                    b.HasIndex("weekId");

                    b.ToTable("trener_Clients");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Week", b =>
                {
                    b.Property<int>("weekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("weekId"));

                    b.Property<string>("weekName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("weekId");

                    b.ToTable("weeks");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Zals", b =>
                {
                    b.Property<int>("ZalsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZalsId"));

                    b.Property<string>("ZalsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZalsId");

                    b.ToTable("zals");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Schedule", b =>
                {
                    b.HasOne("ISFitnessCenter.Models.Trener", "trenerId")
                        .WithMany()
                        .HasForeignKey("TrenerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trenerId");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Specialtiy", b =>
                {
                    b.HasOne("ISFitnessCenter.Models.Zals", "zalsId")
                        .WithMany()
                        .HasForeignKey("ZalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("zalsId");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Specialyty_Trener", b =>
                {
                    b.HasOne("ISFitnessCenter.Models.Trener", "trenerId")
                        .WithMany()
                        .HasForeignKey("TrenerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISFitnessCenter.Models.Specialtiy", "SpecialtiyId")
                        .WithMany()
                        .HasForeignKey("specialtiyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpecialtiyId");

                    b.Navigation("trenerId");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Trener", b =>
                {
                    b.HasOne("ISFitnessCenter.Models.Adress", "AdressTrener")
                        .WithMany()
                        .HasForeignKey("AdressTrenerAdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdressTrener");
                });

            modelBuilder.Entity("ISFitnessCenter.Models.Trener_Client", b =>
                {
                    b.HasOne("ISFitnessCenter.Models.Client", "clientID")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISFitnessCenter.Models.Time", "time")
                        .WithMany()
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISFitnessCenter.Models.Trener", "trenerID")
                        .WithMany()
                        .HasForeignKey("TrenerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISFitnessCenter.Models.Specialtiy", "specialtiyId")
                        .WithMany()
                        .HasForeignKey("specialtiyId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISFitnessCenter.Models.Week", "week")
                        .WithMany()
                        .HasForeignKey("weekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clientID");

                    b.Navigation("specialtiyId");

                    b.Navigation("time");

                    b.Navigation("trenerID");

                    b.Navigation("week");
                });
#pragma warning restore 612, 618
        }
    }
}
