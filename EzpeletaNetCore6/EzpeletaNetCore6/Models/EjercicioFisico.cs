using System.ComponentModel.DataAnnotations;

namespace EzpeletaNetCore6.Models
{
    public class EjercicioFisico
    {
        [Key]
        public int EjercicioFisicoID { get; set; }

        public int TipoEjercicioFisicoID { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadMinutos { get; set; }

        public virtual TipoEjercicioFisico TipoEjercicioFisico { get; set; }
    }

    public class VistaEjercicioFisico
    {
        public int EjercicioFisicoID { get; set; }
        public int? TipoEjercicioFisicoID { get; set; }
        public string? TipoEjercicioFisicoNombre { get; set; }  
        public string? Mes { get; set; }
        public int? Dia { get; set; }
        public int CantidadMinutos { get; set; }
    }
}