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
    [Migration("20230922173551_GestionTareas")]
    partial class GestionTareas
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

            modelBuilder.Entity("EzpeletaNetCore6.Models.GestionTarea.Tarea", b =>
                {
                    b.Property<int>("TareaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TareaID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.Property<bool>("Realizada")
                        .HasColumnType("bit");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TareaID");

                    b.ToTable("Tareas");
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
                            Id = "23c2dfa5-6436-4fbd-bdbc-387a24c45dff",
                            ConcurrencyStamp = "749cc7d3-84d0-4865-908d-70b35b033811",
                            Name = "Superusuario",
                            NormalizedName = "SUPERUSUARIO"
                        },
                        new
                        {
                            Id = "315c702c-88e2-4a62-a43e-7cf4d4fe5407",
                            ConcurrencyStamp = "06b6bfea-5468-4064-ba32-5d4803be907f",
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
                            UserId = "619c4dcc-b7fc-4a19-869d-e8be2f3361be",
                            RoleId = "23c2dfa5-6436-4fbd-bdbc-387a24c45dff"
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
                            Id = "619c4dcc-b7fc-4a19-869d-e8be2f3361be",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7db4eaba-94ef-439b-a40c-756fd012b68d",
                            Email = "superusuario@appezpeleta.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERUSUARIO@APPEZPELETA.COM",
                            NormalizedUserName = "SUPERUSUARIO@APPEZPELETA.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECCk8hMV99bd9QWOHo2GfE0aZGm0QVKbAsyAwW13dM9jkOCAWK6wT3pVjExBZD/dUw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "246d3cb6-4226-4e89-8f3f-4bfefdb0adf7",
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
#pragma warning restore 612, 618
        }
    }
}