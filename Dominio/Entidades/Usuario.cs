using Dominio.Interfaces;
using System.Text.RegularExpressions;

namespace Dominio.Entidades
{
    public class Usuario : IValidable
    {
        #region Atributos
        private string _email;
        private string _contrasenia;
        #endregion

        #region Propiedades
        public string Email
        {
            //Una vez creado un usuario no deberia poder cambiarse el mail
            get { return _email; }
            init { _email = value; }
        }

        public string Contrasenia
        {
            //Dado que se puede cambiar la constraseña, se debe poder settear
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }
        #endregion

        #region Constructores

        //Deshabilitacion de constructor por defecto, los usuarios siempre deben tener usuario y contrasenia
        private Usuario() { }

        public Usuario(string email, string contrasenia)
        {
            Email = email;
            Contrasenia = contrasenia;
        }
        #endregion

        #region Metodos
        public virtual void Validar()
        {
            ValidarEmail(_email);
            ValidarContrasenia(_contrasenia);
        }

        /// <summary>
        /// Metodo que permite validar el email de un usuario en el sistma. Este no puede ser vacio y debe contener '@' y '.'
        /// </summary>
        /// <param name="email">Email que identifica al usuario en el sistema</param>
        /// <exception cref="Exception"></exception>
        private void ValidarEmail(string email)
        {
            if (email.Equals(string.Empty))
                throw new Exception($"El email ingresado no puede ser vacio");
            if (!email.Contains('@'))
                throw new Exception($"El email ingresado: {email}, no contiene @");
            if (!email.Contains('.'))
                throw new Exception($"El email ingresado: {email}, no contiene dominio");
        }

        private void ValidarContrasenia(string contrasenia)
        {
            Regex MayusculaRgx = new(@"[A-Z]{1}", RegexOptions.Compiled);
            Regex numeroRgx = new(@"[0-9]{1}", RegexOptions.Compiled);
            Regex simboloRgx = new(@"[\W\.]{1}", RegexOptions.Compiled);

            //Retrieves a collection of matches with upper case letters
            MatchCollection match = MayusculaRgx.Matches(_contrasenia);
            if (match.Count < 1)
                throw new Exception("La contrasenia ingresada debe tener al menos 1 mayuscula, 1 numero y 1 simbolo");

            match = numeroRgx.Matches(_contrasenia);
            if (match.Count < 1)
                throw new Exception("La contrasenia ingresada debe tener al menos 1 mayuscula, 1 numero y 1 simbolo");

            match = simboloRgx.Matches(_contrasenia);
            if (match.Count < 1)
                throw new Exception("La contrasenia ingresada debe tener al menos 1 mayuscula, 1 numero y 1 simbolo");

        }
        #endregion

        #region Overrided Methods
        public override string ToString()
        {
            return $"El suaurio es {Email}";
        }
        #endregion
    }
}
