namespace Dominio.ExcepcionesPersonalizadas
{
    [Serializable]
    public class NameFormatException : Exception
    {
        public NameFormatException(string mensaje = "El formato del nombre/apellido no es correcto") : base(mensaje) { }
    }
}
