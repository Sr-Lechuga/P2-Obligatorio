using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class PublicarController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        public ActionResult Publicar()
        {
            return View();
        }

        public ActionResult RealizarPublicacion(string titulo, string contenido, string imagen, int privado)
        {
            Miembro autor = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));
            Post nuevoPost = new Post(titulo, contenido, autor, imagen, privado == 0 ? false : true);
            try
            {
                if (autor.Bloqueado)
                    throw new Exception("El usuario esta baneado. No puede realizar publicaciones");

                _sistema.AgregarPost(nuevoPost);
                ViewBag.Mensaje = "El post se agrego con exito";
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
                return Redirect("/Home/Index");
            }

            return View("Publicar");
        }
    }

}
