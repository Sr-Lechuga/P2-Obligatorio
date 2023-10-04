namespace Dominio.Entidades
{
    public class Comentario : Publicacion
    {
        #region Constructores

        public Comentario(string titulo, string contenido, Miembro autor) : base(titulo, contenido, autor){}

        #endregion

        #region Metodos

        public bool PerteneceAlAutor(Miembro miembro)
        {
            return _autor.Equals(miembro);
        }

        #endregion
    }
}
