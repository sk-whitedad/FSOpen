// <auto-generated />
using System;
using FishingSizes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FishingSizes.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20221108203249_Upd-04")]
    partial class Upd04
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("FishingSizes.CoordinatesForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Coord_X")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(100);

                    b.Property<int>("Coord_Y")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(100);

                    b.Property<string>("FormName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Hight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Widht")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CoordForms");
                });

            modelBuilder.Entity("FishingSizes.Print", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Exchange")
                        .HasColumnType("TEXT");

                    b.Property<string>("Flag")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ticker")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimePrint")
                        .HasColumnType("TEXT");

                    b.Property<int>("Vol")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Ticker");

                    b.ToTable("Prints");
                });
#pragma warning restore 612, 618
        }
    }
}
