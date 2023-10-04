using Dominio.Entidades;

namespace Dominio
{
    public class SocialNetwork
    {
        #region Patron Singleton
        //Atrbuto de instancia statico
        private static SocialNetwork _instancia;

        //Constructor
        private SocialNetwork()
        {
            _administradores = new List<Administrador>();
            _miembros = new List<Miembro>();
            _relaciones = new List<Solicitud>();
            _posteos = new List<Post>();
        }

        //Propiedad para recuperar info de isntancia
        public static SocialNetwork Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SocialNetwork();

                return _instancia;
            }
        }

        #endregion

        #region Atributos

        private List<Administrador> _administradores;
        private List<Miembro> _miembros;
        private List<Solicitud> _relaciones;
        private List<Post> _posteos;
        private Usuario _usuarioDeSesion;
        #endregion

        #region Propiedades
        //Todas las listas son recupeerables, pero no pse pueden modificar fuera de la clase sistema
        public List<Administrador> Administradores { get { return _administradores; } }
        public List<Miembro> Miembros { get { return _miembros; } }
        public List<Solicitud> Solicitudes { get { return _relaciones; } }
        public List<Post> Posteos { get { return _posteos; } }

        #endregion

        #region Precargas
        private void PrecargaMiembros()
        {

            List<Miembro> miembrosPrecargados = new List<Miembro>
            {
                new Miembro("juan.perez@email.com", "contraseña123", "Juan", "Pérez", new DateTime(1990, 5, 15)),
                new Miembro("maria.gonzalez@email.com", "clave456", "María", "González", new DateTime(1985, 9, 22)),
                new Miembro("carlos.lopez@email.com", "password789", "Carlos", "López", new DateTime(1993, 3, 8)),
                new Miembro("laura.martinez@email.com", "secret123", "Laura", "Martínez", new DateTime(1988, 7, 12)),
                new Miembro("andres.fernandez@email.com", "qwerty456", "Andrés", "Fernández", new DateTime(1982, 11, 3)),
                new Miembro("ana.rodriguez@email.com", "secure789", "Ana", "Rodríguez", new DateTime(1995, 2, 28)),
                new Miembro("david.gomez@email.com", "pass1234", "David", "Gómez", new DateTime(1987, 12, 17)),
                new Miembro("natalia.diaz@email.com", "mypassword", "Natalia", "Díaz", new DateTime(1991, 6, 9)),
                new Miembro("sergio.hernandez@email.com", "access567", "Sergio", "Hernández", new DateTime(1986, 4, 5)),
                new Miembro("elena.lopez@email.com", "testuser", "Elena", "López", new DateTime(1998, 8, 20))
            };

            foreach (Miembro nuevoMiembro in miembrosPrecargados)
            {
                nuevoMiembro.Validar();
                _miembros.Add(nuevoMiembro);

            }
        }

        private void PrecargaPost()
        {
            Miembro posteadorAleatorio;
            Miembro comentaristaAleatorio;
            int indiceMiembroAleatorio;

            List<string> titulosPost = new List<string>
            {
                "Cancion favorita",
                "Deporte favorito",
                "Tecnologia que sorprende",
                "Libros y peliculas que dejan marcas",
                "Recorriendo el mundo"
            };

            List<string> contenidosPost = new List<string>
            {
                "¿Cuál es tu canción favorita de todos los tiempos? La música nos conecta de formas increíbles. ¡Comparte tu elección y cuéntanos por qué te gusta tanto!",
                "¿Cuál es tu deporte favorito para ver o practicar? ¡Hablemos de nuestra pasión por el deporte y nuestros equipos preferidos!",
                "¿Cuál es la última tecnología que te dejó boquiabierto? ¡Hablemos de los avances tecnológicos más emocionantes de estos tiempos!",
                "¿Cuál es tu libro o película favorita que te haya impactado profundamente? La cultura nos enriquece de maneras inimaginables. ¡Comparte tus recomendaciones!",
                "¿Cuál ha sido tu destino de viaje favorito hasta ahora? ¡Comparte tus experiencias viajeras y da consejos para futuros aventureros!"
            };

            List<string> imagenes = new List<string>
            {
                "concierto",
                "deportes",
                "PC",
                "biblioteca",
                "Aeropuerto",
            };

            List<string> contenidoComentario = new List<string>
            {
                "¡Me encanta 'Bohemian Rhapsody' de Queen! Es una obra maestra musical. 🎶❤️",
                "'Imagine' de John Lennon es una joya. Me hace reflexionar sobre la paz. ✌️",
                "'Hotel California' de Eagles es una canción clásica que nunca pasa de moda. 🦅🎸",
                "Soy un amante del fútbol. Mi equipo favorito es el Barcelona, ¡siempre emocionante verlos jugar! ⚽💙❤️",
                "Me gusta mucho el tenis. Roger Federer es mi ídolo, su estilo en la cancha es incomparable. 🎾👑",
                "El baloncesto es mi pasión. Los Lakers son mi equipo desde que era niño. ¡Vamos Lakers! 🏀💜💛",
                "La inteligencia artificial me fascina. Ver cómo los chatbots y asistentes virtuales pueden ayudarnos es sorprendente. 🤖🚀",
                "La realidad virtual me ha atrapado. Es asombroso cómo te sumerge en mundos virtuales. 🕶️🌌",
                "Los coches eléctricos son el futuro. Tesla está haciendo un gran trabajo en este campo. 🚗🔋",
                "El libro 'Cien años de soledad' de Gabriel García Márquez me marcó para siempre. Una obra maestra. 📚✨",
                "La película 'El Padrino' es un clásico indiscutible. La actuación de Marlon Brando es inolvidable. 🎥🍊",
                "Me encanta la serie 'Stranger Things'. La nostalgia de los años 80 y la trama sobrenatural son adictivas. 👽🚲",
                "Mi viaje a Japón fue inolvidable. La cultura, la comida y la amabilidad de la gente son increíbles. 🗾🍣🎎",
                "Recorrer la Ruta 66 en Estados Unidos fue una aventura única. Paisajes espectaculares y diners clásicos. 🇺🇸🚗",
                "Amo la playa, así que mi lugar favorito es Bali. Las playas de arena blanca y los templos son mágicos. 🏖️🌴🕌",
            };





            for (int iPost = 0; iPost < titulosPost.Count; iPost++) /*iPost = {0,4}*/
            {
                //Crear post
                posteadorAleatorio = DevolverMiembroAleatorio();
                Post unPost = new Post(titulosPost[iPost], contenidosPost[iPost], posteadorAleatorio, $"c:/img/{imagenes[iPost]}.png", false);
                unPost.Validar();

                //Agregarle comentarios

                for (int iComentario = iPost * 3/*iPost={0,3,6,9,12}*/; iComentario < (iPost + 1) * 3/*iPost={3,6,9,12,15}*/; iComentario++)
                {
                    comentaristaAleatorio = DevolverMiembroAleatorio();
                    Comentario comentario = new($"{comentaristaAleatorio.Nombre}:", contenidoComentario[iComentario], comentaristaAleatorio);
                    comentario.Validar();
                    unPost.AgregarComentario(comentario);
                }
                _posteos.Add(unPost);
            }
        }

        #endregion

        #region Metodos
            private Miembro DevolverMiembroAleatorio()
            {
                Random indiceRandom = new Random();
                int indiceMiembroAleatorio = indiceRandom.Next(0, _miembros.Count);

                return _miembros[indiceMiembroAleatorio];
            }

            public void ingresarSistema()
            {
                //TODO: como hacer para identificar si el usuario logueado es un administrador o es un miembro
            }


            public void AltaMiembro(Miembro miembro)
            {
                //TODO Cambiar la logica, para construir miembro y agregarlo
                miembro.Validar();
                _miembros.Add(miembro);
            }

            public void AltaAdmisitrador() { }


            /// <summary>
            /// Metodo que permite buscar un <c>Miembro</c> en el sistema
            /// </summary>
            /// <param name="email">
            /// <c>Email</c> con el que se busca a un <c>Miembro</c>
            /// </param>
            /// <returns><c>Miembro</c></returns>
            public Miembro BuscarMiembro(string nombre, string apellido)
            {
                foreach (Miembro miembro in _miembros)
                {
                    if (miembro.Nombre == nombre && miembro.Apellido == apellido)
                        return miembro;
                }
                //Devuelve un miembro *** HASTA AHI LLEGUE
                return null;
            }

            /// <summary>
            /// Metodo que permite al <c>Administrador</c> bloquear un miembro
            /// </summary>
            /// <param name="miembro"><c>Miembro</c> a bloquear </param>
            public void BloquearMiembro()
            {

            }

            /// <summary>
            /// Metodo que permite al <c>Administrador</c> censurar un comentario
            /// </summary>
            /// <param name="miembro"><c>Miembro</c> que realizo el comentario</param>
            /// <param name="comentario"><c>Comentario</c> a censurar</param>
            public void CensurarComentario(Comentario comentario) { }

            /// <summary>
            /// Metodo que permite gestionar una solicitud
            /// </summary>
            /// <param name="solicitud"> <c>Solicitud</c> que se va a gestionar </param>
            public void GestionSolicitud(Solicitud solicitud) { }

            /// <summary>
            /// Metodo que permite actualizar las <c>Relaciones</c> entre los <c>Miembros</c>
            /// </summary>
            /// <param name="miembro"><c>Miemro</c> a actualizar</param>
            public List<Solicitud> ActualizarAmigos(Miembro miembro) { return null; /*Devuelve lista miembros*/ }

            /// <summary>
            /// Metodo que muestra los <c>Miembros</c> disponibles para amistad
            /// </summary>
            /// <param name="miembro"><c>Miembro</c> al que se le mostrara la lista de amigos disponibles</param>
            /// <returns>Lista de <c>Miembros</c></returns>
            public List<Miembro> MostrarMiembrosDisponiblesParaAmistad() { return null; /*Devuleve lista de miembros*/ }

            /// <summary>
            /// Metodo que permite enviar una <c>Solicitud</c> de amistad
            /// </summary>
            /// <param name="miembro"><c>Miembro</c> al que se le enviara la solicitud</param>
            public void EnviarSolicitud(Miembro miembro) { }

            /// <summary>
            /// Metodo que muestra a los amigos de un <c>Miembro</c>
            /// </summary>
            /// <param name="miembro"> <c>Miembro</c> al que se le mostrara la lista de <c>Miembros</c> que son sus amigos</param>
            /// <returns>Lista de <c>Miembros</c></returns>
            public List<Miembro> BuscarAmigos(Miembro miembro) { return null; /*Devuelve lista de miembros*/ }

            /// <summary>
            /// Metodo que devuelve una lista con todos los <c>Comentarios</c>
            /// </summary>
            /// <returns>Lista de <c>Comentarios</c></returns>
            public List<Comentario> DevolverListaComentarios() { return null; /*Dvuelve la lista total de comentarios*/ }

            /// <summary>
            /// Metodo que devuelve una lista de todos los <c>Post</c> que ha realizado un <c>Miembro</c>
            /// </summary>
            /// <param name="miembro"></param>
            /// <returns>Lista de <c>Post</c></returns>
            public List<Post> DevolverListaPostPorMiembro(Miembro miembro) { return null; /*Devuelve una lista de post filtrada por miemro*/ }

            /// <summary>
            /// Metodo que devuelve una lista de todos los <c>Comentarios</c> que ha realizado un <c>Miembro</c>
            /// </summary>
            /// <param name="miembro"></param>
            /// <returns>Lista de <c>Comentarios</c></returns>
            //TODO: No deberiamos tener tambien una lista de comentarios por post?
            public List<Comentario> DevolverListaComentarioPorMiembro(Miembro miembro) { return null; /*Devuelve una lista de comentarios de un miembro*/}
            #endregion

        }
    }
