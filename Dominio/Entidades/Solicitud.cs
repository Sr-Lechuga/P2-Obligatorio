using Dominio.Enum;
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Solicitud : IValidable
    {
        #region Atributos

        private static int s_ultId = 1;
        private int _id;
        private Miembro _solicitante;
        private Miembro _solicitado;
        private EstadoSolicitud _estado;
        private DateTime _fechaSolicitud;

        #endregion

        #region Propiedades

        public int Id
        {
            get { return _id; } 
        }

        public Miembro Solicitante
        {
            get { return _solicitante; }
        }

        public Miembro Solicitado 
        {
            get { return _solicitado; } 
        }

        public EstadoSolicitud Estado
        {
            get { return _estado;}
        }

        public DateTime FechaSolicitud
        {
            get { return _fechaSolicitud; }
        }

        #endregion

        #region Constructores

        public Solicitud (Miembro solicitante, Miembro solicitado)
        {
            _id = s_ultId++;

            //TODO: Validar que los atributos solicitado y solicitante no sean nulos
            _solicitante = solicitante;
            _solicitado = solicitado;

            _estado = EstadoSolicitud.PENDIENTE_APROVACION;
            _fechaSolicitud = DateTime.Now;
        }

        #endregion

        #region Metodos

        public void Validar()
        {
            ValidarSolicitante();
            ValidarSolicitado();
        }

        public void ValidarSolicitante()
        {
            //TODO: Validar que un miembro sea un objeto valido no vacio
        }

        public void ValidarSolicitado()
        {
            //TODO: Validar que un miembro sea un objeto valido no vacio
        }

        #endregion

        #region Metodos sobreescritos

        public override string ToString()
        {
            return $"El miembro {_solicitante.Nombre} realizo una solicitud al miembro {_solicitado.Nombre}.\n" +
                $"El dia {_fechaSolicitud.Date} y esta en estado {_estado}.";
        }

        #endregion
    }
}
