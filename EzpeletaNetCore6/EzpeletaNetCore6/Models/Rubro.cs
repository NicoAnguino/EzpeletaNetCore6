using System.ComponentModel.DataAnnotations;

namespace EzpeletaNetCore6.Models
{
    public class Rubro
    {
        [Key]
        public int RubroID { get; set; }
        public string? Descripcion { get; set; }
        public bool Eliminado { get; set; }   

        public virtual ICollection<Subrubro> Subrubros { get; set; }
    }
}
