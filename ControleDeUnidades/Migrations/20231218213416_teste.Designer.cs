﻿// <auto-generated />
using System;
using ControleDeContatos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ControleDeContatos.Migrations
{
    [DbContext(typeof(BancoContent))]
    [Migration("20231218213416_teste")]
    partial class teste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ControleDeContatos.Models.ColaboradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("ControleDeContatos.Models.ContatoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("ControleDeContatos.Models.UnidadeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("ControleDeContatos.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ControleDeContatos.Models.ColaboradorModel", b =>
                {
                    b.HasOne("ControleDeContatos.Models.UnidadeModel", "Unidade")
                        .WithMany("Colaboradores")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("ControleDeContatos.Models.ContatoModel", b =>
                {
                    b.HasOne("ControleDeContatos.Models.UsuarioModel", "Usuario")
                        .WithMany("Contatos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ControleDeContatos.Models.UnidadeModel", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("ControleDeContatos.Models.UsuarioModel", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}