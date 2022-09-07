using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EzpeletaNetCore6.Controllers
{
    //Add-Migration InitialCreated
    //Update-Database
    //[Authorize]
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //BUSCAMOS LOS ARTICULOS DE LA TABLA EN BD
            //var articulos = db.Articulos.ToList();

            //var articulosID = db.Articulos.Where(p => p.PrecioVenta > 10).Select(p => p.ArticuloID).ToList();

            //var cantidadArticulos = db.Articulos.Where(p => p.PrecioVenta > 10).Count();

            //string descripcion = null;

            //descripcion = descripcion.Trim();

            ////SI NO EXISTE NINGUN ELEMENTO QUE CUMPLA ESA CONDICION.. NO FUNCIONA EL PROYECTO
            //var primerRegistro = db.Articulos.Where(p => p.PrecioVenta > 10).First();
            //var primerRegistroOVacio = db.Articulos.Where(p => p.PrecioVenta > 10).FirstOrDefault();

            //var unRegistro = db.Articulos.Where(p => p.PrecioVenta > 10).Single();
            //var unRegistroOVacio = db.Articulos.Where(p => p.PrecioVenta > 10).SingleOrDefault();

            var rubros = _context.Rubros.Where(p => p.Eliminado == false).ToList();
            rubros.Add(new Rubro { RubroID = 0, Descripcion = "[SELECCIONE UN RUBRO]" });
            ViewBag.RubroID = new SelectList(rubros.OrderBy(p => p.Descripcion), "RubroID", "Descripcion");

            List<Subrubro> subrubros = new List<Subrubro>();
            subrubros.Add(new Subrubro { SubrubroID = 0, Descripcion = "[SELECCIONE UN RUBRO]" });
            ViewBag.SubrubroID = new SelectList(subrubros.OrderBy(p => p.Descripcion), "SubrubroID", "Descripcion");


            return View();
        }


        public JsonResult BuscarArticulos()
        {
            var articulos = _context.Articulos.Include(p => p.Subrubro.Rubro).Where(p => p.PrecioVenta > 10).ToList();

            //CREAMOS EL OBJETO DE VISTA EN FORMA DE LISTADO
            List<VistaArticulo> articulosMostrar = new List<VistaArticulo>();

            foreach (var articulo in articulos)
            {
                var articuloMostrar = new VistaArticulo
                {
                    ArticuloID = articulo.ArticuloID,
                    Descripcion = articulo.Descripcion,
                    SubrubroNombre = articulo.Subrubro.Descripcion,
                    RubroNombre = articulo.Subrubro.Rubro.Descripcion,
                    UltAct = articulo.UltAct,
                    UltActString = articulo.UltAct.ToString("dd/MM/yyyy"),
                    PrecioCosto = articulo.PrecioCosto,
                    PorcentajeGanancia = articulo.PorcentajeGanancia,
                    PrecioVenta = articulo.PrecioVenta
                };
                articulosMostrar.Add(articuloMostrar);
            }

            return Json(articulosMostrar);
        }


        public JsonResult GuardarArticulo(int ArticuloID, string Descripcion, int SubrubroID, string Costo, string Ganancia, string Venta)
        {
            //CONFIGURACIÓN DE CULTURA ESPAÑOL ARGENTINA
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            //PUNTO COMO DECIMAL

            Costo = Costo.Replace(".", ",");
            Ganancia = Ganancia.Replace(".", ",");
            Venta = Venta.Replace(".", ",");
            decimal costo = Convert.ToDecimal(Costo);
            decimal ganancia = Convert.ToDecimal(Ganancia);
            decimal venta = Convert.ToDecimal(Venta);

            if (ArticuloID == 0)
            {
                var articuloCrear = new Articulo
                {
                    Descripcion = Descripcion,
                    SubrubroID = SubrubroID,
                    PrecioCosto = costo,
                    PorcentajeGanancia = ganancia,
                    PrecioVenta = venta,
                    UltAct = DateTime.Now //FECHA Y HORA ACTUAL
                };
                _context.Add(articuloCrear);
                _context.SaveChanges();
            }
            else
            {
                var articulo = _context.Articulos.Single(m => m.ArticuloID == ArticuloID);
                //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                articulo.Descripcion = Descripcion;
                articulo.SubrubroID = SubrubroID;
                if (articulo.PrecioCosto != costo || articulo.PrecioVenta != venta)
                {
                    articulo.UltAct = DateTime.Now;
                }
                articulo.PrecioCosto = costo;
                articulo.PorcentajeGanancia = ganancia;
                articulo.PrecioVenta = venta;
                _context.SaveChanges();
            }

            int resultado = 0;

            return Json(resultado);
        }

        public JsonResult BuscarArticulo(int ArticuloID)
        {
            var articulo = _context.Articulos.Include(p => p.Subrubro.Rubro).FirstOrDefault(m => m.ArticuloID == ArticuloID);

            var articuloMostrar = new VistaArticulo
            {
                ArticuloID = articulo.ArticuloID,
                Descripcion = articulo.Descripcion,
                SubrubroNombre = articulo.Subrubro.Descripcion,
                RubroNombre = articulo.Subrubro.Rubro.Descripcion,
                RubroID = articulo.Subrubro.RubroID,
                SubrubroID = articulo.SubrubroID,
                UltAct = articulo.UltAct,
                UltActString = articulo.UltAct.ToString("dd/MM/yyyy"),
                PrecioCosto = articulo.PrecioCosto,
                PorcentajeGanancia = articulo.PorcentajeGanancia,
                PrecioVenta = articulo.PrecioVenta
            };

            return Json(articuloMostrar);
        }
    }
}
