using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        public IActionResult Wonderland()
        {
            List<Post> posteos = _sistema.DevolverWonderland(HttpContext.Session.GetString("emailUsuario"));

            if (posteos.Count == 0)
                ViewBag.MensajeError = "No hay publicaciones para mostrar";

            return View(posteos);
        }

        public IActionResult Reaccionar(int id_post, int id_comentario, string type)
        {
            try
            {
                Post post = _sistema.BuscarPost(id_post);
                //Reacciones de comentario
                if (id_comentario != -1)
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

            return View("Wonderland", posteos);
        }

        public IActionResult Buscar(string emailUsuario) 
        {
            List<Post> listaPost = new List<Post>();

            Miembro miembroLogueado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));
            Miembro miembroAmigo = _sistema.BuscarMiembro(emailUsuario);

            if (_sistema.EsAmigo(miembroLogueado.Email, miembroAmigo.Email))
            {
                List<Publicacion> listaPublicacionesAmigo = _sistema.DevolverListaPublicacionesDelMiembro(miembroAmigo.Email);
                foreach (Publicacion publicacion in listaPublicacionesAmigo)
                {
                    if (publicacion is Post)
                        listaPost.Add((Post)publicacion);
                }

            }

            return View("Wonderland", listaPost);


        }

        // Action para poder realizar un comentario.
        public IActionResult AgregarComentario(int id_post, string contenidoComentario)
        {
                List<Post> posteos = _sistema.Posteos;
            try
            {
                Miembro miembroLogueado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));

                if (miembroLogueado.Bloqueado)
                    throw new Exception("El usuario esta baneado. No puede realizar comentarios");


                string nombreUsuarioLogueado = User.Identity.Name;
                string titulo = $"Comentario de " + nombreUsuarioLogueado;

                Post postComentado = _sistema.BuscarPost(id_post);
                if (postComentado != null && contenidoComentario != null)
                {
                    Comentario nuevoComentario = new Comentario(titulo, contenidoComentario, miembroLogueado);
                    postComentado.AgregarComentario(nuevoComentario);

                    return View("wonderland", posteos);
                }

                return View("wonderland", posteos);
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
                return Redirect("/Home/Index");
            }

        }

        public IActionResult BuscarDesdeTexto (string texto, int aceptacion)
        {
            List<Post> publicacionesContienenTexto = new List<Post>();
            List<Post> postDisponibles = _sistema.DevolverWonderland(HttpContext.Session.GetString("emailUsuario"));

            foreach(Post post in postDisponibles)
            {
                if (post.Contenido.Contains(texto) && post.CalcularValorAceptacion() > aceptacion) 
                {
                    publicacionesContienenTexto.Add(post);
                    List<Comentario> comentariosPost = post.DevolverListaComentarios();
                    post.Comentarios = new List<Comentario>();

                    foreach (Comentario comentario in comentariosPost)
                    {
                        if (comentario.Contenido.Contains(texto) && comentario.CalcularValorAceptacion() > aceptacion)
                        {
                            post.AgregarComentario(comentario);
                        }
                    }
                }
            }
           
            return View("Wonderland", publicacionesContienenTexto);
        }
    }
}
