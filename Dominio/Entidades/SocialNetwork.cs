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
        public Miembro BuscarMiembro(string email)
        {

        }
        public void BloquearMiembro(Miembro miembro)
        {

        }
        public void CensurarComentario(Miembro miembro, Comentario comentario)
        {

        }
        public void GestionSolicitud(Solicitud solicitud)
        {

        }
        public List<Solicitud> ActualizarAmigos(Miembro miembro)
        {

        }
        public List<Miembro> MostrarMiembrosDisponiblesParaAmistad(Miembro miembro)
        {

        }
        public void EnviarSolicitud(Miembro miembro)
        {

        }
        public List<Miembro> BuscarAmigos (Miembro miembro)
        {

        }
        public List<Post> DevolverListaPost()
        {

        }
        public List<Comentario> DevolverListaComentarios()
        {

        }
        public List<Post> DevolverListaPostPorMiembro(Miembro miembro)
        {

        }
        public List<Comentario> DevolverListaComentarioPorMiembro (Miembro miembro)
        {

        }
        #endregion

    }
}



