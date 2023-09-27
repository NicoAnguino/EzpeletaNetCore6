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

            var diasDelMes = DateTime.DaysInMonth(2023, Mes);
            for (int i = 1; i <= diasDelMes; i++)
            {
                var subRubroMostrar = new VistaEjercicioFisico
                {
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

        public JsonResult BuscarEjerciciosFisicos2(int Mes, int Anio, int TipoEjercicioFisicoID)
        {   //BUSCAR EN LA TABLA DE EJERCICIOS FISICOS POR MES, POR AÑO Y POR TIPO DE EJERCICIO Y DE ESE LISTADO INCLUYA LA TABLA RELACIONADA DE TIPO DE EJERCICIOS FISICOS          
            var ejerciciosFisicos = _context.EjerciciosFisicos
                                    .Include(s => s.TipoEjercicioFisico)
                                    .Where(e => e.Fecha.Month == Mes && e.Fecha.Year == Anio && e.TipoEjercicioFisicoID == TipoEjercicioFisicoID)
                                    .ToList();
            //INICIALIZAMOS EL OBJETO DE MEMORIA DE LA SUMA DE LOS EJERCICIOS DEL MES Y AÑO DE ESE TIPO DE EJERCICIO
            VistaSumaEjercicioFisico vistaSumaEjercicioFisico = new VistaSumaEjercicioFisico();
            //DE ESA VISTA DECLARADA VAMOS A INICIALIZAR EL LISTADO DE DIAS DE ESE EJERCICIO
            vistaSumaEjercicioFisico.DiasEjercicios = new List<VistaEjercicioFisico>();

            var diasDelMes = DateTime.DaysInMonth(Anio, Mes);
            DateTime fechaMes = new DateTime();
            fechaMes = fechaMes.AddMonths(Mes - 1);
            for (int i = 1; i <= diasDelMes; i++)
            {
                var subRubroMostrar = new VistaEjercicioFisico
                {                  
                    Mes = fechaMes.ToString("MMM"),
                    Dia = i,
                    CantidadMinutos = 0
                };
                vistaSumaEjercicioFisico.DiasEjercicios.Add(subRubroMostrar);
            }
           
            foreach (var ejercicioFisico in ejerciciosFisicos.OrderBy(e => e.Fecha))
            {
                var diaSumar = vistaSumaEjercicioFisico.DiasEjercicios.Where(e => e.Dia == ejercicioFisico.Fecha.Day).Single();
                diaSumar.CantidadMinutos += ejercicioFisico.CantidadMinutos;
                vistaSumaEjercicioFisico.TotalidadMinutos += ejercicioFisico.CantidadMinutos;
            }

            vistaSumaEjercicioFisico.TotalidadDiasConEjercicio = vistaSumaEjercicioFisico.DiasEjercicios.Where(e => e.CantidadMinutos > 0).Count();
            vistaSumaEjercicioFisico.TotalidadDiasSinEjercicio = vistaSumaEjercicioFisico.DiasEjercicios.Where(e => e.CantidadMinutos == 0).Count();

            return Json(vistaSumaEjercicioFisico);
        }
       
    }
}
