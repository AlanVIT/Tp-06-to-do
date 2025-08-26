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
        public IActionResult mostrarLogin()
        {
            return View("salaLogin");
        }

        [HttpPost]
        public IActionResult Login(string usuario, string contraseña)
        {
            int userId = BD.Login(usuario, contraseña);
            if (userId > 0)
            {
                HttpContext.Session.SetString("IdUsuario", userId.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("salaLogin");
            }
        }

        [HttpGet]
        public IActionResult mostrarRegister()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(string nombre, string apellido, string usuario, string password, string foto)
        {
            BD.RegistrarUsuario(nombre, apellido, usuario, password, foto, DateTime.Now);
            return RedirectToAction("mostrarLogin");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }
    }
}