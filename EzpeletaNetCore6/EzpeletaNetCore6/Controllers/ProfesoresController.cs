using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models.GestionAlumno;

namespace TPAPP1.Controllers;

public class ProfesoresController : Controller 
{
    private readonly ILogger<ProfesoresController>? _logger;
    private ApplicationDbContext _contexto;

    public ProfesoresController(ILogger<ProfesoresController>? logger, ApplicationDbContext contexto)
    {
        _logger = logger;
        _contexto = contexto;
    }

    public IActionResult Index()
    {
        var asignaturas = _contexto.Asignaturas.ToList();
        asignaturas.Add(new Asignatura{AsignaturaID = 0, Nombre = "[SELECCIONE UNA ASIGNATURA]"});
        ViewBag.AsignaturaID = new SelectList(asignaturas.OrderBy(c => c.Nombre), "AsignaturaID", "Nombre");


        return View();
    }


    public JsonResult BuscarProfesores(int ProfesorID = 0){
               
               
        var profesores = _contexto.Profesores.OrderBy(c => c.Nombre).ToList();

       if (ProfesorID  > 0){
        profesores = profesores.Where(c => c.ProfesorID == ProfesorID).ToList();
       }

       return Json(profesores);

    }


    public JsonResult GuardarProfesor(int ProfesorID, string Nombre, int DNI, string Email, string Direccion, DateTime FechaNacimiento){
        bool resultado = false;

        if(!string.IsNullOrEmpty(Nombre)){

            if(ProfesorID == 0){
                var profesorNuevo = _contexto.Profesores.Where(a =>a.DNI == DNI).FirstOrDefault();
                if(profesorNuevo == null){
                    var profeGuardar = new Profesor {
                        Nombre = Nombre.ToUpper(),
                        Email = Email,
                        DNI = DNI,
                        Direccion = Direccion.ToUpper(),
                        FechaNacimiento = FechaNacimiento          
                    };
                    _contexto.Add(profeGuardar);
                    _contexto.SaveChanges();
                    resultado = true;
                }
            }
            else
            {
                var otroProfesor = _contexto.Profesores.Where(a =>a.DNI == DNI && a.ProfesorID != ProfesorID).FirstOrDefault();
                if(otroProfesor == null){

                    var profeEditar = _contexto.Profesores.Find(ProfesorID);
                    if(profeEditar != null){
                        profeEditar.Nombre = Nombre.ToUpper();
                        profeEditar.Email = Email;
                        profeEditar.DNI = DNI;
                        profeEditar.Direccion = Direccion.ToUpper();
                        profeEditar.FechaNacimiento = FechaNacimiento;
                        _contexto.SaveChanges();

                        resultado = true;
                    }
                }

            }

        }
        return Json(resultado);
    }


    public JsonResult EliminarProfesor(int ProfesorID){

        bool resultado = false;
        
        var elimarProfe = _contexto.Profesores.FirstOrDefault(a => a.ProfesorID == ProfesorID);

        if(elimarProfe != null){
            
                _contexto.Profesores.Remove(elimarProfe);
                _contexto.SaveChanges();
                resultado = true;
            
        }
        return Json(resultado);
    }


    public JsonResult GuardarAsignaturaProfesor(int ProfesorID, int AsignaturaID){

        bool resultado = false;

        var asignaturaEnUso = _contexto.ProfesoresAsignaturas.Where(p => p.AsignaturaID == AsignaturaID && p.ProfesorID == ProfesorID).Count();
        if (asignaturaEnUso == 0)
        {
            var asignaturaProfesor = new ProfesorAsignatura
            {
                ProfesorID = ProfesorID,
                AsignaturaID = AsignaturaID
            };
            _contexto.Add(asignaturaProfesor);
            _contexto.SaveChanges();

            resultado = true;
        }

        return Json(resultado);
    }

    public JsonResult BuscarAsignaturas(int ProfesorID = 0){

        var asignaturas = _contexto.ProfesoresAsignaturas.Where(p => p.ProfesorID == ProfesorID).ToList();

        return Json(asignaturas);
    }



}