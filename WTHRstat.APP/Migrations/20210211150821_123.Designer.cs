﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WTHRstat.APP.EntityFramework;

namespace WTHRstat.APP.Migrations
{
    [DbContext(typeof(WTHRstatDBContext))]
    [Migration("20210211150821_123")]
    partial class _123
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WTHRstat.APP.Models.EmissionERD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<int>("Source_Id")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Emissions");
                });

            modelBuilder.Entity("WTHRstat.APP.Models.SourceERD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("Emission_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Emission_Id")
                        .IsUnique();

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("WTHRstat.APP.Models.SourceERD", b =>
                {
                    b.HasOne("WTHRstat.APP.Models.EmissionERD", "Emission")
                        .WithOne("Source")
                        .HasForeignKey("WTHRstat.APP.Models.SourceERD", "Emission_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
