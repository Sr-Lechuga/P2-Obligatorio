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
        public Miembro(string email, string contrasenia) : base(email, contrasenia)
        {

        }
        public Miembro(
            string email,
            string contrasenia,
            string? nombre,
            string? apellido,
            DateTime? fechaNacimiento
            ) : base(email, contrasenia)
        {
            _nombre = nombre;
            _apellido = apellido;

            if (fechaNacimiento == null)
                _fechaNacimiento = DateTime.MinValue;
            else
                _fechaNacimiento = (DateTime)fechaNacimiento;

            _bloqueado = false;
        }

        #endregion

        #region Metodos

        public List<Miembro> ObtenerMiembros()
        {
            List<Miembro> miembrosPrecargados = new List<Miembro>
            {
                new Miembro("juan.perez@email.com", "contraseña123", "Juan", "Pérez", new DateTime(1990, 5, 15)),
                new Miembro("maria.gonzalez@email.com", "clave456", "María", "González", new DateTime(1985, 9, 22)),
                new Miembro("carlos.lopez@email.com", "password789", "Carlos", "López", new DateTime(1993, 3, 8)),
                new Miembro("laura.martinez@email.com", "secret123", "Laura", "Martínez", new DateTime(1988, 7, 12)),
                new Miembro("andres.fernandez@email.com", "qwerty456", "Andrés", "Fernández", new DateTime(1982, 11, 3)),
                new Miembro("ana.rodriguez@email.com", "secure789", "Ana", "Rodríguez", new DateTime(1995, 2, 28)),
                new Miembro("david.gomez@email.com", "pass1234", "David", "Gómez", new DateTime(1987, 12, 17)),
                new Miembro("natalia.diaz@email.com", "mypassword", "Natalia", "Díaz", new DateTime(1991, 6, 9)),
                new Miembro("sergio.hernandez@email.com", "access567", "Sergio", "Hernández", new DateTime(1986, 4, 5)),
                new Miembro("elena.lopez@email.com", "testuser", "Elena", "López", new DateTime(1998, 8, 20))
            }
            return miembrosPrecargados
        }

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
        private void ValidarFechaNacimiento()
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
        private void ValidarNombre()
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
        private void ValidarApellido()
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
