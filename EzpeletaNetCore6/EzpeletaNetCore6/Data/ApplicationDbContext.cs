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

        public DbSet<EzpeletaNetCore6.Models.Rubro> Rubros { get; set; }

        public DbSet<EzpeletaNetCore6.Models.Subrubro> Subrubros { get; set; }

        public DbSet<EzpeletaNetCore6.Models.Articulo> Articulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}