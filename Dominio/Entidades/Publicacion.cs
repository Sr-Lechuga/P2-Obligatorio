 using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public abstract class Publicacion : IValidable
    {
        #region Atributos

        private static int s_ultId = 1;
        protected int _id;
        protected string _titulo;
        protected string _contenido;
        protected Miembro _autor;
        protected DateTime _fecha;
        protected List<Reaccion> _reacciones;

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
        }

        public List<Reaccion> Reacciones
        {
            get { return _reacciones; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Crea un objeto publicacion
        /// <para><b>Precondicion: </b>Tanto el titulo como el contenido no pueden ser vacios. Ademas el titulo debe contener al menos 3 caracteres</para>
        /// </summary>
        /// <param name="titulo">Titulo de la publicacion <para><b>Precondicion: </b>Debe contener al menos 3 caracteres</para></param>
        /// <param name="autor">Miembro autor de la publicacion</param>
        /// <param name="contenido">Contenido de la publicacion<b>Precondicion: </b>No puede ser vacio</para></param>
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
            ValidarTitulo();
            ValidarContenido();
        }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(_titulo))
                throw new Exception("El titulo no puede ser vacio");
            if (_titulo.Length < 3)
                throw new Exception("El titulo debe contener al menos 3 caracteres");
        }

        private void ValidarContenido()
        {
            if (string.IsNullOrEmpty(_contenido))
                throw new Exception("El contenido no puede ser vacio");
        }

        public void AgregarOModificarReaccion (Miembro miembro, bool like)
        {
            Reaccion reaccion = new Reaccion(miembro, like);

            if (EsReaccionUnica(miembro))
                _reacciones.Add(reaccion);
            else
            {
                Reaccion reaccionDePublicacion = BuscarReaccion(miembro);
                reaccionDePublicacion.ModificarReaccion(like);
            }
        }

        private bool EsReaccionUnica(Miembro miembro)
        {
            int i = 0;
            bool habiaReaccionado = false;
            while (!habiaReaccionado && i < _reacciones.Count)
            {
                if (_reacciones[i].Miembro.Equals(miembro))
                    habiaReaccionado = true;
                i++;
            }

            return !habiaReaccionado;
        }

        private Reaccion BuscarReaccion(Miembro miembro)
        {
            int i = 0;
            Reaccion? reaccion = null;
            while ( reaccion == null && i < _reacciones.Count)
            {
                if (_reacciones[i].Miembro.Equals(miembro))
                    reaccion = _reacciones[i];
                i++;
            }

            return reaccion;
        }

        public int CantidadMeGusta()
        {
            int cantidadMeGusta = 0;

            foreach (Reaccion reaccion in _reacciones)
            {
                if (reaccion.Like)
                    cantidadMeGusta++;
            }
            return cantidadMeGusta;
        }

        public int CantidadNoMeGusta()
        {
            int cantidadNoMeGusta = 0;

            foreach (Reaccion reaccion in _reacciones)
            {
                if (!reaccion.Like)
                    cantidadNoMeGusta++;
            }
            return cantidadNoMeGusta;
        }

        #endregion

        #region

        public abstract int CalcularValorAceptacion();

        #endregion
    }
}
