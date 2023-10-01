using System;

namespace Dominio.Entidades
{
    public class SocialNetwork
    {
        #region Singleton
        private static SocialNetwork instancia;

        public static SocialNetwork Instance
        {
            get
            {
                if (instancia == null)
                    instancia = new SocialNetwork();
                return instancia;
            }
        }

        private SocialNetwork()
        {
        }
        #endregion

        #region Atributos
        private List<Administrador> _administradores;
        private List<Miemnbro> _miembros;
        private List<Solicitud> _relaciones;
        private List<Post> _publicaciones;
        #endregion

        #region Métodos
        /// <summary>
        /// Metodo que permite buscar un <c>Miembro</c> en el sistema
        /// </summary>
        /// <param name="email">
        /// <c>Email</c> con el que se busca a un <c>Miembro</c>
        /// </param>
        /// <returns><c>Miembro</c></returns>
        public Miembro BuscarMiembro(string email)
        {

        }
        /// <summary>
        /// Metodo que permite al <c>Administrador</c> bloquear un miembro
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> a bloquear </param>
        public void BloquearMiembro(Miembro miembro)
        {

        }
        /// <summary>
        /// Metodo que permite al <c>Administrador</c> censurar un comentario
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> que realizo el comentario</param>
        /// <param name="comentario"><c>Comentario</c> a censurar</param>
        public void CensurarComentario(Miembro miembro, Comentario comentario)
        {

        }
        /// <summary>
        /// Metodo que permite gestionar una solicitud
        /// </summary>
        /// <param name="solicitud"> <c>Solicitud</c> que se va a gestionar </param>
        public void GestionSolicitud(Solicitud solicitud)
        {

        }
        /// <summary>
        /// Metodo que permite actualizar las <c>Relaciones</c> entre los <c>Miembros</c>
        /// </summary>
        /// <param name="miembro"><c>Miemro</c> a actualizar</param>
        /// <returns></returns>
        public List<Solicitud> ActualizarAmigos(Miembro miembro)
        {

        }
        /// <summary>
        /// Metodo que muestra los <c>Miembros</c> disponibles para amistad
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> al que se le mostrara la lista de amigos disponibles</param>
        /// <returns>Lista de <c>Miembros</c></returns>
        public List<Miembro> MostrarMiembrosDisponiblesParaAmistad(Miembro miembro)
        {

        }
        /// <summary>
        /// Metodo que permite enviar una <c>Solicitud</c> de amistad
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> al que se le enviara la solicitud</param>
        public void EnviarSolicitud(Miembro miembro)
        {

        }
        /// <summary>
        /// Metodo que muestra a los amigos de un <c>Miembro</c>
        /// </summary>
        /// <param name="miembro"> <c>Miembro</c> al que se le mostrara la lista de <c>Miembros</c> que son sus amigos</param>
        /// <returns>Lista de <c>Miembros</c></returns>
        public List<Miembro> BuscarAmigos (Miembro miembro)
        {

        }
        /// <summary>
        /// Metodo que devuelve la lista de todos los <c>Post</c>
        /// </summary>
        /// <returns>Lista de <c>Post</c></returns>
        public List<Post> DevolverListaPost()
        {

        }
        /// <summary>
        /// Metodo que devuelve una lista con todos los <c>Comentarios</c>
        /// </summary>
        /// <returns>Lista de <c>Comentarios</c></returns>
        public List<Comentario> DevolverListaComentarios()
        {

        }
        /// <summary>
        /// Metodo que devuelve una lista de todos los <c>Post</c> que ha realizado un <c>Miembro</c>
        /// </summary>
        /// <param name="miembro"></param>
        /// <returns>Lista de <c>Post</c></returns>
        public List<Post> DevolverListaPostPorMiembro(Miembro miembro)
        {

        }
        /// <summary>
        /// Metodo que devuelve una lista de todos los <c>Comentarios</c> que ha realizado un <c>Miembro</c>
        /// </summary>
        /// <param name="miembro"></param>
        /// <returns>Lista de <c>Comentarios</c></returns>
        public List<Comentario> DevolverListaComentarioPorMiembro (Miembro miembro)
        {
            // No deberiamos tener tambien una lista de comentarios por post?
        }
        #endregion

    }
}



