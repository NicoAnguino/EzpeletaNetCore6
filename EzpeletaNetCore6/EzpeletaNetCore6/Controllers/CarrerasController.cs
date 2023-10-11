using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPAPP1.Data;
using TPAPP1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TPAPP1.Controllers;


public class CarrerasController : Controller 
{
    private readonly ILogger<CarrerasController>? _logger;
    private ApplicationDbContext _contexto;

    public CarrerasController(ILogger<CarrerasController>? logger, ApplicationDbContext contexto)
    {
        _logger = logger;
        _contexto = contexto;
    }

    public IActionResult Index()
    {
        return View();
    }


    public JsonResult BuscarCarreras(int CarreraID = 0){
               
               
        var carreras = _contexto.Carreras.ToList();

       if (CarreraID  > 0){
        carreras = carreras.Where(c => c.CarreraID == CarreraID).OrderBy(c => c.NombreCarrera).ToList();
       }

       return Json(carreras);

    }


    public JsonResult GuardarCarrera(int CarreraID, string NombreCarrera, string Duracion){
        bool resultado = false;


         if (!string.IsNullOrEmpty(NombreCarrera))
         {
        
            if(CarreraID == 0){
                
                var carreraNuev = _contexto.Carreras.Where(c => c.NombreCarrera == NombreCarrera).FirstOrDefault();
                if (carreraNuev == null){
                   
                    var carreraGuardar = new Carrera {
                        NombreCarrera = NombreCarrera,
                        DuracionCarrera = Duracion
                    };
                    
                    carreraGuardar.NombreCarrera = carreraGuardar.NombreCarrera.ToUpper();
                    carreraGuardar.DuracionCarrera = carreraGuardar.DuracionCarrera.ToUpper();

                    _contexto.Add(carreraGuardar);
                    _contexto.SaveChanges();
                    resultado = true;
                }
            }
         
            else{
               
                var carreraOriginal = _contexto.Carreras.Where(c => c.NombreCarrera == NombreCarrera && c.CarreraID != CarreraID).FirstOrDefault();
                if(carreraOriginal == null){

                    var carreraEditar = _contexto.Carreras.Find(CarreraID);
                    if (carreraEditar != null){
                        carreraEditar.NombreCarrera = NombreCarrera;
                        carreraEditar.DuracionCarrera = Duracion;

                        carreraEditar.NombreCarrera = carreraEditar.NombreCarrera.ToUpper();
                        carreraEditar.DuracionCarrera = carreraEditar.DuracionCarrera.ToUpper();
                    
                        _contexto.SaveChanges();
                        resultado = true;
                    }
                }
            

            }

         }

        return Json(resultado);


    }


    public JsonResult EliminarCarrera(int CarreraID){
        bool resultado = false;

        var eliminarCarrera = _contexto.Carreras.FirstOrDefault(a => a.CarreraID == CarreraID);

        if(eliminarCarrera != null){
            
            var carreraUsa = _contexto.Alumnos.Where(a => a.CarreraID == CarreraID).ToList();
            if (carreraUsa.Count == 0 )
            {
                _contexto.Carreras.Remove(eliminarCarrera);
                _contexto.SaveChanges();
                resultado = true;
            }
            
        }

        return Json(resultado);
    }



}