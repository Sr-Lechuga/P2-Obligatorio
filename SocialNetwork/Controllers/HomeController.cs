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

        public IActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string email, string contrasenia)
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

        [HttpGet] // Este atributo indica que el método responde a solicitudes HTTP GET
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string email, string nombre, string apellido, string contrasenia, string confirmarContrasenia, DateTime fechaDeNacimiento)
        {
            try
            {
        
                if (contrasenia != confirmarContrasenia)
                {
                    throw new Exception("Las contraseñas no coinciden.");
                }

                Miembro nuevoMiembro = new Miembro(email, contrasenia, nombre, apellido, fechaDeNacimiento);
                _sistema.AltaMiembro(nuevoMiembro);

                
                return RedirectToAction("Ingresar");
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