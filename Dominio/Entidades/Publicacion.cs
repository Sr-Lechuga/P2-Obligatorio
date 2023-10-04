using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Publicacion : IValidable
    {
        #region Atributos

        private static int s_ultId;
        private int _id;
        private string _titulo;
        private string _contenido;
        private Miembro _autor;
        private DateTime _fecha;
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

        /// <summary>
        /// Crea un objeto publicacion
        /// <para><b>Precondicion: </b>Tanto el titulo como el contenido no pueden ser vacios. Ademas el titulo debe contener al menos 3 caracteres</para>
        /// </summary>
        /// <param name="titulo">Titulo de la publicacion <para><b>Precondicion: </b>Debe contener al menos 3 caracteres</para></param>
        /// <param name="autor">Miembro autor de la publicacion</param>
        /// <param name="contenido">Contenido de la publicacion</param>
        public Publicacion(string titulo, string contenido, Miembro autor)
        {
            _id = s_ultId++;

            _titulo = titulo;
            _contenido = contenido;
            _autor = autor;

            _fecha = DateTime.Now;
            _reacciones = new List<Reaccion>();
        }



        #endregion

        #region Metodos

        public void Validar()
        {
        }

        private void EsReaccionUnica(Miembro miembro)
        {
            //TODO: Miembro no puede reaccionar dos veces. Tiene que asegurarse que en la lista no se repita el miembro pasado por parametro
        }

        private void ValidarTitulo()
        {
            //TODO: El titulo no puede ser vacio, debe contener al menos 3 caracteres
        }

        public void ValidarContenido()
        {
            //TODO: El contendio no puede ser vacio
        }
        //TODO: Implementar los posibles metodos de una publicacion

        #endregion
    }
}
