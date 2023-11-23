using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Dominio.Enum;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocialNetwork.Controllers
{
    public class AmigosController : Controller
    {
        Dominio.SocialNetwork _sistema = Dominio.SocialNetwork.Instancia;

        public IActionResult Index()
        {
            return View("Index");
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
            List<Miembro> miembrosDisponibles = new List<Miembro>();

            Miembro miembroLogueado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));

            // Trae todos los miembros que tengan alguna relacion con el miembro logueado (aceptada,rechazada o pendiente)
            List<Miembro> miembrosRelacionados = new List<Miembro>();
            foreach (Solicitud solicitud in _sistema.Solicitudes)
            {
                if (solicitud.Solicitante.Equals(miembroLogueado))
                    miembrosRelacionados.Add(solicitud.Solicitado);
                else if (solicitud.Solicitado.Equals(miembroLogueado))
                    miembrosRelacionados.Add(solicitud.Solicitante);
            }

            // Se filtran (quitan) los miembros del sistema, que tengan alguna relacion con el miembro loguado
            List<Miembro> miembrosDelSistema = _sistema.DevolverMiembrosRegistrados();
            foreach (Miembro miembroSistema in miembrosDelSistema)
            {
                if (!miembrosRelacionados.Contains(miembroSistema) && !miembroSistema.Equals(miembroLogueado))
                    miembrosDisponibles.Add(miembroSistema);
            }

            return View(miembrosDisponibles);
        }

        public IActionResult Pendientes()
        {
            List<Miembro> amigosPendientes = new List<Miembro>();

            Miembro miembroLogueado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));

            //Agrega a la lista de amistades pendientes si el miembro logueado es el solicitado
            foreach (Solicitud solicitud in _sistema.Solicitudes)
            {
                if (solicitud.Solicitado.Equals(miembroLogueado)
                    && solicitud.Estado == EstadoSolicitud.PENDIENTE_APROVACION)
                    amigosPendientes.Add(solicitud.Solicitante);
            }

            return View(amigosPendientes);
        }

        public IActionResult AceptarSolicitud(string email)
        {
            int i = 0;
            Solicitud? solicitudParaAceptar = null;
            try
            {
                Miembro miembroLogueuado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));
                Miembro miembroSolicitante = _sistema.BuscarMiembro(email);

                while (solicitudParaAceptar == null && i < _sistema.Solicitudes.Count)
                {
                    if (_sistema.Solicitudes[i].Solicitado.Equals(miembroLogueuado)
                        && _sistema.Solicitudes[i].Solicitante.Equals(miembroSolicitante))
                        solicitudParaAceptar = _sistema.Solicitudes[i];
                    i++;
                }

                if (solicitudParaAceptar == null)
                    throw new Exception("No se encontro la solicitud a aceptar");
            }
            catch(Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
                return View("Index");
            }

            solicitudParaAceptar.CambiarEstado(EstadoSolicitud.ACEPTADA);

            return RedirectToAction("Pendientes");
        }

        public IActionResult RechazarSolicitud(string email)
        {
            int i = 0;
            Solicitud? solicitudParaAceptar = null;
            try
            {
                Miembro miembroLogueuado = _sistema.BuscarMiembro(HttpContext.Session.GetString("emailUsuario"));
                Miembro miembroSolicitante = _sistema.BuscarMiembro(email);

                while (solicitudParaAceptar == null && i < _sistema.Solicitudes.Count)
                {
                    if (_sistema.Solicitudes[i].Solicitado.Equals(miembroLogueuado)
                        && _sistema.Solicitudes[i].Solicitante.Equals(miembroSolicitante))
                        solicitudParaAceptar = _sistema.Solicitudes[i];
                    i++;
                }

                if (solicitudParaAceptar == null)
                    throw new Exception("No se encontro la solicitud a aceptar");
            }
            catch (Exception ex)
            {
                ViewBag.MensajeError = ex.Message;
                return View("Index");
            }

            solicitudParaAceptar.CambiarEstado(EstadoSolicitud.RECHAZADA);

            return RedirectToAction("Pendientes");
        }
    }
}
