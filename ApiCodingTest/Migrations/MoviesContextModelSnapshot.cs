﻿// <auto-generated />
using System;
using ApiCodingTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiCodingTest.Migrations
{
    [DbContext(typeof(MoviesContext))]
    partial class MoviesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ApiCodingTest.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ApiCodingTest.Models.MovieDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Actors")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Director")
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MetaScore")
                        .HasColumnType("text");

                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Plot")
                        .HasColumnType("text");

                    b.Property<string>("Poster")
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<string>("Provider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderId")
                        .HasColumnType("text");

                    b.Property<string>("Rated")
                        .HasColumnType("text");

                    b.Property<string>("Rating")
                        .HasColumnType("text");

                    b.Property<string>("Released")
                        .HasColumnType("text");

                    b.Property<string>("Runtime")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("Votes")
                        .HasColumnType("text");

                    b.Property<string>("Writer")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieDetails");
                });

            modelBuilder.Entity("ApiCodingTest.Models.MovieListStatus", b =>
                {
                    b.Property<string>("Provider")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Provider");

                    b.ToTable("MovieListStatuses");
                });

            modelBuilder.Entity("ApiCodingTest.Models.MovieDetail", b =>
                {
                    b.HasOne("ApiCodingTest.Models.Movie", "Movie")
                        .WithMany("MovieDetails")
                        .HasForeignKey("MovieId");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ApiCodingTest.Models.Movie", b =>
                {
                    b.Navigation("MovieDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
