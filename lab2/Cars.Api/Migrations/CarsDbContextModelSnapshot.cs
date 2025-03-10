﻿// <auto-generated />
using System;
using Cars.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cars.Api.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    partial class CarsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cars.Api.Models.Domain.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                            Model = "Golf",
                            Name = "Volkswagen",
                            Price = 24000.0,
                            Year = 2018
                        },
                        new
                        {
                            Id = new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                            Model = "Panamera",
                            Name = "Porsche",
                            Price = 114000.0,
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                            Model = "Gulia",
                            Name = "Alfa Romeo",
                            Price = 31000.0,
                            Year = 2021
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
