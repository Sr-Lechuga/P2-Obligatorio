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
            //TODO: Que pasa si los posteos son nulos?
            return View(posteos);
        }

        public IActionResult Buscar()
        {
            return View();
        }

    }
}
