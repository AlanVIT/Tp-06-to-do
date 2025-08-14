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
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario is null || idUsuario <= 0)
                return RedirectToAction("Login", "Account");

            int tareas = BD.VerTareas(idUsuario.Value);
            return View("Tareas", tareas);
        }

        [HttpGet]
        public IActionResult MostrarAgregarTarea()
        {
            return View("AgregarTarea");
        }

        [HttpPost]
        public IActionResult AgregarTarea(string descripcion, bool finalizada, string titulo, DateTime fecha)
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null){
                return RedirectToAction("Login", "Account");

            }

            BD.AgregarTarea(descripcion, finalizada, idUsuario.Value, titulo, fecha);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MostrarEliminarTarea(int id)
        {
            int tarea = BD.VerTarea(id);
            return View("EliminarTarea", tarea);
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
            int tarea = BD.VerTarea(id);
            return View("Tarea", tarea);
        }
    }
}
