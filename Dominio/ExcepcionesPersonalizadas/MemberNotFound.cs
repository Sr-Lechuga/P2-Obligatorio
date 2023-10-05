using Dominio.Entidades;

namespace Dominio.ExcepcionesPersonalizadas
{
    [Serializable]
    internal class MemberNotFound : Exception
    {
        public Miembro? Miembro { get; }
        public string Mensaje { get; }

        public MemberNotFound(string mensaje = "No se encontro el miembro en el sistema") 
        {
            Mensaje = mensaje;
        }

        public MemberNotFound(Miembro miembro, string mensaje = "No se encontro el miembro en el sistema" ) 
        {
            Mensaje = mensaje;
            Miembro = miembro;
        }
    }
}
