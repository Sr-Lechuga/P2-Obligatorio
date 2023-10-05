namespace Dominio.ExcepcionesPersonalizadas
{
    [Serializable]
    internal class DuplicateUserInSystem : Exception
    {
        public string Mensaje { get; }
        public DuplicateUserInSystem(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}
