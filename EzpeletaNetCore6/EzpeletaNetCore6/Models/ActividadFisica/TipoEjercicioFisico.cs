using System.ComponentModel.DataAnnotations;

namespace EzpeletaNetCore6.Models.ActividadFisica
{
    public class TipoEjercicioFisico
    {
        [Key]
        public int TipoEjercicioFisicoID { get; set; }
        public string? Descripcion { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<EjercicioFisico> EjerciciosFisicos { get; set; }
    }

    public class VistaTipoEjercicioFisico
    {
        public int TipoEjercicioFisicoID { get; set; }
        public string? Descripcion { get; set; }
        public int CantidadMinutos { get; set; }
    }
}