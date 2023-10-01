namespace Dominio.Entidades
{
    public class Miembro : Usuario
    {
        #region Atributos

        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private bool _bloqueado;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return _nombre; }
            //El nombre se puede cambiar
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public bool Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }

        #endregion

        #region Constructores

        public Miembro(
            List<Solicitud> amigos,
            DateTime fechaNacimiento,
            bool bloqueado = false,
            string nombre = "Natalia",
            string apellido = "Natalia"
            ) : base(nombre, apellido)
        {
            //Si amigos esta vacio, crea una nueva lista
            amigos ??= new List<Solicitud>();
            _amigos = amigos;
            _fechaNacimiento = fechaNacimiento;
            _bloqueado = bloqueado;
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
        }

        #endregion

        #region Metodos

        public override void Validar()
        {
            base.Validar();
            ValidarNombre();
            ValidarApellido();
            ValidarFechaNacimiento();
        }

        /// <summary>
        /// Valida que la fecha de nacimiento no sea posterior a la fecha actual
        /// <para>Exception:</para>
        /// Exception - En caso de ingresar una fecha posterior a la actual, arroja un error.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ValidarFechaNacimiento()
        {
            if (_fechaNacimiento > DateTime.Today)
                throw new Exception("La fecha de nacimiento debe ser menor a la fecha actual");
            //TODO: Create an custom exception for date of birth 
        }

        /// <summary>
        /// Valida que el nombre elegido no sea vacio      
        /// <para>Exception:</para>
        /// NameFormatException - En caso de que el nombre sea vacio, arroja un error.
        /// </summary>
        /// <exception cref="ExcepcionesPersonalizadas.NameFormatException"></exception> 
        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre))
                throw new ExcepcionesPersonalizadas.NameFormatException("El nombre ingresado es vacio. Intenelo con uno nuevo nuevo");
        }

        /// <summary>
        /// Valida que el apellido elegido no sea vacio      
        /// <para>Exception:</para>
        /// NameFormatException - En caso de que el apellido sea vacio, arroja un error.
        /// </summary>
        /// <exception cref="ExcepcionesPersonalizadas.NameFormatException"></exception> 
        public void ValidarApellido()
        {
            if (string.IsNullOrEmpty(_nombre))
                throw new ExcepcionesPersonalizadas.NameFormatException("El apellido ingresado es vacio. Intenelo con uno nuevo nuevo");
        }

        /// <summary>
        /// Aceptar o rechazar una solicitud de amistad
        /// </summary>
        /// <param name="miembro">El <c>Miembro</c> que realizo la solicitud</param>
        /// <returns>Devuelve la respuesta a la solicitud, siendo <c>true</c> si la acepto y <c>false</c> si la rechazo</returns>
        public bool AceptarSolicitud(Miembro miembro)
        {
            //TODO: Mostrar info del solicitante. Cambiar estado de solicitud a aceptada o rechazada
            return true;
        }

        /// <summary>
        /// Permite a un miembro realizar una publicacion de tipo <c>Post</c>
        /// </summary>
        /// <param name="titulo">Titulo de la publicacion. El mismo no puede ser vacio y debe contener al menos 3 caracteres</param>
        /// <param name="contenido">El contenido de la publicacion. La misma no puede ser vacia</param>
        /// <param name="imagen">Debe contener obligatoriamente una imagen <para><i><b>Nota:</b> Actualmente guarda la ruta de la imagen unicamente</i></para></param>
        /// <param name="privado">Define el alcance de un post. Toma dos valores posibles <c>publico o privado</c> siendo <c>publico</c> por default</param>
        //public void Publicar(string titulo, string contenido, string imagen, bool privado = false)
        //{
        //    //TODO: Logica para realizar una publicacion.
        //    #warning Es el usuario el que deberia publicar, o es la publicacion misma. Como implementar la limitacion entonces que solo los miembros publican
        //}

        /// <summary>
        /// Permite a un miembro realizar una publicacion de tipo <c>Comentario</c>
        /// </summary>
        /// <param name="titulo">Titulo de la publicacion. El mismo no puede ser vacio y debe contener al menos 3 caracteres</param>
        /// <param name="contenido">El contenido de la publicacion. La misma no puede ser vacia</param>
        //public void Comentar(string titulo, string contenido)
        //{
        //    //TODO: Logica de comentar una publicacion
        //    #warning Es el usuario el que deberia publicar, o es la publicacion misma. Como implementar la limitacion entonces que solo los miembros publican
        //}

        #endregion
        //TODO: Este es comentario de prueba pa los pibes
        #region Overrided Methods

        public override string ToString()
        {
            return $"Es el miembro: {Nombre},{Apellido}.";
        }

        #endregion
    }
}
