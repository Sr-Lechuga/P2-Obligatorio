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
        }
        #endregion

        #region Constructores

        public Usuario(string email, string contrasenia)
        {
            _email = email;
            _contrasenia = contrasenia;
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
            if (email[0] == '@' || email[email.Length - 1] == '@')
                throw new Exception("El arroba no puede estar al comienzo ni al final del mail");
            if (!email.Contains('.'))
                throw new Exception($"El email ingresado: {email}, no contiene dominio");
            if (email.Length < 5)
                throw new Exception("El email debe contener al menos 5 caracteres");/*minimo: a@a.a*/
        }

        private void ValidarContrasenia(string contrasenia)
        {
            if (contrasenia.Length < 8) /*Charla con profe 04/10*/
                throw new Exception("La constrasenia debe contener al menos 8 caracteres");
        }
        #endregion

        #region Overrided Methods
        public override string ToString()
        {
            return $"El suaurio es {Email}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null||!(obj is Usuario otroUsuario))
                return false;

            return  this._email == otroUsuario._email;
        }
        #endregion
    }
}
