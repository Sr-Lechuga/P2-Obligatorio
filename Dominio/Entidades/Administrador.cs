namespace Dominio.Entidades
{
    public class Administrador : Usuario
    {
        #region  Cosntructores

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
            //TODO: Logica para bloquear miembros
        }

        /// <summary>
        /// Permite a un <c>Administrador</c> censurar un comentario realizado por un <c>Miembro</c>
        /// </summary>
        public void CensurarComentario()
        {
            //TODO: Logica para censurar comentarios
        }

        //Override
        public override string ToString()
        {
            return $"El administrador es: {Email}";
        }
    }
}
