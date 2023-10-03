namespace Dominio.Entidades
{
    public class Post : Publicacion
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
            set { _imagen = value; }
        }
        public bool Privado
        {
            get { return _privado; }
            set { _privado = value; }
        }
        public List<Comentario> Comentarios
        {
            get { return _comentarios; }
        }
        public bool Censurado
        {
            get { return _censurado; }
            // no deberiamos poner set tambien??
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Permite crear un post con una imagen y definir si el post sera privado.
        /// <para><i>Nota: Al crearse un post, comienza sin ningún comentario</i></para>
        /// </summary>
        public Post()
        {
            _imagen = string.Empty;
            _comentarios = new List<Comentario>();
            _censurado = false;
        }

        /// <summary>
        /// Permite crear un post con una imagen y definir si el post sera privado.
        /// <para><i>Nota: Al crearse un post, comienza sin ningún comentario</i></para>
        /// </summary>
        /// <param name="image">
        /// Guarda la imagen del post
        /// <para><i><b>Nota: </b>Actualmente solo se guarda el nombre de la imagen.</i></para>
        /// </param>
        /// <param name="privado">
        /// Permite definir si un post es publico(<c>false</c>) o privado(<c>true</c>)
        /// </param>
        public Post(string image, bool privado) : base()
        {
            image ??= string.Empty;
            _imagen = image;
            _privado = privado;

            //Al crear una post el mismo no deberia tener comentarios ni deberia estar censurado
            _comentarios = new List<Comentario>();
            _censurado = false;
        }

        #endregion

        #region Metodos

        

        /// <summary>
        /// Permite agregar un <c>Comentario</c> a la lista de comentarios
        /// </summary>
        /// <param name="comentario">
        /// <c>Comentario</c> a agregar al <c>Post</c>
        /// </param>
        public void AgregarComentario(Comentario comentario)
        {
            //TODO: Logica para agregar un comentario al post
        }
        #endregion

        #region Metodos sobreescritos
        #endregion
    }
}
