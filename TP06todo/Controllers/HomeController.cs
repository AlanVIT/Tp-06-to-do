using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06todo.Models;

namespace TP06todo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        idUsuario = HttpContext.Session.GetInt("IdUsuario");
        List<Tarea> tareas = BD.verTareas(idUsuario.Value);
        return View(tareas);
    }

    public IActionResult mostrarAgregarTarea(){

        return View("agregarTarea");

    }
    public IActionResult agregarTarea(string descripcion, bool finalizada, string titulo, DateTime fecha)
    {
        idUsuario = HttpContext.Session.GetInt("IdUsuario");
        BD.agregarTarea(descripcion, finalizada, idUsuario, titulo, fecha);

        return RedirectToAction("Index");
    }
        public IActionResult mostrarEliminarTarea(){

        return View("agregarTarea");

    }
    public IActionResult eliminarTarea(string descripcion, bool finalizada, string titulo, DateTime fecha)
    {
        idUsuario = HttpContext.Session.GetInt("IdUsuario");
        BD.eliminarTarea(descripcion, finalizada, idUsuario, titulo, fecha);

        return RedirectToAction("Index");
    }
}