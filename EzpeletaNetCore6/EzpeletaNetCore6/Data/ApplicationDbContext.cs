using EzpeletaNetCore6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EzpeletaNetCore6.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Subrubro> Subrubros { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<TipoEjercicioFisico> TiposEjerciciosFisicos { get; set; }
        public DbSet<EjercicioFisico> EjerciciosFisicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}