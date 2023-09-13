namespace Dominio.Entidades
{
    public class Comentario : Publicacion
    {
        #region Constructores

        public Comentario() { }

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
