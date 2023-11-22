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

        public IActionResult Reaccionar(int id_post, int id_comentario, string type)
        {
            try
            {
                Post post = _sistema.BuscarPost(id_post);
                //Reacciones de comentario
                if(id_comentario != -1)
                {
                    Comentario comentario = post.BuscarComentario(id_comentario);
                    Miembro miembroLogueado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));
                    comentario.AgregarOModificarReaccion(miembroLogueado, type == "like" ? true : false);
                }
                // Si el id_comentario es -1, se refiere a la reaccion del post
                else
                {
                    Miembro miembroLogueado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));
                    post.AgregarOModificarReaccion(miembroLogueado, type == "like" ? true : false);
                }
            }
            catch (Exception ex) 
            {
                ViewBag.MensajeError = ex.Message;
            }
            List<Post> posteos = _sistema.Posteos;

            return View("Wonderland",posteos);
        }

        [HttpPost]
        public IActionResult Buscar()
        {

            return View();
        }

    }
}
