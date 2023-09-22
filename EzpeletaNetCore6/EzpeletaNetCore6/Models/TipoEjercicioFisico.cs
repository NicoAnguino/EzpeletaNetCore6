using System.ComponentModel.DataAnnotations;

namespace EzpeletaNetCore6.Models
{
    public class TipoEjercicioFisico
    {
        [Key]
        public int TipoEjercicioFisicoID { get; set; }
        public string? Descripcion { get; set; }
        public bool Eliminado { get; set; }   

        public virtual ICollection<EjercicioFisico> EjerciciosFisicos { get; set; }
    }
}