using Dominio.Enum;

namespace Dominio.Entidades
{
    public class Solicitud
    {
        #region Atributos

        private static int s_lastId = 1;
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

        public Solicitud()
        {
            //Auto incremental
            _id = s_lastId++;

            //TODO: Validar que los atributos solicitado y solicitante no sean nulos
            
            _estado = new EstadoSolicitud();
            _estado = EstadoSolicitud.PENDIENTE_APROVACION;

            _fechaSolicitud = new DateTime();
            _fechaSolicitud = DateTime.Now;
        }

        public Solicitud (Miembro solicitante, Miembro solicitado)
        {
            _id = s_lastId++;

            //TODO: Validar que los atributos solicitado y solicitante no sean nulos
            _solicitante = solicitante;
            _solicitado = solicitado;

            _estado = new EstadoSolicitud();
            _estado = EstadoSolicitud.PENDIENTE_APROVACION;

            _fechaSolicitud = new DateTime();
            _fechaSolicitud = DateTime.Now;
        }

        #endregion

        #region Metodos
        public void ValidarMiembro()
        {
            //TODO: Validar que un miembro sea un objeto valido
        }
        public void AceptarSolicitud()
        {
            //TODO: Logica para aceptar una solicitud
        }

        public void RechazarSolicitud()
        {
            //TODO: Logica para rechazar una solicitud
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
