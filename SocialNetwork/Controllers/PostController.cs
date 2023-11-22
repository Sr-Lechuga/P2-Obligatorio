using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        public IActionResult Wonderland()
        {
            ViewBag.Posts = _sistema.Posteos;
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }

    }
}
