using Microsoft.AspNetCore.Mvc;
using TP06todo.Models;

namespace TP06todo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string session = HttpContext.Session.GetString("IdUsuario");
            if (session == null)
            {
                return View("Index");
            }
            else
            {
                int idUsuario = int.Parse(HttpContext.Session.GetString("IdUsuario"));
                ViewBag.tareas = BD.VerTareas(idUsuario);
                return View("Tareas");
            }
        }

        [HttpGet]
        public IActionResult MostrarAgregarTarea()
        {
            return View("AgregarTarea");
        }

        [HttpPost]
        public IActionResult AgregarTarea(string descripcion, bool finalizada, string titulo, DateTime fecha)
        {
            var session = HttpContext.Session.GetString("IdUsuario");
            int idUsuario = int.Parse(session);
            BD.AgregarTarea(descripcion, finalizada, idUsuario, titulo, fecha);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EliminarTarea(int id)
        {
            BD.EliminarTarea(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult VerTarea(int id)
        {
            ViewBag.tarea = BD.VerTarea(id);
            return View("Tarea");
        }

        [HttpGet]
        public IActionResult VerTareas()
        {
            int idUsuario = int.Parse(HttpContext.Session.GetString("IdUsuario"));
            ViewBag.tareas = BD.VerTareas(idUsuario);
            return View("Tareas");
        }

        [HttpGet]
        public IActionResult mostrarModificarTarea(int id)
        {
            ViewBag.tarea = BD.VerTarea(id);
            return View("ModificarTarea");
        }

        [HttpPost]
        public IActionResult modificarTarea(int id, string descripcion, bool finalizada, string titulo, DateTime fecha)
        {
            int idUsuario = int.Parse(HttpContext.Session.GetString("IdUsuario"));
            BD.ModificarTarea(id, descripcion, finalizada, idUsuario, titulo, fecha);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult finalizarTarea(int id)
        {
            BD.FinalizarTarea(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult actualizarFecha(int id, DateTime fecha)
        {
            BD.ActualizarFecha(id, fecha);
            return RedirectToAction("index");
        }

    }
}
