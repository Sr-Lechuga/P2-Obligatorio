﻿using System.Text.RegularExpressions;

namespace Dominio.Entidades
{
    public class Usuario
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
            init { Email = value; }
        }

        public string Contrasenia
        {
            //Dado que se puede cambiar la constraseña, se debe poder settear
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }
        #endregion

        #region Constructores
        public Usuario(string email, string contrasenia)
        {
            Email = email;
            Contrasenia = contrasenia;
        }
        #endregion

        #region Metodos
        public void Validar(string email, string contrasenia)
        {
            //if (ExisteUsuario(email))
            //    throw new Exception($"El mail {email} ya esta registrado. Intente loguearse");
            ValidarEmail(email);
            ValidarContrasenia(contrasenia);
        }

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
            Regex simboloRgx = new(@"[\W]{1}", RegexOptions.Compiled);

            //Retrieves a collection of matches with upper case letters
            MatchCollection match = MayusculaRgx.Matches(Email);
            if (match.Count < 1)
                throw new Exception("La contrasenia ingresada debe tener al menos 1 mayuscula, 1 numero y 1 simbolo");

            match = numeroRgx.Matches(Email);
            if (match.Count < 1)
                throw new Exception("La contrasenia ingresada debe tener al menos 1 mayuscula, 1 numero y 1 simbolo");

            match = simboloRgx.Matches(Email);
            if (match.Count < 1)
                throw new Exception("La contrasenia ingresada debe tener al menos 1 mayuscula, 1 numero y 1 simbolo");

        }
        #endregion

        #region Overrided Methods
        //Overrides
        public override string ToString()
        {
            return $"El suaurio es {Email}";
        }
        #endregion
    }
}
