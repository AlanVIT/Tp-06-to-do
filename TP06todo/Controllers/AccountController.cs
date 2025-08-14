using Microsoft.AspNetCore.Mvc;
using TP06todo.Models;

namespace TP06todo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            int idUsuario = BD.Login(usuario, password);
            if (idUsuario <= 0)
            {
                TempData["Error"] = "Usuario o contraseña inválidos.";
                return View("Login");
            }

            HttpContext.Session.SetInt32("IdUsuario", idUsuario);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
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
}