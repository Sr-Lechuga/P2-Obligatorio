namespace Dominio.Entidades
{
    public class Administrador : Usuario
    {
        #region  Constructores

        public Administrador(string email, string contrasenia) : base(email, contrasenia)
        {
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Permite a un <c>Administrador</c> bloquear a un miembro del sistema
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> que el <c>Administrador</c> quiere bloquear</param>
        public void BloquearMiembro(Miembro miembro)
        {
            //NEXT: Segunda entrega
        }

        /// <summary>
        /// Permite a un <c>Administrador</c> censurar un <c>Post</c> realizado por un <c>Miembro</c>
        /// </summary>
        /// <param name="post"><c>Post</c> que el <c>Administrador</c> quiere censurar</param>
        public void CensurarPost(Post post)
        {
            //NEXT: Segunda entrega
        }

        //Override
        public override string ToString()
        {
            return $"El administrador es: {Email}";
        }

        #endregion

        #region Overrided Methods
        public override string Rol()
        {
            return "administrador";
        }
        #endregion
    }
}
