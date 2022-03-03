﻿// <auto-generated />
using System;
using GraphQL.WebApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GraphQL.WebApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220302181243_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GraphQL.WebApi.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("restaurant","food");
                });

            modelBuilder.Entity("GraphQL.WebApi.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("tag_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("tag_id");

                    b.ToTable("tag","food");
                });

            modelBuilder.Entity("GraphQL.WebApi.Models.Tag", b =>
                {
                    b.HasOne("GraphQL.WebApi.Models.Restaurant", null)
                        .WithMany("Tags")
                        .HasForeignKey("tag_id");
                });
#pragma warning restore 612, 618
        }
    }
}
