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

        public DbSet<Models.CategoriaComercial.Rubro> Rubros { get; set; }
        public DbSet<Models.CategoriaComercial.Subrubro> Subrubros { get; set; }
        public DbSet<Models.CategoriaComercial.Articulo> Articulos { get; set; }
        
        public DbSet<Models.ActividadFisica.TipoEjercicioFisico> TiposEjerciciosFisicos { get; set; }
        public DbSet<Models.ActividadFisica.EjercicioFisico> EjerciciosFisicos { get; set; }


        public DbSet<Models.GestionAlumno.Carrera> Carreras { get; set; }
        public DbSet<Models.GestionAlumno.Asignatura> Asignaturas { get; set; }
        public DbSet<Models.GestionAlumno.Alumno> Alumnos { get; set; }
        public DbSet<Models.GestionAlumno.Profesor> Profesores { get; set; }
        public DbSet<Models.GestionAlumno.ProfesorAsignatura> ProfesoresAsignaturas { get; set; }

        public DbSet<Models.GestionTarea.Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}