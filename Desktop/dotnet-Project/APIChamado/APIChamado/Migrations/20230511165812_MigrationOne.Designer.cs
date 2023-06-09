﻿// <auto-generated />
using System;
using APIChamado.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIChamado.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230511165812_MigrationOne")]
    partial class MigrationOne
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APIChamado.Models.Chamado", b =>
                {
                    b.Property<int>("ChamadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ChamadoClosingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ChamadoDescription")
                        .HasColumnType("int");

                    b.Property<string>("ChamadoImage")
                        .HasColumnType("longtext");

                    b.Property<string>("ChamadoNumber")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ChamadoOpenDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ChamadoTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ChamadoUpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SolicitanteId")
                        .HasColumnType("int");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("int");

                    b.HasKey("ChamadoId");

                    b.HasIndex("SolicitanteId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Chamados");
                });

            modelBuilder.Entity("APIChamado.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChamadoId")
                        .HasColumnType("int");

                    b.Property<string>("ComentarioComent")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("ComentarioDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ComentarioId");

                    b.HasIndex("ChamadoId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("APIChamado.Models.Solicitante", b =>
                {
                    b.Property<int>("SolicitanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SolicitanteContact")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SolicitanteDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SolicitanteEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SolicitanteManager")
                        .HasColumnType("longtext");

                    b.Property<string>("SolicitanteName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("SolicitanteOffice")
                        .HasColumnType("longtext");

                    b.Property<string>("SolicitantePassWord")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("SolicitanteStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("SolicitanteId");

                    b.ToTable("Solicitante");
                });

            modelBuilder.Entity("APIChamado.Models.Tecnico", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TecnicoContact")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TecnicoDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TecnicoEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TecnicoManager")
                        .HasColumnType("longtext");

                    b.Property<string>("TecnicoName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("TecnicoOffice")
                        .HasColumnType("longtext");

                    b.Property<string>("TecnicoPassWord")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("TecnicoStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("TecnicoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("APIChamado.Models.Chamado", b =>
                {
                    b.HasOne("APIChamado.Models.Solicitante", "Solicitante")
                        .WithMany("Chamados")
                        .HasForeignKey("SolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIChamado.Models.Tecnico", "Tecnico")
                        .WithMany("Chamados")
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitante");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("APIChamado.Models.Comentario", b =>
                {
                    b.HasOne("APIChamado.Models.Chamado", "Chamado")
                        .WithMany("Comentarios")
                        .HasForeignKey("ChamadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chamado");
                });

            modelBuilder.Entity("APIChamado.Models.Chamado", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("APIChamado.Models.Solicitante", b =>
                {
                    b.Navigation("Chamados");
                });

            modelBuilder.Entity("APIChamado.Models.Tecnico", b =>
                {
                    b.Navigation("Chamados");
                });
#pragma warning restore 612, 618
        }
    }
}
