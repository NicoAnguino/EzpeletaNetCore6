﻿// <auto-generated />
using System;
using EzpeletaNetCore6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EzpeletaNetCore6.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231213131239_CrearTablaPiques")]
    partial class CrearTablaPiques
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EzpeletaNetCore6.Models.ActividadFisica.EjercicioFisico", b =>
                {
                    b.Property<int>("EjercicioFisicoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EjercicioFisicoID"), 1L, 1);

                    b.Property<int>("CantidadMinutos")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoEjercicioFisicoID")
                        .HasColumnType("int");

                    b.HasKey("EjercicioFisicoID");

                    b.HasIndex("TipoEjercicioFisicoID");

                    b.ToTable("EjerciciosFisicos");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.ActividadFisica.TipoEjercicioFisico", b =>
                {
                    b.Property<int>("TipoEjercicioFisicoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoEjercicioFisicoID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("TipoEjercicioFisicoID");

                    b.ToTable("TiposEjerciciosFisicos");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.CategoriaComercial.Articulo", b =>
                {
                    b.Property<int>("ArticuloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Img")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("PorcentajeGanancia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecioCosto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubrubroID")
                        .HasColumnType("int");

                    b.Property<string>("TipoImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltAct")
                        .HasColumnType("datetime2");

                    b.HasKey("ArticuloID");

                    b.HasIndex("SubrubroID");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.CategoriaComercial.Rubro", b =>
                {
                    b.Property<int>("RubroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RubroID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("RubroID");

                    b.ToTable("Rubros");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.CategoriaComercial.Subrubro", b =>
                {
                    b.Property<int>("SubrubroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubrubroID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int>("RubroID")
                        .HasColumnType("int");

                    b.HasKey("SubrubroID");

                    b.HasIndex("RubroID");

                    b.ToTable("Subrubros");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionAlumno.Alumno", b =>
                {
                    b.Property<int>("AlumnoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlumnoID"), 1L, 1);

                    b.Property<int>("CarreraID")
                        .HasColumnType("int");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlumnoID");

                    b.HasIndex("CarreraID");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionAlumno.Asignatura", b =>
                {
                    b.Property<int>("AsignaturaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsignaturaID"), 1L, 1);

                    b.Property<int>("CarreraID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AsignaturaID");

                    b.HasIndex("CarreraID");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionAlumno.Carrera", b =>
                {
                    b.Property<int>("CarreraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarreraID"), 1L, 1);

                    b.Property<string>("DuracionCarrera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarreraID");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionAlumno.Profesor", b =>
                {
                    b.Property<int>("ProfesorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfesorID"), 1L, 1);

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfesorID");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionAlumno.ProfesorAsignatura", b =>
                {
                    b.Property<int>("ProfesorAsignaturaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfesorAsignaturaID"), 1L, 1);

                    b.Property<int>("AsignaturaID")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorID")
                        .HasColumnType("int");

                    b.HasKey("ProfesorAsignaturaID");

                    b.ToTable("ProfesoresAsignaturas");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionTarea.Tarea", b =>
                {
                    b.Property<int>("TareaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TareaID"), 1L, 1);

                    b.Property<int?>("AsignaturaID")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.Property<bool>("Realizada")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TareaID");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.Tenis.Pique", b =>
                {
                    b.Property<int>("PiqueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PiqueID"), 1L, 1);

                    b.Property<decimal>("EjeX")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EjeY")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HeightDevice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WidthDevice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PiqueID");

                    b.ToTable("Piques");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a8ca83f4-7dfb-472a-9f6c-dc6b1fb5192b",
                            ConcurrencyStamp = "f3f42944-6e3f-40d7-b43e-db0a03e96eea",
                            Name = "Superusuario",
                            NormalizedName = "SUPERUSUARIO"
                        },
                        new
                        {
                            Id = "ed29929a-e87c-48d1-9523-7e8787b4b8bc",
                            ConcurrencyStamp = "5f450e5f-be3d-4747-8e46-671c4dd9b928",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "c8ec4a86-5fb3-49d9-8c52-760b6be769bf",
                            RoleId = "a8ca83f4-7dfb-472a-9f6c-dc6b1fb5192b"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "c8ec4a86-5fb3-49d9-8c52-760b6be769bf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5a2ea0cc-144e-4430-b4b3-97f3f7429203",
                            Email = "superusuario@appezpeleta.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERUSUARIO@APPEZPELETA.COM",
                            NormalizedUserName = "SUPERUSUARIO@APPEZPELETA.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEI5HLXox35M5PJUs/RkLBNIfRMe3FqTsuWsMtrF5EcT7aie7RWrVDIXktaIep9xiGA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1d5ba48f-556e-44f1-bea6-bea44a9bcd92",
                            TwoFactorEnabled = false,
                            UserName = "superusuario@appezpeleta.com"
                        });
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.ActividadFisica.EjercicioFisico", b =>
                {
                    b.HasOne("EzpeletaNetCore6.Models.ActividadFisica.TipoEjercicioFisico", "TipoEjercicioFisico")
                        .WithMany("EjerciciosFisicos")
                        .HasForeignKey("TipoEjercicioFisicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoEjercicioFisico");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.CategoriaComercial.Articulo", b =>
                {
                    b.HasOne("EzpeletaNetCore6.Models.CategoriaComercial.Subrubro", "Subrubro")
                        .WithMany("Articulos")
                        .HasForeignKey("SubrubroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subrubro");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.CategoriaComercial.Subrubro", b =>
                {
                    b.HasOne("EzpeletaNetCore6.Models.CategoriaComercial.Rubro", "Rubro")
                        .WithMany("Subrubros")
                        .HasForeignKey("RubroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rubro");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionAlumno.Alumno", b =>
                {
                    b.HasOne("EzpeletaNetCore6.Models.GestionAlumno.Carrera", "Carrera")
                        .WithMany("Alumnos")
                        .HasForeignKey("CarreraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionAlumno.Asignatura", b =>
                {
                    b.HasOne("EzpeletaNetCore6.Models.GestionAlumno.Carrera", "Carrera")
                        .WithMany("Asignaturas")
                        .HasForeignKey("CarreraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.ActividadFisica.TipoEjercicioFisico", b =>
                {
                    b.Navigation("EjerciciosFisicos");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.CategoriaComercial.Rubro", b =>
                {
                    b.Navigation("Subrubros");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.CategoriaComercial.Subrubro", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionAlumno.Carrera", b =>
                {
                    b.Navigation("Alumnos");

                    b.Navigation("Asignaturas");
                });
#pragma warning restore 612, 618
        }
    }
}
