using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class PublicarController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        [HttpGet]
        public ActionResult Publicar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Publicar(Publicacion nuevaPublicacion) 
        {
            if(ModelState.IsValid)
            {
                _sistema.Posteos.Add((Post)nuevaPublicacion);
                return RedirectToAction("Publicar");
            }
            return View(nuevaPublicacion);
        }
    }

}
