using Dominio.Entidades;

namespace Dominio.ExcepcionesPersonalizadas
{
    [Serializable]
    public class MemberNotFound : Exception
    {
        public Miembro? Miembro { get; }

        public MemberNotFound(string mensaje = "No se encontro el miembro en el sistema") : base(mensaje) { }

        public MemberNotFound(Miembro miembro, string mensaje = "No se encontro el miembro en el sistema") : base(mensaje)
        {
            Mensaje = mensaje;
            Miembro = miembro;
        }
    }
}
