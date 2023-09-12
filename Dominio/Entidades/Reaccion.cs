namespace Dominio.Entidades
{
    public class Reaccion
    {
        #region Atributos

        private bool _like;
        private Miembro _miembro;

        #endregion

        #region Propiedades

        public bool Like
        {
            get { return _like; }
            //Debe ser posible cambiar la opinion acerca de una publicacion
            set { _like = value; }
        }

        public Miembro Miembro
        {
            get { return _miembro; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Permite crear una reaccion de un <c>Miembro</c> a una <c>Publicacion</c>.
        /// </summary>
        /// <param name="miembro"><c>Miembro</c> que reacciona</param>
        /// <param name="like">Reaccion del miembro
        /// <para>Puede ser un me gusta o un no me gusta (true o false respectivamente)</para>
        /// <para><i><b>Nota: </b>El valor por defecto es <c>true</c></i></para>
        /// </param>
        public Reaccion(Miembro miembro, bool like = true)
        {
            _like = like;
            _miembro = miembro;
        }

        #endregion

        #region Metodos

        public void Validar()
        {
            //TODO: Deberia ser una validacion de sistema, ya que es la entidad que conoce la informacion global (cosnultar)
            //EsReaccionUnica();
        }

        /// <summary>
        /// Permite modificar el tipo de reaccion
        /// </summary>
        /// <param name="nuevaReaccion">Nueva reacciono de un <c>Miembro</c> a una <c>Publicacion</c>.</param>
        public void ModificarReaccion(bool nuevaReaccion)
        {
            //TODO: Logica para el cambio de una reaccion
        }
        #endregion

        #region Metodos sobreescritos

        public override string ToString()
        {
            return $"Al miembro {Miembro.Nombre}, {(Like ? "le gusto" : "no le gusto")} la publicacion";
        }

        #endregion
    }
}
