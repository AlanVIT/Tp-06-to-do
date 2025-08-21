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
            var session = HttpContext.Session.GetString("IdUsuario");
            if(session == null){

                return View("Login");

            }
            else{
                int idUsuario = int.Parse(session);
                ViewBag.tareas = BD.VerTareas(idUsuario);
            }
            return View("Tareas");
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

        [HttpPost]
        public IActionResult EliminarTarea(int id)
        {
            BD.EliminarTarea(id);
            return RedirectToAction("Index");
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
            ViewBag.tarea = BD.VerTarea(idUsuario);
            return View("Tarea");
        }

        [HttpGet]
        public IActionResult modificarTarea(int id, string descripcion, bool finalizada, string titulo, DateTime fecha)
        {
            int idUsuario = int.Parse(HttpContext.Session.GetString("IdUsuario"));
            BD.ModificarTarea(id, descripcion, finalizada, idUsuario, titulo, fecha );
            return View("Tarea");
        }

        [HttpGet]
        public IActionResult mostrarFinalizarTarea(int id)
        {
            BD.FinalizarTarea(id);
            return View("Tarea");
        }

        [HttpGet]
        public IActionResult finalizarTarea(int id)
        {
            BD.FinalizarTarea(id);
            return View("Tarea");
        }

        [HttpGet]
        public IActionResult actualizarFecha(int id)
        {
            BD.FinalizarTarea(id);
            return View("Tarea");
        }

    }
}
