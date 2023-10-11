using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models.GestionAlumno;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EzpeletaNetCore6.Controllers;


public class AlumnosController : Controller 
{
    private readonly ILogger<AlumnosController>? _logger;
    private ApplicationDbContext _contexto;

    public AlumnosController(ILogger<AlumnosController>? logger, ApplicationDbContext contexto)
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


    public JsonResult BuscarAlumnos(int AlumnoID = 0, int CarreraID = 0){

        List<VistaAlumno> listaAlumnos = new List<VistaAlumno>();

        var alumnos = _contexto.Alumnos.Include(a => a.Carrera).ToList();


        if (AlumnoID  > 0){
            alumnos = alumnos.Where(c => c.AlumnoID == AlumnoID).OrderBy(c => c.Nombre).ToList();
        } 


        foreach (var alumno in alumnos.OrderBy(a => a.Carrera.Nombre).ThenBy(c => c.Nombre).ToList())
        {
            var mostrarAlumnos = new VistaAlumno
                {
                    AlumnoID = alumno.AlumnoID,
                    Nombre = alumno.Nombre,
                    FechaNacimientoString = alumno.FechaNacimientoString,
                    FechaNacimientoStringInput = alumno.FechaNacimientoStringInput,
                    CarreraID = alumno.CarreraID,
                    NombreCarrera = alumno.Carrera.Nombre,
                    Email = alumno.Email,
                    DNI = alumno.DNI,
                    Direccion = alumno.Direccion

                };

            listaAlumnos.Add(mostrarAlumnos);
        }


        return Json(listaAlumnos);
    }


    public JsonResult GuardarAlumno(int AlumnoID, string Nombre, DateTime FechaNacimiento, int CarreraID, string Email, int DNI, string Direccion){
        bool resultado = false;

        if(!string.IsNullOrEmpty(Nombre)){

            if(AlumnoID == 0){
                var alumnonew = _contexto.Alumnos.Where(a => a.DNI == DNI).FirstOrDefault();
                if(alumnonew == null){
                    var alumnoGuardar = new Alumno {
                        Nombre = Nombre.ToUpper(),
                        FechaNacimiento = FechaNacimiento,
                        CarreraID = CarreraID, 
                        Email = Email,
                        Direccion = Direccion.ToUpper(),
                        DNI = DNI
                    };
                    _contexto.Add(alumnoGuardar);
                    _contexto.SaveChanges();
                    resultado = true;
                }
            }
            else
            {
                var otroAlumno = _contexto.Alumnos.Where(a => a.DNI == DNI && a.AlumnoID != AlumnoID).FirstOrDefault();
                if(otroAlumno == null){


                    var alumnoEditar = _contexto.Alumnos.Find(AlumnoID);
                    if(alumnoEditar != null){
                        alumnoEditar.Nombre = Nombre.ToUpper();
                        alumnoEditar.FechaNacimiento = FechaNacimiento;
                        alumnoEditar.CarreraID = CarreraID;
                        alumnoEditar.Email = Email;
                        alumnoEditar.Direccion = Direccion.ToUpper();
                        alumnoEditar.DNI = DNI;


                        _contexto.SaveChanges();
                        resultado = true;
                    }
                }

            }

        }
        return Json(resultado);
    }


    public JsonResult EliminarAlumno(int AlumnoID){

        bool resultado = false;
        
        var elimarAlumno = _contexto.Alumnos.FirstOrDefault(a => a.AlumnoID == AlumnoID);

        if(elimarAlumno != null){
            
                _contexto.Alumnos.Remove(elimarAlumno);
                _contexto.SaveChanges();
                resultado = true;
            
        }
        return Json(resultado);
    }



}