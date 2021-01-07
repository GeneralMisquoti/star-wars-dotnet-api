﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PL_452490_P2.Data;

namespace PL_452490_P2.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210101150718_AddForceUserTypeUnknown")]
    partial class AddForceUserTypeUnknown
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PL_452490_P2.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<long?>("MidichlorianCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("People");
                });
#pragma warning restore 612, 618
        }
    }
}