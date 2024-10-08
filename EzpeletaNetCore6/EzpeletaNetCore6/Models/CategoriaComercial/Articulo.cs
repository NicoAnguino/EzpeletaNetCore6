﻿using System.ComponentModel.DataAnnotations;

namespace EzpeletaNetCore6.Models.CategoriaComercial
{
    public class Articulo
    {
        [Key]
        public int ArticuloID { get; set; }

        public string? Descripcion { get; set; }
        public DateTime UltAct { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioVenta { get; set; }
        public int SubrubroID { get; set; }
        public bool Eliminado { get; set; }

        public byte[]? Img { get; set; }
        public string? TipoImg { get; set; }

        public virtual Subrubro Subrubro { get; set; }
    }

    public class VistaArticulo
    {
        public int ArticuloID { get; set; }
        public string? Descripcion { get; set; }
        public string? SubrubroNombre { get; set; }
        public string? RubroNombre { get; set; }
        public int RubroID { get; set; }
        public int SubrubroID { get; set; }
        public DateTime UltAct { get; set; }
        public string? UltActString { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Eliminado { get; set; }
        public string? ImagenBase64 { get; set; }
        public string? TipoImg { get; set; }
    }
}
