namespace Dominio.Entidades
{
    public class Comentario : Publicacion
    {
        #region Constructores

        public Comentario() : base() 
        { 
            //TODO: Cheuqear quehaga el autoincremento de el constructor base
        }

        #endregion

        #region Metodos

        public void Validar()
        {
            //TODO: Lleva alguna validacion (?)
        }

        private void ValidarVisibilidad()
        {
            //TODO: Consultar, deberia ir en realidad en publicacion o en sistema o donde
        }

        #endregion
    }
}
