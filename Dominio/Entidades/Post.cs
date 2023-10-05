namespace Dominio.Entidades
{
    public class Post : Publicacion, IComparable<Post>
    {
        #region Atributos

        private string _imagen;
        private bool _privado;
        private List<Comentario> _comentarios;
        private bool _censurado;

        #endregion

        #region Propiedades
        public string Image
        {
            get { return _imagen; }
        }
        public bool Privado
        {
            get { return _privado; }
        }
        public List<Comentario> Comentarios
        {
            get { return _comentarios; }
        }
        public bool Censurado
        {
            get { return _censurado; }
            set { _censurado = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Permite crear un post con una imagen y definir si el post sera privado.
        /// <para><i>Nota: Al crearse un post, comienza sin ningún comentario</i></para>
        /// <para><i><b>Importante: </b>El titulo de un <c>Post</c> no puede ser vacio. Y debe contener al menos 3 caracteres.</i></para>
        /// <para><i><b>Importante: </b>El contenido de un <c>Post</c> no puede ser vacio.</i></para>
        /// </summary>
        /// <param name="titulo">Titulo del post <b>No puede ser vacio. Debe contener al menos 3 caracteres</b></param>
        /// <param name="contenido">Contenido del post <b>No puede ser vacio</b></param>
        /// <param name="autor"><c>Miembro</c> autor del <c>Post</c></param>
        /// <param name="imagen">Guarda la imagen del post<para><i><b>Nota: </b>Actualmente solo se guarda el nombre de la imagen.</i></para></param>
        /// <param name="privado">Permite definir si un post es publico(<c>false</c>) o privado(<c>true</c>)</param>
        public Post(string titulo, string contenido, Miembro autor, string imagen, bool privado = true) : base(titulo,contenido,autor)
        {
            _imagen = imagen;
            _privado = privado;

            _comentarios = new List<Comentario>();
            _censurado = false;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Permite agregar un <c>Comentario</c> a la lista de comentarios
        /// </summary>
        /// <param name="comentario"><c>Comentario</c> a agregar al <c>Post</c></param>
        public void AgregarComentario(Comentario comentario)
        {
            comentario.Validar();
            _comentarios.Add(comentario);
        }

        /// <summary>
        /// Devuleve una copia de la lista de comentarios del <c>Post</c>
        /// </summary>
        /// <returns>Lista de <c>Comentario</c></returns>
        public List<Comentario> DevolverListaComentarios()
        {
            //TODO: Devulver una lista copia de lso comentarios
            return _comentarios;
        }

        public List<Comentario> DevolverComentariosDelMiembro(Miembro miembro) 
        {
            List<Comentario> comentariosDelMiembro = new List<Comentario>();

            foreach (Comentario comentario in _comentarios)
            {
                if(comentario.PerteneceAlAutor(miembro))
                    comentariosDelMiembro.Add(comentario);
            }

            return comentariosDelMiembro;
        }

        public int CompareTo(Post? other)
        {
            return -1 * this.Titulo.CompareTo(other.Titulo);
        }
        #endregion
    }
}
