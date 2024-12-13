﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using meditation.Infrastructure.DataStoreContext;

#nullable disable

namespace meditation.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20241213073307_Migrations")]
    partial class Migrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("meditation.Core.Models.Domain.MantraModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LordImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LordThreed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MantraAudio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MantraDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MantraImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MantraName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Mantras");
                });
#pragma warning restore 612, 618
        }
    }
}
