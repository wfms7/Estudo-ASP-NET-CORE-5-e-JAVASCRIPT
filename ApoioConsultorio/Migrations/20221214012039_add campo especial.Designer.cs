﻿// <auto-generated />
using ApoioConsultorio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApoioConsultorio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221214012039_add campo especial")]
    partial class addcampoespecial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("ApoioConsultorio.Models.ImpostoTaxa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ativo")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("imposto_nf")
                        .HasColumnType("decimal(4,4)");

                    b.Property<decimal>("taxa_Parcelado")
                        .HasColumnType("decimal(4,4)");

                    b.Property<decimal>("taxa_avista")
                        .HasColumnType("decimal(4,4)");

                    b.HasKey("Id");

                    b.ToTable("ImpostoTaxas");
                });

            modelBuilder.Entity("ApoioConsultorio.Models.Procedimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("EquipeCustos1")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("EquipeCustos2")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("EquipeCustos3")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("EquipeCustos4")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MaterialCustos_1")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MaterialCustos_2")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MaterialCustos_3")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MaterialCustos_4")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Material_1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Material_2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Material_3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Material_4")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorAvista")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorParcelado")
                        .HasColumnType("decimal(10,2)");

                    b.Property<bool>("especial")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Procedimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
