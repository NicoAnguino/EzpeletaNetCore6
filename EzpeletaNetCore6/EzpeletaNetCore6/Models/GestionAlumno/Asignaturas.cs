using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzpeletaNetCore6.Models.GestionAlumno{

    public class Asignatura{
        [Key]
        public int AsignaturaID { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public int CarreraID {get; set; }
        public virtual Carrera? Carrera { get; set; }
    }

    public class VistaAsignatura {
        public int AsignaturaID { get; set; }
        public string? NombreAsignatura { get; set; }
        public int CarreraID {get; set; }
        public string? NombreCarrera {get; set; }
    }

}