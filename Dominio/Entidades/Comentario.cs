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

        #region Overrided Methods

        public override string ToString()
        {
            return $"Fecha:{_fecha}\nContenido: {_contenido}";
        }

        public override int CalcularValorAceptacion()
        {

            int likes = 0;
            int dislikes = 0;
            foreach (Reaccion reaccion in Reacciones)
            {
                if (reaccion.Like)
                    likes++;
                else
                    dislikes++;
            }

            return (likes * 5) + (dislikes * -2);
        }
        #endregion
    }
}
