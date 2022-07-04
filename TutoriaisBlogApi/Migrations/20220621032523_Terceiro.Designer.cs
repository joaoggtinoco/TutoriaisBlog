﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutoriaisBlogApi.Context;

#nullable disable

namespace TutoriaisBlogApi.Migrations
{
  [DbContext(typeof(AppDbContext))]
  [Migration("20220621032523_Terceiro")]
  partial class Terceiro
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "6.0.5")
          .HasAnnotation("Relational:MaxIdentifierLength", 128);

      SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

      modelBuilder.Entity("TutoriaisBlogApi.Models.Postagem", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Conteudo")
                      .IsRequired()
                      .HasMaxLength(300)
                      .HasColumnType("nvarchar(300)");

            b.Property<int>("Usuario")
                      .HasColumnType("int");

            b.HasKey("Id");

            b.ToTable("Postagens");

            b.HasData(
                      new
                  {
                    Id = 1,
                    Conteudo = "Teste",
                    Usuario = 1
                  });
          });

      modelBuilder.Entity("TutoriaisBlogApi.Models.Usuario", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Email")
                      .IsRequired()
                      .HasMaxLength(100)
                      .HasColumnType("nvarchar(100)");

            b.Property<int>("Idade")
                      .HasColumnType("int");

            b.Property<string>("Nome")
                      .IsRequired()
                      .HasMaxLength(80)
                      .HasColumnType("nvarchar(80)");

            b.HasKey("Id");

            b.ToTable("Usuarios");
          });
#pragma warning restore 612, 618
    }
  }
}