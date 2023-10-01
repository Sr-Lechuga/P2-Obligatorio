using Dominio.Entidades;

namespace Dominio
{
    internal class SocialNetwork
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
            _publicaciones = new List<Publicacion>();
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

        public void AltaMiembro() { }

        public void AltaAdmisitrador() { }

        public Miembro BuscarMiembro() { return null; /*Devuelve un miembro*/}

        public void BloquearMiembro() { }

        public void CensurarComentario(Comentario comentario) { }

        public void GestionSolicitud(Solicitud solicitud) { }

        public List<Solicitud> ActualizarAmigos(Miembro miembro) { return null; /*Devuelve lista miembros*/ }

        public List<Miembro> MostrarMiembrosDisponiblesParaAmistad() { return null; /*Devuleve lista de miembros*/ }

        public void EnviarSolicitud(Miembro miembro) { }

        public List<Miembro> BuscarAmigos(Miembro miembro) { return null; /*Devuelve lista de miembros*/ }

        public List<Comentario> DevolverListaComentarios() { return null; /*Dvuelve la lista total de comentarios*/ }

        public List<Post> DevolverListaComentariosPorMiembro(Miembro miembro) { return null; /*Devuelve una lista de post filtrada por miemro*/ }

        public List<Comentario> DevolverListaComentarioPorMiembro(Miembro miembro ) { return null; /*Devuelve una lista de comentarios de un miembro*/}
        #endregion

    }
}
