﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewLab1_MinimalAPI.Data;

#nullable disable

namespace NewLab1_MinimalAPI.Migrations
{
    [DbContext(typeof(LibDbContext))]
    partial class LibDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewLab1_MinimalAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvaliabel")
                        .HasColumnType("bit");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Jules Verne",
                            Genre = "Äventyrsroman",
                            IsAvaliabel = true,
                            ReleaseYear = 1873,
                            Title = "Around the World in Eighty Days"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Jules Verne",
                            Genre = "Science fiction",
                            IsAvaliabel = true,
                            ReleaseYear = 1870,
                            Title = "Twenty Thousand Leagues Under the Seas"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Alexandre Dumas",
                            Genre = "Historical novel",
                            IsAvaliabel = false,
                            ReleaseYear = 1995,
                            Title = "The Count of Monte Cristo"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Richard Dawkins",
                            Genre = "Fact",
                            IsAvaliabel = true,
                            ReleaseYear = 1995,
                            Title = "The God Delusion"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Unknown / King James Bible",
                            Genre = "Religious Text",
                            IsAvaliabel = true,
                            ReleaseYear = 0,
                            Title = "The Holy Bible"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
