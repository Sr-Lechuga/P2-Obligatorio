using Dominio.Entidades;

namespace Dominio
{
    public class SocialNetwork
    {
        #region Patron Singleton
        //Atrbuto de instancia statico
        private static SocialNetwork _instancia;
        
        //Constructor
        private SocialNetwork()
        {
            _administradores = new List<Administrador>();
            _miembros = new List<Miembro>();
            _relaciones = new List<Solicitud>();
            _publicaciones = new List<Post>();
        }

        //Propiedad para recuperar info de isntancia
        public static SocialNetwork Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SocialNetwork();

                return _instancia;
            }
        }

        #endregion

        #region Atributos

        private List<Administrador> _administradores;
        private List<Miembro> _miembros;
        private List<Solicitud> _relaciones;
        private List<Post> _publicaciones;
        private Usuario _usuarioDeSesion;
        #endregion

        #region Propiedades
        //Todas las listas son recupeerables, pero no pse pueden modificar fuera de la clase sistema
        public List<Administrador> Administradores { get { return _administradores; } }
        public List<Miembro> Miembros { get { return _miembros; } }
        public List<Solicitud> Solicitudes { get { return _relaciones; } }
        public List<Post> Publicaciones { get { return _publicaciones;} }

        #endregion

        #region Metodos

        public void ingresarSistema() 
        {
            //TODO: como hacer para identificar si el usuario logueado es un administrador o es un miembro
        }


        public void AltaMiembro(Miembro miembro) 
        {
            miembro.Validar();
            _miembros.Add(miembro);
        }

        public void AltaAdmisitrador() { }


        /// <summary>
        /// Metodo que permite buscar un <c>Miembro</c> en el sistema
        /// </summary>
        /// <param name="email">
        /// <c>Email</c> con el que se busca a un <c>Miembro</c>
        /// </param>
        /// <returns><c>Miembro</c></returns>
        public Miembro BuscarMiembro() { return null; /*Devuelve un miembro*/}

        /// <summary>
        /// Metodo que permite al <c>Administrador</c> bloquear un miembro
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> a bloquear </param>
        public void BloquearMiembro() { }

        /// <summary>
        /// Metodo que permite al <c>Administrador</c> censurar un comentario
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> que realizo el comentario</param>
        /// <param name="comentario"><c>Comentario</c> a censurar</param>
        public void CensurarComentario(Comentario comentario) { }

        /// <summary>
        /// Metodo que permite gestionar una solicitud
        /// </summary>
        /// <param name="solicitud"> <c>Solicitud</c> que se va a gestionar </param>
        public void GestionSolicitud(Solicitud solicitud) { }

        /// <summary>
        /// Metodo que permite actualizar las <c>Relaciones</c> entre los <c>Miembros</c>
        /// </summary>
        /// <param name="miembro"><c>Miemro</c> a actualizar</param>
        public List<Solicitud> ActualizarAmigos(Miembro miembro) { return null; /*Devuelve lista miembros*/ }

        /// <summary>
        /// Metodo que muestra los <c>Miembros</c> disponibles para amistad
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> al que se le mostrara la lista de amigos disponibles</param>
        /// <returns>Lista de <c>Miembros</c></returns>
        public List<Miembro> MostrarMiembrosDisponiblesParaAmistad() { return null; /*Devuleve lista de miembros*/ }

        /// <summary>
        /// Metodo que permite enviar una <c>Solicitud</c> de amistad
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> al que se le enviara la solicitud</param>
        public void EnviarSolicitud(Miembro miembro) { }

        /// <summary>
        /// Metodo que muestra a los amigos de un <c>Miembro</c>
        /// </summary>
        /// <param name="miembro"> <c>Miembro</c> al que se le mostrara la lista de <c>Miembros</c> que son sus amigos</param>
        /// <returns>Lista de <c>Miembros</c></returns>
        public List<Miembro> BuscarAmigos(Miembro miembro) { return null; /*Devuelve lista de miembros*/ }

        /// <summary>
        /// Metodo que devuelve una lista con todos los <c>Comentarios</c>
        /// </summary>
        /// <returns>Lista de <c>Comentarios</c></returns>
        public List<Comentario> DevolverListaComentarios() { return null; /*Dvuelve la lista total de comentarios*/ }

        /// <summary>
        /// Metodo que devuelve una lista de todos los <c>Post</c> que ha realizado un <c>Miembro</c>
        /// </summary>
        /// <param name="miembro"></param>
        /// <returns>Lista de <c>Post</c></returns>
        public List<Post> DevolverListaPostPorMiembro(Miembro miembro) { return null; /*Devuelve una lista de post filtrada por miemro*/ }

        /// <summary>
        /// Metodo que devuelve una lista de todos los <c>Comentarios</c> que ha realizado un <c>Miembro</c>
        /// </summary>
        /// <param name="miembro"></param>
        /// <returns>Lista de <c>Comentarios</c></returns>
        //TODO: No deberiamos tener tambien una lista de comentarios por post?
        public List<Comentario> DevolverListaComentarioPorMiembro(Miembro miembro ) { return null; /*Devuelve una lista de comentarios de un miembro*/}
        #endregion

    }
}
