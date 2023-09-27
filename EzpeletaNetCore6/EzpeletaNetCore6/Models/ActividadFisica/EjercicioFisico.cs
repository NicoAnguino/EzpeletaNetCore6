using System.ComponentModel.DataAnnotations;

namespace EzpeletaNetCore6.Models.ActividadFisica
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

    public class VistaSumaEjercicioFisico
    {
        public string? TipoEjercicioNombre {get; set;}
        public int TotalidadMinutos {get; set; }
        public int TotalidadDiasConEjercicio {get;set;}
        public int TotalidadDiasSinEjercicio {get;set;}

        public List<VistaEjercicioFisico>? DiasEjercicios {get;set;}
    }

    public class VistaEjercicioFisico
    {   
        public int Anio {get; set; }  
        public string? Mes { get; set; }
        public int? Dia { get; set; }
        public int CantidadMinutos { get; set; }
    }
}