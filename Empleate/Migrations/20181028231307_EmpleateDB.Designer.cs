﻿// <auto-generated />
using System;
using Empleate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Empleate.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181028231307_EmpleateDB")]
    partial class EmpleateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Empleate.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos");

                    b.Property<string>("Correo");

                    b.Property<string>("Nombre");

                    b.Property<int>("ProfesionId");

                    b.Property<int>("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("ProfesionId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Empleate.Models.Experiencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId");

                    b.Property<string>("cargo");

                    b.Property<DateTime>("fin");

                    b.Property<DateTime>("inicio");

                    b.Property<string>("lugar");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Experiencias");
                });

            modelBuilder.Entity("Empleate.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId");

                    b.Property<string>("idioma");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Idiomas");
                });

            modelBuilder.Entity("Empleate.Models.Profesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("Profesiones");
                });

            modelBuilder.Entity("Empleate.Models.Titulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId");

                    b.Property<string>("descripcion");

                    b.Property<string>("grado");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Titulos");
                });

            modelBuilder.Entity("Empleate.Models.Empleado", b =>
                {
                    b.HasOne("Empleate.Models.Profesion", "Profesion")
                        .WithMany("Empleados")
                        .HasForeignKey("ProfesionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Empleate.Models.Experiencia", b =>
                {
                    b.HasOne("Empleate.Models.Profesion", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Empleate.Models.Language", b =>
                {
                    b.HasOne("Empleate.Models.Profesion", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Empleate.Models.Titulo", b =>
                {
                    b.HasOne("Empleate.Models.Profesion", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
