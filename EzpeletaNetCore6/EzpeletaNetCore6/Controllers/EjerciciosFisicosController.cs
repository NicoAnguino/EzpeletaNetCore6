using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models.ActividadFisica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EzpeletaNetCore6.Controllers
{
    [Authorize]
    public class EjerciciosFisicosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EjerciciosFisicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tipoEjerciciosFisicos = _context.TiposEjerciciosFisicos.Where(p => p.Eliminado == false).ToList();
            ViewBag.RubroID = new SelectList(tipoEjerciciosFisicos.OrderBy(p => p.Descripcion), "TipoEjercicioFisicoID", "Descripcion");

            return View();
        }

        public JsonResult BuscarEjerciciosFisicos(int Mes = 9, int TipoEjercicioFisicoID = 1)
        {
            
            var ejerciciosFisicos = _context.EjerciciosFisicos.Include(s => s.TipoEjercicioFisico).ToList();

            List<VistaEjercicioFisico> listadoMostrar = new List<VistaEjercicioFisico>();

            var fechaInicio = new DateTime();
            fechaInicio.AddMonths(Mes);

            var diasDelMes = DateTime.DaysInMonth(2023, Mes);
            for (int i = 1; i <= diasDelMes; i++)
            {
                var subRubroMostrar = new VistaEjercicioFisico
                {
                    TipoEjercicioFisicoID = 1,
                    Mes = "SEP ",
                    Dia = i,
                    CantidadMinutos = 0
                };
                listadoMostrar.Add(subRubroMostrar);
            }

            foreach (var ejercicioFisico in ejerciciosFisicos.OrderBy(e => e.Fecha))
            {
                var diaSumar = listadoMostrar.Where(e => e.Dia == ejercicioFisico.Fecha.Day).Single();
                diaSumar.CantidadMinutos += ejercicioFisico.CantidadMinutos;
            }

            return Json(listadoMostrar);
        }
       
    }
}
