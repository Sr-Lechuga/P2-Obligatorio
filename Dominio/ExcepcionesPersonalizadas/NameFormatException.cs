namespace Dominio.ExcepcionesPersonalizadas
{
    [Serializable]
    public class NameFormatException : Exception
    {
        public string? Mensaje { get; };
        public NameFormatException(string mensaje = "El formato del nombre/apellido no es correcto")
        {
            Mensaje = mensaje;
        }
    }
}
