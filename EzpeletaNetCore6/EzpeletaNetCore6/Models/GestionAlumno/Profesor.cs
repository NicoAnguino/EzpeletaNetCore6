using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzpeletaNetCore6.Models.GestionAlumno{

    public class Profesor{

        [Key]
        public int ProfesorID { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public DateTime FechaNacimiento {get; set; }

        [NotMapped]
        public string FechaNacimientoString { get { return FechaNacimiento.ToString("dd/MM/yyyy"); } }

        [NotMapped]
        public string FechaNacimientoStringInput { get { return FechaNacimiento.ToString("yyyy-MM-dd"); } }

        public int DNI {get; set; }

        public string? Direccion {get; set; }

        public string? Email {get; set; }

    }

    public class VistaProfesor{
         public int ProfesorID { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaNacimiento {get; set; }
        public string FechaNacimientoString {get; set; }
        public string FechaNacimientoStringInput {get; set; }
        public int DNI {get; set; }
        public string? Direccion {get; set; }
        public string? Email {get; set; }
    }

}