using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models.CategoriaComercial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EzpeletaNetCore6.Controllers
{
    [Authorize]
    public class SubrubrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubrubrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rubros = _context.Rubros.Where(p => p.Eliminado == false).ToList();
            ViewBag.RubroID = new SelectList(rubros.OrderBy(p => p.Descripcion), "RubroID", "Descripcion");

            return View();
        }

        public JsonResult BuscarSubrubros()
        {
            var subrubros = _context.Subrubros.Include(s => s.Rubro).ToList();

            List<ListadoSubrubros> listadoSubrubros = new List<ListadoSubrubros>();

            foreach (var subrubro in subrubros)
            {
                var subRubroMostrar = new ListadoSubrubros
                {
                    SubrubroID = subrubro.SubrubroID,
                    Descripcion = subrubro.Descripcion,
                    RubroID = subrubro.RubroID,
                    RubroNombre = subrubro.Rubro.Descripcion,
                    Eliminado = subrubro.Eliminado
                };
                listadoSubrubros.Add(subRubroMostrar);
            }

            return Json(listadoSubrubros);
        }


        public JsonResult GuardarSubrubro(int SubrubroID, string Descripcion, int RubroID)
        {
            int resultado = 0;

            //SI ES 0 - ES CORRECTO
            //SI ES 1 - CAMPO DESCRIPCION ESTÁ VACIO
            //SI ES 2 - EL REGISTRO YA EXISTE CON LA MISMA DESCRIPCION

            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
                if (SubrubroID == 0)
                {
                    //ANTES DE CREAR EL REGISTRO DEBEMOS PREGUNTAR SI EXISTE UNO CON LA MISMA DESCRIPCION
                    if (_context.Subrubros.Any(e => e.Descripcion == Descripcion && e.RubroID == RubroID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //CREA EL REGISTRO DE RUBRO
                        //PARA ESO CREAMOS UN OBJETO DE TIPO RUBRO CON LOS DATOS NECESARIOS
                        var subrubro = new Subrubro
                        {
                            Descripcion = Descripcion,
                            RubroID = RubroID
                        };
                        _context.Add(subrubro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    //ANTES DE EDITAR EL REGISTRO DEBEMOS PREGUNTAR SI EXISTE UNO CON LA MISMA DESCRIPCION
                    if (_context.Subrubros.Any(e => e.Descripcion == Descripcion && e.RubroID == RubroID && e.SubrubroID != SubrubroID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //EDITA EL REGISTRO
                        //BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                        var subrubro = _context.Subrubros.Single(m => m.SubrubroID == SubrubroID);
                        //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                        subrubro.Descripcion = Descripcion;
                        subrubro.RubroID = RubroID;
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                resultado = 1;
            }

            return Json(resultado);
        }

        public JsonResult ComboSubRubro(int id)//RUBRO ID
        {
            //BUSCAR SUBRUBROS
            var subRubros = (from o in _context.Subrubros where o.RubroID == id && o.Eliminado == false select o).ToList();

            return Json(new SelectList(subRubros, "SubrubroID", "Descripcion"));
        }

        public JsonResult BuscarSubrubro(int SubrubroID)
        {
            var subRubro = _context.Subrubros.FirstOrDefault(m => m.SubrubroID == SubrubroID);

            return Json(subRubro);
        }

        public JsonResult EliminarSubrubro(int SubrubroID, int Elimina)
        {
            int resultado = 0;

            var subRubro = _context.Subrubros.Find(SubrubroID);
            if (subRubro != null)
            {
                if (Elimina == 0)
                {
                    subRubro.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    //ANTES PREGUNTAR SI EXISTE ALGUN ARTÍCULO CON ESTADO ACTIVO QUE TENGA ESE SUBRUBRO
                    var cantidadArticulos = (from o in _context.Articulos where o.SubrubroID == SubrubroID && o.Eliminado == false select o).Count();
                    if (cantidadArticulos == 0)
                    {
                        subRubro.Eliminado = true;
                        _context.SaveChanges();
                    }
                    else
                    {
                        resultado = 1;
                    }
                }
            }

            return Json(resultado);
        }
    }
}
