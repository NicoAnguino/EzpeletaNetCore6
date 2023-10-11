using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzpeletaNetCore6.Models.GestionAlumno{

    public class ProfesorAsignatura{

        [Key]
        public int ProfesorAsignaturaID { get; set; }

        public int ProfesorID { get; set; }

        public int AsignaturaID { get; set; }

    }

}