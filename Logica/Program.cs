using Dominio;
using Dominio.Entidades;
using Dominio.ExcepcionesPersonalizadas;

namespace Vista
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] opciones = {"Dar de alta a un miembro",
                "Listar publicaciones por tipo",
                "Listar post con comentarios",
                "Listar post entre fechas",
                "Mostrar miembros con mas publicaciones"
            };

            Console.WriteLine("--------------- Bienvenido a Social.Netwok ---------------\n");
            while (true)
            {
                DibujarOpciones(opciones);
                Console.WriteLine("\nIngrese el número de la opcion deseada. De lo contrario, ingrese 0 para salir.");

                bool exito = false;
                while (!exito)
                {
                    int opcion;
                    exito = int.TryParse(Console.ReadLine(), out opcion);

                    if (exito && opcion == 0)
                    {
                        Console.WriteLine("Hasta la proxima!");
                        Console.ReadKey();
                        return;
                    }

                    if (!exito)
                    {
                        Console.Clear();
                        DibujarOpciones(opciones);
                        Console.WriteLine("\nIngrese una opcion númerica valida. Para salir, ingrese 0.");
                    }
                    else
                    {
                        Console.Clear();
                        Enrutamiento(opcion);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

            }

        }
        
        /// <summary>
        /// Dado un array de opciones, muestra en consola todas las opciones disponibles en formato 'posicion.descripcion'
        /// <para><i><b>Nota:</b> el menu de opciones dibujado contiene un salto de pagina al comienzo y otro al final.</i></para>
        /// </summary>
        /// <param name="opciones">Contiene la descripcion de todas las opciones disponibles para el menu</param>
        private static void DibujarOpciones(string[] opciones)
        {
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine("{0}. {1}.", i + 1, opciones[i]);
            }
        }

        /// <summary>
        /// <para>De acuerdo a la opcion seleccionada, selecciona el o los metodo(s) correctos a ejecutar.</para>
        /// <para>En caso de no ser valida, solicita ingresar nuevamente una nueva opcion.</para>
        /// </summary>
        /// <param name="opcion">Opcion de menu seleccionada por el usuario</param>
        private static void Enrutamiento(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("--------------- Alta miembro ---------------\n");
                    AltaMiembro();
                    break;
                case 2:
                    Console.WriteLine("--------------- Listar publicaciones por tipo ---------------\n");
                    //ListarPublicacionesPorTipo();
                    break;
                case 3:
                    Console.WriteLine("--------------- Listar post(s) comentados ---------------\n");
                    //ListarPostComentados()
                    break;
                case 4:
                    Console.WriteLine("--------------- Listar post(s) entre fechas ---------------\n");
                    //ListarPostEntreFechas();
                    break;
                case 5:
                    Console.WriteLine("--------------- Mostrar miembros que mas comentan ---------------\n");
                    //MostrarMayoresComentaristas();
                    break;
                default:
                    Console.WriteLine("Ingrese una opcion valida del menu.");
                    return;
            }
        }

        private static void AltaMiembro()
        {
            SocialNetwork sistema = SocialNetwork.Instancia;
            Console.WriteLine("Los campos marcados con (*), son obligatorios\n");
            Console.Write("Ingrese el e-mail(*): ");
            string? email = Console.ReadLine();
            Console.Write("Ingrese la contraseña(*): ");
            string? contrasenia = Console.ReadLine();
            Console.Write("Ingrese su nombre: ");
            string? nombre = Console.ReadLine();
            Console.Write("Ingrese su apellido: ");
            string? apellido = Console.ReadLine();
            
            Console.Write("Ingrese su fecha de nacimiento en formato DD/MM/YYYY: ");
            bool exito = DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento);
            while (!exito)
            {
                Console.Write("Ingrese su fecha de nacimiento en formato DD/MM/YYYY: ");
                exito = DateTime.TryParse(Console.ReadLine(), out fechaNacimiento);
            }

            Miembro nuevoMiembro = new(email,contrasenia,nombre,apellido,fechaNacimiento);

            try
            {
                sistema.AltaMiembro(nuevoMiembro);
                Console.Write("\n¡Miembro agregado al sistema con exito!");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }

        }
    }
}
