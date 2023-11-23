using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class ConsolaController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        public void ValidacionDeRol()
        {
            string? rol = HttpContext.Session.GetString("rol");

            if (String.IsNullOrEmpty(rol) || !rol.Equals("administrador"))
                throw new Exception("El usuario no es administrador, no tiene acceso a estas acciones");
        }

        public IActionResult ListaMiembros()
        {
            try
            {
            ValidacionDeRol();}
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
                return Redirect("/Home/index");
            }
       
            //TODO: Ordenar por nombre y apellido ascendentemente
            List<Miembro> miembrosDelSistema = _sistema.DevolverMiembrosRegistrados();
            return View(miembrosDelSistema);
           }  

        public IActionResult BloquearMiembro(string emailMiembro)
        {
            try
            {
                ValidacionDeRol();
                Miembro miembroParaBanear = _sistema.BuscarMiembro(emailMiembro);
                miembroParaBanear.Bloqueado = true;
                TempData["Mensaje"] = "El usuario fue bloqueado con exito";
            }
            catch (Exception ex) 
            {
                ViewBag.Mensaje = ex.Message;
                return View("ListaMiembros");
            }
          
            return RedirectToAction("ListaMiembros");
        }

        public IActionResult ListarPosts()
        {
            try
            {
                ValidacionDeRol();
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
                return Redirect("/Home/index");
            }

            List<Post> posteosDelSistema = _sistema.Posteos;

            return View(posteosDelSistema);
        }

        public IActionResult BanearPost(int idPost)
        {
            try
            {
                ValidacionDeRol();
                Post postParaBanear = _sistema.BuscarPost(idPost);
                postParaBanear.Censurado = true;
                TempData["Mensaje"] = "El post fue baneado con exito";
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
                return View("ListarPosts");
            }

            return RedirectToAction("ListarPosts");
        }
    }
}
