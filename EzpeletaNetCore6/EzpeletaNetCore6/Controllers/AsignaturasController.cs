using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPAPP1.Data;
using TPAPP1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TPAPP1.Controllers;


public class AsignaturasController : Controller 
{
    private readonly ILogger<AsignaturasController>? _logger;
    private ApplicationDbContext _contexto;

    public AsignaturasController(ILogger<AsignaturasController>? logger, ApplicationDbContext contexto)
    {
        _logger = logger;
        _contexto = contexto;
    }

    public IActionResult Index()
    {
        var carreras = _contexto.Carreras.ToList();
        carreras.Add(new Carrera{CarreraID = 0, NombreCarrera = "[SELECCIONE UNA CARRERA]"});
        ViewBag.CarreraID = new SelectList(carreras.OrderBy(c => c.NombreCarrera), "CarreraID", "NombreCarrera");

        return View();
    }

    public JsonResult BuscarAsignaturas(int AsignaturaID = 0){
               
        List<VistaAsignatura> listaasignatura = new List<VistaAsignatura>();
         
        var asignaturas = _contexto.Asignaturas.Include( a => a.Carrera).ToList();

        if (AsignaturaID  > 0){
            asignaturas = asignaturas.Where(c => c.AsignaturaID == AsignaturaID).OrderBy(c => c.NombreAsignatura).ToList();
        }

        foreach (var asignatura in asignaturas.OrderBy(c => c.NombreAsignatura).ToList())
        {
            var mostrarAsignatura = new VistaAsignatura
                {
                    AsignaturaID = asignatura.AsignaturaID,
                    NombreAsignatura = asignatura.NombreAsignatura,
                    CarreraID = asignatura.CarreraID,
                    NombreCarrera = asignatura.Carrera.NombreCarrera

                };

            listaasignatura.Add(mostrarAsignatura);
        }


        return Json(listaasignatura);


    }

    public JsonResult GuardarAsignatura(int AsignaturaID, string NombreAsignatura, int CarreraID){
        bool resultado = false;


         if (!string.IsNullOrEmpty(NombreAsignatura))
         {
        
            if(AsignaturaID == 0){
                
                var asignaturaUsada = _contexto.Asignaturas.Where(c => c.NombreAsignatura == NombreAsignatura && c.CarreraID == CarreraID).Count();
                if (asignaturaUsada == 0){
                   
                    var asignatura = new Asignatura {
                        NombreAsignatura = NombreAsignatura.ToUpper(),
                        CarreraID = CarreraID
                    };
                    

                    _contexto.Add(asignatura);
                    _contexto.SaveChanges();
                    resultado = true;
                }
            }
         
            else{
               
                var asignaturaOriginal = _contexto.Asignaturas.Where(c => c.NombreAsignatura == NombreAsignatura &&  c.CarreraID == CarreraID && c.AsignaturaID != AsignaturaID).FirstOrDefault();
                if(asignaturaOriginal == null){

                    var asignEditar = _contexto.Asignaturas.Find(AsignaturaID);
                    if (asignEditar != null){
                        asignEditar.NombreAsignatura = NombreAsignatura.ToUpper();
                        asignEditar.CarreraID = CarreraID;
                    
                        _contexto.SaveChanges();
                        resultado = true;
                    }
                }
            

            }

         }

        return Json(resultado);


    }


    public JsonResult EliminarAsignatura(int AsignaturaID){
        bool resultado = false;

        var eliminarAsignatura = _contexto.Asignaturas.FirstOrDefault(a => a.AsignaturaID == AsignaturaID);

        if(eliminarAsignatura != null){
            
            var asignaturaUsada = _contexto.ProfesorAsignaturas.Where(a => a.AsignaturaID == AsignaturaID).ToList();
            if (asignaturaUsada.Count == 0 )
            {
                _contexto.Asignaturas.Remove(eliminarAsignatura);
                _contexto.SaveChanges();
                resultado = true;
            }
            
        }

        return Json(resultado);
    }


}