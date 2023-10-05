using Dominio.Entidades;

namespace Dominio.ExcepcionesPersonalizadas
{
    [Serializable]
    internal class MemberNotFound : Exception
    {
        public Miembro Miembro { get; }

        public MemberNotFound(string mensaje) { }

        public MemberNotFound(string mensaje, Miembro miembro) 
        {
            Miembro = miembro;
        }
    }
}
