namespace Dominio.Entidades
{
    public class Publicacion
    {
        #region Atributos

        private static int s_lastId;
        private int _id;
        private string _titulo;
        private Miembro _autor;
        private DateTime _fecha;
        private string _contenido;
        private List<Reaccion> _reacciones;

        #endregion

        #region Propiedades
        public int Id
        {
            get { return _id; }
        }

        public string Titulo
        {
            get { return _titulo; }
        }

        public Miembro Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
        }

        public string Contenido
        {
            get { return _contenido; }
            set { _contenido = value; }
        }

        public List<Reaccion> Reacciones
        {
            get { return _reacciones; }
            set { _reacciones = value;}
        }

        #endregion

        #region Constructores

        public Publicacion()
        {

        }

        /// <summary>
        /// Crea un objeto publicacion
        /// <para><b>Precondicion:</b>Tanto el titulo como el contenido no pueden ser vacios. Ademas el titulo debe contener al menos 3 caracteres</para>
        /// </summary>
        /// <param name="titulo">Titulo de la publicacion <para><b>Precondicion: </b>Debe contener al menos 3 caracteres</para></param>
        /// <param name="autor">Miembro autor de la publicacion</param>
        /// <param name="fecha">Fecha en que se realiza la publicacion</param>
        /// <param name="contenido">Contenido de la publicacion</param>
        /// <param name="reacciones">Lista de todas las reacciones que recibio la publicacion</param>
        public Publicacion(string titulo,Miembro autor, DateTime fecha, string contenido, List<Reaccion> reacciones)
        {
            _id = s_lastId++;
            _titulo = titulo;
            //TODO: El autor deberia setearse al hacer la publicacion automaticamente (?)
            //_autor = autor;
            _fecha = fecha;
            //Validado previamente para no ser vacio
            _contenido = contenido;
            //Si reaccciones es null, crea una lista vacia
            reacciones ??= new List<Reaccion>();
            _reacciones = reacciones;
        }


        #endregion

        #region Metodos

        //TODO: Implementar los posibles metodos de una publicacion

        #endregion
    }
}
