using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        public IActionResult Wonderland()
        {
            List<Post> posteos = _sistema.Posteos;

            if(posteos.Count == 0)
                ViewBag.MensajeError = "No hay publicaciones para mostrar";

            return View(posteos);
        }

        public IActionResult Buscar()
        {
            return View();
        }

    }
}
