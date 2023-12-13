using System.ComponentModel.DataAnnotations;

namespace EzpeletaNetCore6.Models.Tenis
{
    public class Pique
    {
        [Key]
        public int PiqueID { get; set; }
        public decimal EjeX { get; set; }
        public decimal EjeY { get; set; }
        public decimal WidthDevice {get;set;}
        public decimal HeightDevice {get;set;}
    }
}