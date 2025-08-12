using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06todo.Models;

namespace TP06todo.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public static void mostrarLogin(){

        return View("Login");

    }

    [HttpPost]
    public IActionResult Login(string usuario, string password)
    {
        int idUsuario = BD.Login(usuario, password);
        HttpContext.Session.SetInt("IdUsuario", idUsuario);
        return RedirectToAction("Index", "Home");

    }

     [HttpPost]
    public IActionResult Register(string nombre, string apellido, string usuario, string password, string foto)
    {
        BD.RegistrarUsuario(nombre, apellido, usuario, password, foto, DateTime.Now);

        return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }


}
