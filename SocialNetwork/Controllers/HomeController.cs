using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using System.Diagnostics;
using Dominio;
using Dominio.Entidades;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasenia)
        {
            try
            {
                Usuario logueado = _sistema.AutenticarUsuario(email, contrasenia);
                HttpContext.Session.SetString("emailUsuario", logueado.Email);

                if (logueado is Miembro) { 
                    Miembro usuarioLogueado = (Miembro)logueado;
                    HttpContext.Session.SetString("nombreUsuario", usuarioLogueado.Nombre);
                    HttpContext.Session.SetString("rol", usuarioLogueado.Rol());
                }
                else
                {
                    Administrador usuarioLogueado = (Administrador) logueado;
                    HttpContext.Session.SetString("nombreUsuario", "Admin");
                    HttpContext.Session.SetString("rol", usuarioLogueado.Rol());
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {   
                ViewBag.MensajeError = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}