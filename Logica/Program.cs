using Dominio;
using Dominio.Entidades;
using Dominio.ExcepcionesPersonalizadas;
using System.Data;
using System.Globalization;
using System.Text;

namespace Vista
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Comentarios con emojis
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //Definimos la cultura como la de uruguay para no tener problemas con la fecha
            CultureInfo culturaUruaguaya = new CultureInfo("es-UY");
            CultureInfo.DefaultThreadCurrentCulture = culturaUruaguaya;
            CultureInfo.DefaultThreadCurrentUICulture = culturaUruaguaya;

            string[] opciones = {"Dar de alta a un miembro",
                "Listar publicaciones por tipo",
                "Listar post con comentarios",
                "Listar post entre fechas",
                "Mostrar miembros con más publicaciones"
            };

            while (true)
            {
                Console.Clear();
                //Demora para que cargue correctamente el menu
                Thread.Sleep(500);
                Console.WriteLine("--------------- Bienvenido a Social.Netwok ---------------\n");
                DibujarOpciones(opciones);
                Console.WriteLine("\nIngrese el número de la opción deseada. De lo contrario, ingrese 0 para salir.");

                bool exito = false;
                while (!exito)
                {
                    int opcion;
                    exito = int.TryParse(Console.ReadLine(), out opcion);

                    if (exito && opcion == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("¡Hasta la proxima!");
                        Console.ReadKey();
                        return;
                    }

                    if (exito)
                        Enrutamiento(opcion);

                    break;
                }

            }

        }

        /// <summary>
        /// Dada una lista de opciones, muestra en consola todas las opciones disponibles en formato 'posicion) descripcion'
        /// <para><i><b>Nota:</b> el menu de opciones dibujado contiene un salto de pagina al comienzo y otro al final.</i></para>
        /// </summary>
        /// <param name="opciones">Contiene la descripcion de todas las opciones disponibles para el menu</param>
        private static void DibujarOpciones(string[] opciones)
        {
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine("{0}) {1}.", i + 1, opciones[i]);
            }
        }

        /// <summary>
        /// <para>De acuerdo a la opcion seleccionada, selecciona el o los metodo(s) correctos a ejecutar.</para>
        /// <para>En caso de no ser valida, solicita ingresar nuevamente una nueva opcion.</para>
        /// </summary>
        /// <param name="opcion">Opcion de menu seleccionada por el usuario</param>
        private static void Enrutamiento(int opcion)
        {
            Console.Clear();
            Thread.Sleep(300);
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("--------------- Alta miembro ---------------\n");
                    AltaMiembro();
                    break;
                case 2:
                    Console.WriteLine("--------------- Listar publicaciones por tipo ---------------\n");
                    ListarPublicacionesPorTipo();
                    break;
                case 3:
                    Console.WriteLine("--------------- Listar post(s) comentados ---------------\n");
                    ListarPostComentados();
                    break;
                case 4:
                    Console.WriteLine("--------------- Listar post(s) entre fechas ---------------\n");
                    ListarPostEntreFechas();
                    break;
                case 5:
                    Console.WriteLine("--------------- Mostrar miembros que más comentan ---------------\n");
                    MostrarMayoresComentaristas();
                    break;
            }
            return;
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

            string mensaje = "Ingrese su fecha de nacimiento en formato DD/MM/AAAA: ";
            Console.Write(mensaje);
            DateTime fechaNacimiento = ObtenerFechaIngresada(mensaje);

            Miembro nuevoMiembro = new(email, contrasenia, nombre, apellido, fechaNacimiento);

            try
            {
                sistema.AltaMiembro(nuevoMiembro);
                Console.Write("\n¡Miembro agregado al sistema con éxito!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write($"\n{ex.GetType()}: {ex.Message}");
                Console.ReadKey();
            }

        }

        /// <summary>
        /// Lista las publicaciones por tipo
        /// <para><b>Excepción</b></para>
        /// <para>Si el email con el que se busca, no esta registrado en el sistema. Devuelve un error de miembro no encontrado <c>MemberNotFound</c></para>
        /// <para>Si el email con el que se busca, tiene un valor vacio o nulo devuelve una expecion de <c>ArgumentNullException</c></para>
        /// </summary>
        /// <returns>Lista de publicaciones Segun sean <c>Post</c> o <c>Comentarios</c></returns>
        /// <exception cref="MemberNotFound"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        private static void ListarPublicacionesPorTipo()
        {
            SocialNetwork sistema = SocialNetwork.Instancia;

            Console.WriteLine("Ingrese el mail del miembro que desea buscar");
            string? emailMiembroBuscado = Console.ReadLine();

            List<Post> posteosDelMiembro = new List<Post>();
            List<Comentario> comentariosDelMiembro = new List<Comentario>();

            try
            {
                List<Publicacion> listaPublicacionesDelMiembro = sistema.DevolverListaPublicacionesDelMiembro(emailMiembroBuscado);

                foreach (Publicacion publicacion in listaPublicacionesDelMiembro)
                {
                    if (publicacion is Post)
                        posteosDelMiembro.Add((Post)publicacion);
                    else
                        comentariosDelMiembro.Add((Comentario)publicacion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n\n** Posteos del miembro buscado **" + "\n");
            foreach (Post posteo in posteosDelMiembro)
            {
                Console.WriteLine(posteo.ToString() + "\n");
            }

            Console.WriteLine("\n** Comentarios del miembro buscado **" + "\n");
            foreach (Comentario comentario in comentariosDelMiembro)
            {
                Console.WriteLine(comentario + "\n");
            }

            Console.Write("\n---------- No hay más publicaciones para mostrar ----------");
            Console.ReadKey();

        }

        private static void ListarPostComentados()
        {
            SocialNetwork sistema = SocialNetwork.Instancia;

            Console.WriteLine("Ingrese el mail del miembro que desea buscar");
            string? emailMiembroBuscado = Console.ReadLine();

            try
            {
                List<Post> postComentadosPorMiembro = sistema.DevolverListaPostComentadosPorMiembro(emailMiembroBuscado);

                Console.WriteLine("\n** El miembro buscado ha comentado los siguientes posts. **\n\n");
                foreach (Post posteo in postComentadosPorMiembro)
                {
                    Console.WriteLine(posteo + "\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
            }

            Console.Write("\n---------- No hay más publicaciones para mostrar ----------");
            Console.ReadKey();
        }

        private static void ListarPostEntreFechas()
        {
            SocialNetwork sistema = SocialNetwork.Instancia;
            Console.WriteLine("Ingrese dos fechas y se mostrarán los post realizados en ese lapso de tiempo.");

            Console.Write("\nFecha comienzo (DD/MM/AAAA):");
            DateTime fechaComienzo = ObtenerFechaIngresada("Fecha comienzo (DD/MM/AAAA):");

            Console.Write("Fecha fin (DD/MM/AAAA):");
            DateTime fechaFin = ObtenerFechaIngresada("Fecha fin (DD/MM/AAAA):");
            
            if (fechaFin < fechaComienzo) //TODO chequear si es referencia o valor
            {
                DateTime fechaAux = fechaFin;
                fechaFin = fechaComienzo;
                fechaComienzo = fechaAux;
            }

            List<Post> postEntreFechas = sistema.PostsRealizadosEntreFechas(fechaComienzo, fechaFin);
            Console.WriteLine("\n** Los posteos realizados entre las fechas ingresadas son los siguientes **\n\n");
            
            foreach (Post posteo in postEntreFechas)
            {
                Console.WriteLine($"ID: {posteo.Id}\nFecha: {posteo.Fecha}\nTitulo: {posteo.Titulo}\nContenido: {posteo.Contenido.Substring(0, 50)}");
                Console.WriteLine();
            }

            Console.Write("\n---------- No hay más publicaciones para mostrar ----------");
            Console.ReadKey();
        }

        private static void MostrarMayoresComentaristas()
        {
            SocialNetwork sistema = SocialNetwork.Instancia;

            try
            {

            List<Miembro> miembrosMasPublicaciones = sistema.MiembrosConMasPublicaciones();

            foreach (Miembro miembro in miembrosMasPublicaciones)
            {
                string miembroBloqueado = "";
                if (miembro.Bloqueado)
                    miembroBloqueado = "El miembro se encuentra bloqueado";
                else
                    miembroBloqueado = "El miembro no se encuentra bloqueado";
                Console.WriteLine($"Nombre: {miembro.Nombre} | Apellido: {miembro.Apellido} | Fecha de nacimiento: {miembro.FechaNacimiento} | Bloqueo: {miembroBloqueado}");
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
            }
            Console.Write("\n---------- No hay más miembros para mostrar ----------");
            Console.ReadKey();

        }

        /// <summary>
        /// Toma una fecha por consola en formato DD/MM/AAAA y la transforma en un objeto <c>DateTime</c>
        /// <para><i><b>Nota: </b>El formato de la fecha debe respetar el indicado o vuelve a pedirlo</i></para>
        /// </summary>
        /// <returns>Un objeto de tipo <c>DateTime</c> con la fecha ingresada por consola</returns>
        private static DateTime ObtenerFechaIngresada(string mensaje)
        {
            bool exito = DateTime.TryParse(Console.ReadLine(), out DateTime fechaIngresada);
            while (!exito)
            {
                Console.Write(mensaje);
                exito = DateTime.TryParse(Console.ReadLine(), out fechaIngresada);
            }
            return fechaIngresada;
        }
    }
}
