using Dominio.ExcepcionesPersonalizadas;

namespace Dominio.Entidades
{
    public class Miembro : Usuario, IEquatable<Miembro>
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
        }

        public string Apellido
        {
            get { return _apellido; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
        }

        public bool Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }

        #endregion

        #region Constructores
        
        /// <summary>
        /// Constructor de un <c>Miembro</c>
        /// </summary>
        /// <param name="email">Email que sera el identificador del usuario en el sistema</param>
        /// <param name="contrasenia">Palabra clave con la que accede al sitio</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="fechaNacimiento">Fecha de naciemiento del usuario en formato DD/MM/YYYY</param>
        public Miembro(string email,string contrasenia,string nombre,string apellido, DateTime fechaNacimiento) : base(email, contrasenia)
        {
            _nombre = nombre; 
            _apellido = apellido; 
            _fechaNacimiento = fechaNacimiento;

            _bloqueado = false;
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
        private void ValidarFechaNacimiento()
        {
            if (DateTime.Today < _fechaNacimiento )
                throw new Exception("La fecha de nacimiento debe ser menor a la fecha actual");
        }

        /// <summary>
        /// Valida que el nombre elegido no sea vacio      
        /// <para>Exception:</para>
        /// NameFormatException - En caso de que el nombre sea vacio, arroja un error.
        /// </summary>
        /// <exception cref="NameFormatException"></exception> 
        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre))
                throw new NameFormatException("El nombre ingresado es vacio. Intenelo con uno nuevo nuevo");
        }

        /// <summary>
        /// Valida que el apellido elegido no sea vacio      
        /// <para>Exception:</para>
        /// NameFormatException - En caso de que el apellido sea vacio, arroja un error.
        /// </summary>
        /// <exception cref="NameFormatException"></exception> 
        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(_apellido))
                throw new NameFormatException("El apellido ingresado es vacio. Intenelo con uno nuevo nuevo");
        }

        #region segunda entrega
        /// <summary>
        /// Aceptar o rechazar una solicitud de amistad
        /// </summary>
        /// <param name="miembro">El <c>Miembro</c> que realizo la solicitud</param>
        /// <returns>Devuelve la respuesta a la solicitud, siendo <c>true</c> si la acepto y <c>false</c> si la rechazo</returns>
        public bool AceptarSolicitud(Miembro miembro)
        {
            //NEXT: Segunda entrega
            return true;
        }
        #endregion

        #endregion

        #region Overrided Methods

        public override string ToString()
        {
            return $"Es el miembro: {Nombre},{Apellido}.";
        }

        /// <summary>
        /// Se compara la igualdad de los miembros segun su email
        /// </summary>
        /// <param name="other">Otro <c>Miembro</c> para comparar con el actual</param>
        /// <returns></returns>
        public bool Equals(Miembro? other)
        {
            //Un miembro sera igual a otro si el email es el mismo
            return other is Miembro otroMiembro && this.Email == otroMiembro.Email;
        }


        #endregion
    }
}
