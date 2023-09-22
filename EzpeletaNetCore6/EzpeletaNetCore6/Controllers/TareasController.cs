using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models.GestionTarea;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EzpeletaNetCore6.Controllers
{
    [Authorize]
    public class TareasController : Controller
    {
       private readonly UserManager<IdentityUser> _userManager;

        private readonly ApplicationDbContext _context;

        public TareasController(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
              _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult BuscarTareas(int TareaID)
        {
            var usuarioIDActual = _userManager.GetUserId(HttpContext.User);
            var tareas = _context.Tareas.Where(t => t.UsuarioID == usuarioIDActual).ToList();

            if (TareaID > 0)
            {
                tareas = tareas.Where(p => p.TareaID == TareaID).ToList();
            }

            tareas = tareas.OrderByDescending(t => t.Fecha).OrderByDescending(t=> t.Prioridad).ToList();

            return Json(tareas);
        }


        public JsonResult GuardarTarea(int TareaID, string Fecha, string Descripcion, int Prioridad)
        {
            var usuarioIDActual = _userManager.GetUserId(HttpContext.User);

            //CONFIGURACIÓN DE CULTURA ESPAÑOL ARGENTINA
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            //PUNTO COMO DECIMAL

            DateTime fechaTarea = Convert.ToDateTime(Fecha);

            byte[] img = null;
            string tipoImg = null;

            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
            }

            var prioridadTarea = Models.GestionTarea.Prioridad.Baja;
            if (Prioridad == 2)
            {
                prioridadTarea = Models.GestionTarea.Prioridad.Media;
            }
            if (Prioridad == 3)
            {
                prioridadTarea = Models.GestionTarea.Prioridad.Alta;
            }

            if (TareaID == 0)
            {
                var tareaCrear = new Tarea
                {
                    Fecha = fechaTarea,
                    Descripcion = Descripcion,
                    Prioridad = prioridadTarea,
                    Realizada = false,
                    UsuarioID = usuarioIDActual
                };
                _context.Add(tareaCrear);
                _context.SaveChanges();
            }
            else
            {
                var tareaEditar = _context.Tareas.Single(m => m.TareaID == TareaID);
                //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                tareaEditar.Fecha = fechaTarea;
                tareaEditar.Descripcion = Descripcion;
                tareaEditar.Prioridad = prioridadTarea;
                _context.SaveChanges();
            }

            int resultado = 0;

            return Json(resultado);
        }

        public JsonResult MarcarRealizada(int TareaID)
        {
            Tarea tarea = _context.Tareas.Find(TareaID);
            if (tarea != null)
            {
                tarea.Realizada = true;
                _context.SaveChanges();
            }
            return Json(true);
        }


        public JsonResult EliminarTarea(int TareaID)
        {
            Tarea tarea = _context.Tareas.Find(TareaID);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                _context.SaveChanges();
            }
            return Json(true);
        }
    }
}
