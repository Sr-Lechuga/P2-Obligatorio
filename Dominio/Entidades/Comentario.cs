namespace Dominio.Entidades
{
    public class Comentario : Publicacion
    {
        #region Constructores

        public Comentario(string titulo, string contenido, Miembro autor) : base(titulo, contenido, autor){}

        #endregion

        #region Metodos

        public void Validar()
        {
            //TODO: Lleva alguna validacion (?)
        }
       
        public bool PerteneceAlAutor(Miembro miembro)
        {
            //TODO: Logica para saber si un comentario pertence a un usuario, tal vez va en Publicacion(?)
            return false;
        }

        #endregion
    }
}
