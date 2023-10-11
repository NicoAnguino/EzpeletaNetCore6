using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzpeletaNetCore6.Models.GestionAlumno{

    public class Carrera{
        [Key]
        public int CarreraID { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public string? DuracionCarrera {get; set; }
        public virtual ICollection<Alumno>? Alumnos { get; set; }
        public virtual ICollection<Asignatura>? Asignaturas { get; set; }
    }

}