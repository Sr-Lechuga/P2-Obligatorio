namespace Dominio.Entidades
{
    public class Administrador : Usuario
    {
        //Cosntructores
        public Administrador(string email, string contrasenia) : base(email, contrasenia)
        {
        }

        //Metodos
        public void BloquearMiembro(Usuario miembro)
        {

        }

        public void CensurarComentario()
        {

        }

        //Override
        public override string ToString()
        {
            return $"El administrador es: {Email}";
        }
    }
}
