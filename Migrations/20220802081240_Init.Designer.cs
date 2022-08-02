﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather.App.Domain.Cotext;

#nullable disable

namespace Weather.App.Migrations
{
    [DbContext(typeof(WeatherDbContext))]
    [Migration("20220802081240_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Weather.App.Domain.Model.FavoriteCities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityKey")
                        .HasColumnType("int");

                    b.Property<int>("CityName")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FavoriteCities", " dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
