using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzpeletaNetCore6.Models.GestionTarea
{
    public class Tarea
    {
        [Key]
        public int TareaID { get; set; }
        public DateTime Fecha { get; set; }
        
        [NotMapped]
        public string FechaString {get { return Fecha.ToString("dd/MM/yyyy"); } }
        
        [NotMapped]
        public string FechaStringInput {get { return Fecha.ToString("yyyy-MM-dd"); } }

        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        [NotMapped]
        public string FechaVencimientoString { get { return FechaVencimiento.ToString("dd/MM/yyyy"); } }

        [NotMapped]
        public string FechaVencimientoStringInput { get { return FechaVencimiento.ToString("yyyy-MM-dd"); } }

        public Prioridad Prioridad { get; set; }

        [NotMapped]
        public string PrioridadString {get { return Prioridad.ToString(); } }
        
        public bool Realizada { get; set; }
        public int? AsignaturaID { get; set; }
        public string? UsuarioID { get; set; }
    }

    public enum Prioridad
    {
        Baja = 1,
        Media,
        Alta
    }

}
