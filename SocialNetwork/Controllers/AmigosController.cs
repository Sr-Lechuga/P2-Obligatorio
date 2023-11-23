using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using Dominio.Entidades;

namespace SocialNetwork.Controllers
{
    public class AmigosController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Amigos()
        {
            try
            {
                Miembro miembroLogueado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));
                List<Miembro> listaAmigos = _sistema.BuscarAmigos(miembroLogueado);
                return View(listaAmigos);
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
                return View("Index");
            }
        }

        public IActionResult Buscar()
        {
            List<Miembro> listaMiembros = new List<Miembro>();

            Miembro miembroLogueado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));
            List<Miembro> listaAmigos = _sistema.BuscarAmigos(miembroLogueado);

            List<Miembro> miembrosDisponibles = new List<Miembro>();
            foreach (Solicitud solicitud in _sistema.Solicitudes)
            {
                if (solicitud.Solicitante.Equals(miembroLogueado))
                {
                    
                }
            }

            return View(listaMiembros);
        }
    }
}
