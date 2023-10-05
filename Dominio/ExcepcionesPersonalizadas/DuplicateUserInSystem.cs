namespace Dominio.ExcepcionesPersonalizadas
{
    [Serializable]
    public class DuplicateUserInSystem : Exception
    {
        public DuplicateUserInSystem(string mensaje) : base(mensaje) {}
    }
}
