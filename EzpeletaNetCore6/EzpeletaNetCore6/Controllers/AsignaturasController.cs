using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models.GestionAlumno;

namespace EzpeletaNetCore6.Controllers;


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
        carreras.Add(new Carrera{CarreraID = 0, Nombre = "[SELECCIONE UNA CARRERA]"});
        ViewBag.CarreraID = new SelectList(carreras.OrderBy(c => c.Nombre), "CarreraID", "Nombre");

        return View();
    }

    public JsonResult BuscarAsignaturas(int AsignaturaID = 0){
               
        List<VistaAsignatura> listaasignatura = new List<VistaAsignatura>();
         
        var asignaturas = _contexto.Asignaturas.Include( a => a.Carrera).ToList();

        if (AsignaturaID  > 0){
            asignaturas = asignaturas.Where(c => c.AsignaturaID == AsignaturaID).OrderBy(c => c.Nombre).ToList();
        }

        foreach (var asignatura in asignaturas.OrderBy(c => c.Nombre).ToList())
        {
            var mostrarAsignatura = new VistaAsignatura
                {
                    AsignaturaID = asignatura.AsignaturaID,
                    NombreAsignatura = asignatura.Nombre,
                    CarreraID = asignatura.CarreraID,
                    NombreCarrera = asignatura.Carrera.Nombre

                };

            listaasignatura.Add(mostrarAsignatura);
        }


        return Json(listaasignatura);


    }

    public JsonResult GuardarAsignatura(int AsignaturaID, string Nombre, int CarreraID){
        bool resultado = false;


         if (!string.IsNullOrEmpty(Nombre))
         {
        
            if(AsignaturaID == 0){
                
                var asignaturaUsada = _contexto.Asignaturas.Where(c => c.Nombre == Nombre && c.CarreraID == CarreraID).Count();
                if (asignaturaUsada == 0){
                   
                    var asignatura = new Asignatura {
                        Nombre = Nombre.ToUpper(),
                        CarreraID = CarreraID
                    };               
                    _contexto.Add(asignatura);
                    _contexto.SaveChanges();
                    resultado = true;
                }
            }
         
            else{
               
                var asignaturaOriginal = _contexto.Asignaturas.Where(c => c.Nombre == Nombre &&  c.CarreraID == CarreraID && c.AsignaturaID != AsignaturaID).FirstOrDefault();
                if(asignaturaOriginal == null){

                    var asignEditar = _contexto.Asignaturas.Find(AsignaturaID);
                    if (asignEditar != null){
                        asignEditar.Nombre = Nombre.ToUpper();
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
            
            var asignaturaUsada = _contexto.ProfesoresAsignaturas.Where(a => a.AsignaturaID == AsignaturaID).ToList();
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