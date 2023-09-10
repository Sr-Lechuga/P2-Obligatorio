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
                    //AltaMiemro();
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
    }
}