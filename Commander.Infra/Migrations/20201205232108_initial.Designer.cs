﻿// <auto-generated />
using Commander.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Commander.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201205232108_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Commander.Logic.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HowTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(5000)");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("nvarchar(5000)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(5000)");

                    b.HasKey("Id");

                    b.ToTable("Commands");
                });
#pragma warning restore 612, 618
        }
    }
}