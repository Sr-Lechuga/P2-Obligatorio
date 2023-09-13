namespace Dominio.ExcepcionesPersonalizadas
{
    [Serializable]
    public class NameFormatException : Exception
    {
        public NameFormatException() { }

        public NameFormatException(string formatErrorDescription) : base(formatErrorDescription) { }
    }
}
