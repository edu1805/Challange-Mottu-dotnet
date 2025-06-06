﻿// <auto-generated />
using System;
using Cp2WebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cp2WebApplication.Migrations
{
    [DbContext(typeof(Cp2Context))]
    [Migration("20250517034408_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cp2WebApplication.Domain.Entities.Moto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("PLACA");

                    b.Property<string>("Posicao")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("STATUS");

                    b.Property<DateTime>("UltimaAtualizacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("ULTIMA_ATUALIZACAO");

                    b.HasKey("Id");

                    b.ToTable("T_MOTOS", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
