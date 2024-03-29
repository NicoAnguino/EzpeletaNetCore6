﻿using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models.CategoriaComercial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EzpeletaNetCore6.Controllers
{
    [Authorize]
    public class RubrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RubrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rubros
        public async Task<IActionResult> Index()
        {        
            return View(await _context.Rubros.ToListAsync());
        }

        public JsonResult BuscarRubros()
        {
            var rubros = _context.Rubros.ToList();

            return Json(rubros);
        }

        public JsonResult GuardarRubro(int rubroID, string rubroNombre)
        {
            int resultado = 0;

            //SI ES 0 - ES CORRECTO
            //SI ES 1 - CAMPO DESCRIPCION ESTÁ VACIO
            //SI ES 2 - EL REGISTRO YA EXISTE CON LA MISMA DESCRIPCION           

            if (!string.IsNullOrEmpty(rubroNombre))
            {          
                rubroNombre = rubroNombre.ToUpper();
                if (rubroID == 0)
                {
                    //ANTES DE CREAR EL REGISTRO DEBEMOS PREGUNTAR SI EXISTE UNO CON LA MISMA DESCRIPCION
                    if (_context.Rubros.Any(e => e.Descripcion == rubroNombre))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //CREA EL REGISTRO DE RUBRO
                        //PARA ESO CREAMOS UN OBJETO DE TIPO RUBRO CON LOS DATOS NECESARIOS
                        var rubro = new Rubro
                        {
                            Descripcion = rubroNombre,                            
                        };                        
                        _context.Add(rubro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    //ANTES DE EDITAR EL REGISTRO DEBEMOS PREGUNTAR SI EXISTE UNO CON LA MISMA DESCRIPCION
                    if (_context.Rubros.Any(e => e.Descripcion == rubroNombre && e.RubroID != rubroID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //EDITA EL REGISTRO
                        //BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                        var rubro = _context.Rubros.Single(m => m.RubroID == rubroID);
                        //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                        rubro.Descripcion = rubroNombre;                      
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                resultado = 1;
            }

            //aqui va el codigo que deseemos para manipular el archivo
            return Json(resultado);
        }



        public JsonResult BuscarRubro(int RubroID)
        {
            var rubro = _context.Rubros.FirstOrDefault(m => m.RubroID == RubroID);

            return Json(rubro);
        }

        public JsonResult EliminarRubro(int RubroID, int Elimina)
        {
            int resultado = 0;

            var rubro = _context.Rubros.Find(RubroID);
            if (rubro != null)
            {
                if (Elimina == 0)
                {
                    rubro.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    //NO PUEDE ELIMINAR RUBRO SI TIENE SUBRUBROS ACTIVOS
                    var cantidadSubRubros = (from o in _context.Subrubros where o.RubroID == RubroID && o.Eliminado == false select o).Count();
                    if (cantidadSubRubros == 0)
                    {
                        rubro.Eliminado = true;
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
