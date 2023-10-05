using Dominio.Entidades;
using Dominio.Enum;
using Dominio.ExcepcionesPersonalizadas;

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

            PrecargarDatos();
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
        private Usuario? _usuarioDeSesion;
        #endregion

        #region Propiedades
        //Todas las listas son recupeerables, pero no pse pueden modificar fuera de la clase sistema
        public List<Administrador> Administradores { get { return _administradores; } }
        public List<Miembro> Miembros { get { return _miembros; } }
        public List<Solicitud> Solicitudes { get { return _relaciones; } }
        public List<Post> Posteos { get { return _posteos; } }

        #endregion


        #region Precargas

        private void PrecargarDatos()
        {
            PrecargaMiembros();
            PrecargaAdministradores();
            PrecargaPost();
            PrecargarSolicitudes();
        }

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
                AltaMiembro(nuevoMiembro);
            }
        }

        private void PrecargaAdministradores()
        {
            AltaAdmisitrador(new Administrador("karmen.bratislava@gmail.com", "soylakarmen"));
        }

        private void PrecargaPost()
        {
            Miembro posteadorAleatorio;
            Miembro comentaristaAleatorio;
            Miembro reaccionadorAleatorio;

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
                "¡Me encanta 'Bohemian Rhapsody' de Queen! Es una obra maestra musical. 🎶❤",
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
                posteadorAleatorio = SeleccionarMiembroAleatorio();
                Post unPost = new Post(titulosPost[iPost], contenidosPost[iPost], posteadorAleatorio, $"c:/img/{imagenes[iPost]}.png", false);
                unPost.Validar();

                // Agrega reaccion a 2 Post

                if (iPost == 0 || iPost == 1)
                {
                    reaccionadorAleatorio = SeleccionarMiembroAleatorio();
                    Reaccion reaccion = new Reaccion(reaccionadorAleatorio, true);
                    unPost.Reacciones.Add(reaccion);
                }

                //Agregarle comentarios

                for (int iComentario = iPost * 3/*iPost={0,3,6,9,12}*/; iComentario < (iPost + 1) * 3/*iPost={3,6,9,12,15}*/; iComentario++)
                {
                    comentaristaAleatorio = SeleccionarMiembroAleatorio();
                    Comentario comentario = new($"{comentaristaAleatorio.Nombre}:", contenidoComentario[iComentario], comentaristaAleatorio);
                    comentario.Validar();

                    // Agrega reaccion a 2 Comentarios

                    //Post[1], Comentario[0] y Post[3],Comentario[0] 
                    if (iComentario == 3 || iComentario == 9)
                    {
                        reaccionadorAleatorio = SeleccionarMiembroAleatorio();
                        Reaccion reaccion = new Reaccion(reaccionadorAleatorio, true);
                        comentario.Reacciones.Add(reaccion);
                    }
                    unPost.AgregarComentario(comentario);
                }
                _posteos.Add(unPost);
            }
        }

        private void PrecargarSolicitudes()
        {
            Random random = new Random();
            for (int i = 0; i < _miembros.Count; i++)
            {
                Miembro miembroSolicitante = _miembros[i];
                for (int j = 0; j < _miembros.Count; j++)
                {
                    Miembro miembroSolicitado = _miembros[j];
                    if (!miembroSolicitante.Equals(miembroSolicitado))
                    {
                        if (i == 0 || i == 1)
                        {
                            Solicitud unaSolicitud = new Solicitud(miembroSolicitante, miembroSolicitado);
                            EstadoSolicitud estadoAceptado = EstadoSolicitud.ACEPTADA;
                            unaSolicitud.CambiarEstado(estadoAceptado);
                            _relaciones.Add(unaSolicitud);
                        }
                        else
                        {
                            Solicitud otraSolicitud = new Solicitud(miembroSolicitante, miembroSolicitado);
                            EstadoSolicitud estadoAleatorio = SeleccionarEstadoSolicitudAleatorio();
                            otraSolicitud.CambiarEstado(estadoAleatorio);
                            _relaciones.Add(otraSolicitud);
                        }

                    }
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Da de alta a un <c>Miembro</c> en el sistema
        /// <para><b>Expeciones</b></para>
        /// En caso que el usuario <c cref="Miembro">Miembro</c> este registrado en el sistema lanza una excepcion <c>DuplicateUserInSystem</c>
        /// </summary>
        /// <param name="miembro"><c cref="Miembro">Miembro</c> a agregar al sistema</param>
        /// <exception cref="DuplicateUserInSystem">En caso que el usuario <c cref="Miembro">Miembro</c> se encuentra registrado en el sistema lanza una excepcion</exception>
        public void AltaMiembro(Miembro miembro)
        {
            miembro.Validar();

            if (_miembros.Contains(miembro))
                throw new DuplicateUserInSystem($"El miembro {miembro.Email} ya esta registrado en el sistema");

            _miembros.Add(miembro);
        }

        /// <summary>
        /// Da de alta a un administrador en el sistema
        /// <para><b>Excepciones</b></para>
        /// Si el <c>Administrador</c> ya esta registrado en el sistema lanza una excepcion de <c>DuplicateUserInSystem</c>
        /// </summary>
        /// <param name="administrador"></param>
        /// <exception cref="DuplicateUserInSystem"></exception>
        public void AltaAdmisitrador(Administrador administrador)
        {
            administrador.Validar();

            if (_administradores.Contains(administrador))
                throw new DuplicateUserInSystem($"El administrador {administrador.Email} ya esta registrado en el sistema");

            _administradores.Add(administrador);
        }

        /// <summary>
        /// Devuelve la lista de todas publicaciones dado el email de un <c>Miembro</c>. 
        /// <para><i><b>Nota:</b> Las mismas pueden ser <c>Post</c> o <c>Comentarios</c></i></para>
        /// <para><b>Excepción</b></para>
        /// <para>Si el email con el que se busca, no esta registrado en el sistema. Devuelve un error de miembro no encontrado <c>MemberNotFound</c></para>
        /// <para>Si el email con el que se busca, tiene un valor vacio o nulo devuelve una expecion de <c>ArgumentNullException</c></para>
        /// </summary>
        /// <param name="emailMiembro">Email que identifica al usuario inequivocamente en el sistema</param>
        /// <returns>Lista de publicaciones de un miembro en el sistema</returns>
        /// <exception cref="MemberNotFound"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public List<Publicacion> DevolverListaPublicacionesDelMiembro(string? emailMiembro)
        {
            List<Publicacion> publicacionesDelMiembro = new List<Publicacion>();
            Miembro miembro = BuscarMiembro(emailMiembro);

            foreach (Post post in _posteos)
            {
                if (post.Autor.Equals(miembro))
                    publicacionesDelMiembro.Add(post);

                //Aunque el post no sea del miembro,el mismo lo puede haber comentado
                List<Comentario> comentariosEnPostDelMiembro = post.DevolverComentariosDelMiembro(miembro);
                foreach (Comentario comentario in comentariosEnPostDelMiembro)
                {
                    publicacionesDelMiembro.Add(comentario);
                }
            }

            return publicacionesDelMiembro;
        }

        /// <summary>
        /// Metodo que devuelve una lista de todos los <c>Post</c> en los que un <c>Miembro</c> realizo comentarios
        /// <para><b>Excepciones</b></para>
        /// <para>Si el email con el que se busca, no esta registrado en el sistema. Devuelve un error de miembro no encontrado <c>MemberNotFound</c></para>
        /// <para>Si el email con el que se busca, tiene un valor vacio o nulo devuelve una expecion de <c>ArgumentNullException</c></para>
        /// </summary>
        /// <param name="emailMiembro">Email que identifica unequivocamente al <c>Miembro</c> en el sistema</param>
        /// <returns>Lista de post comentados por el <c>Miembro</c></returns>
        /// <exception cref="MemberNotFound"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public List<Post> DevolverListaPostComentadosPorMiembro(string? emailMiembro)
        {
            List<Post> postComentadosPorMiembro = new List<Post>();
            Miembro miembro = BuscarMiembro(emailMiembro);

            foreach (Post post in _posteos)
            {
                if (post.DevolverComentariosDelMiembro(miembro).Count > 0)
                    postComentadosPorMiembro.Add(post);
            }
            return postComentadosPorMiembro;
        }

        /// <summary>
        /// Devuelve una lista de los <c>Post</c> realizados entre la fecha definida para el comienzo y la definida para el final.
        /// Ordenda descendentemente por el titulo de los <c>Post</c>
        /// <para><i><b>Nota: </b>La lista no muestra los comentarios</i></para>
        /// <para><i><b>Nota: </b>Si el contenido de los <c>Post</c> supera los 50 caracteres, solo se mostraran los primeros 50</i></para>
        /// </summary>
        /// <param name="comienzo">Fecha desde la que comienza la busqueda de <c>Post</c></param>
        /// <param name="fin">Fecha en la que finaliza la busqueda de <c>Post</c></param>
        /// <returns>Una lista de Post entre fechas</returns>
        public List<Post> PostsRealizadosEntreFechas(DateTime comienzo, DateTime fin)
        {
            List<Post> postEntreFechas = new List<Post>();

            foreach (Post post in _posteos)
            {
                if (comienzo <= post.Fecha && post.Fecha <= fin)
                {
                    Post copiaPost = new(post.Titulo, post.Contenido, post.Autor, post.Image, post.Privado)
                    {
                        Censurado = post.Censurado
                    };
                    postEntreFechas.Add(copiaPost);
                }
            }
            postEntreFechas.Sort();

            return postEntreFechas;
        }

        /// <summary>
        /// Devuelve la lista de  miembros con mas publicaciones
        /// <para><b>Excepción</b></para>
        /// <para>Si el email con el que se busca, no esta registrado en el sistema. Devuelve un error de miembro no encontrado <c>MemberNotFound</c></para>
        /// <para>Si el email con el que se busca, tiene un valor vacio o nulo devuelve una expecion de <c>ArgumentNullException</c></para>
        /// </summary>
        /// <returns>Devuelve la lista de  miembros con mas publicaciones sin diferenciar entre post ni comentarios</returns>
        /// <exception cref="MemberNotFound"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public List<Miembro> MiembrosConMasPublicaciones()
        {
            int maxPublicaciones = 0;
            List<Miembro> miembosConMasPublicaciones = new List<Miembro>();

            foreach (Miembro miembro in _miembros)
            {
                List<Publicacion> publicacionesMiembro = DevolverListaPublicacionesDelMiembro(miembro.Email);
                if (publicacionesMiembro.Count > maxPublicaciones)
                {
                    miembosConMasPublicaciones.Clear();
                    miembosConMasPublicaciones.Add(miembro);
                    maxPublicaciones = publicacionesMiembro.Count;
                }
                else if (publicacionesMiembro.Count == maxPublicaciones)
                {
                    miembosConMasPublicaciones.Add(miembro);
                }
            }

            return miembosConMasPublicaciones;
        }

    /// <summary>
    /// Dado un email, permite buscar un <c>Miembro</c> en el sistema
    /// <para><b>Excepciones:</b></para>
    /// <para>Si el email con el que se busca, no esta registrado en el sistema. Devuelve un error de miembro no encontrado <c>MemberNotFound</c></para>
    /// <para>Si el email con el que se busca, tiene un valor vacio o nulo devuelve una expecion de <c>ArgumentNullException</c></para>
    /// </summary>
    /// <param name="email">Email que identifica al usuario inequivocamente en el sistema</param>
    /// <returns>Devuelve un <c>Miembro</c> del sistema si lo encuentra registrado</returns>
    /// <exception cref="MemberNotFound"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public Miembro BuscarMiembro(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException("El parametro email no puede estar vacio, es necesario ingresar un mail valido");

        int i = 0;
        Miembro? miembro = null;
        while (miembro == null && i < _miembros.Count)
        {
            if (_miembros[i].Email == email)
                miembro = _miembros[i];
            i++;
        }

        if (miembro == null)
            throw new MemberNotFound($"El miembro con e-mail {email}, no se encuentra registrado en el sistema.");

        return miembro;
    }

    #region Auxiliares

    /// <summary>
    /// Devulve un miembro aleatorio de los que estan registrados en el sistema
    /// </summary>
    /// <returns cref="Miembro"><c>Miembro</c> aleatorio.</returns>
    private Miembro SeleccionarMiembroAleatorio()
    {
        Random indiceRandom = new Random();
        int indiceMiembroAleatorio = indiceRandom.Next(_miembros.Count);

        return _miembros[indiceMiembroAleatorio];
    }

    /// <summary>
    /// Selecciona y devuelve un estado de solicitud aleatorio
    /// </summary>
    /// <returns><c>Estado de solicitud</c></returns>
    private EstadoSolicitud SeleccionarEstadoSolicitudAleatorio()
    {
        Random random = new Random();
        int valorAleatorio = random.Next(1, 4);
        EstadoSolicitud estadoAleatorio = (EstadoSolicitud)valorAleatorio;
        return estadoAleatorio;
    }
    #endregion

    #region ---------- Segunda entrega ----------

    /// <summary>
    /// Bloquea a un <c>Miembro</c> del sistema
    /// </summary>
    public void BloquearMiembro()
    {
        //NEXT: Proxima entrega
    }

    /// <summary>
    /// Censura un <c>Comentario</c> en el sistema
    /// </summary>
    /// <param name="comentario"></param>
    public void CensurarComentario(Comentario comentario)
    {
        //NEXT: Proxima entrega
    }

    /// <summary>
    /// Metodo que permite gestionar una solicitud
    /// </summary>
    /// <param name="solicitud"> <c>Solicitud</c> que se va a gestionar </param>
    public void GestionSolicitud(Solicitud solicitud)
    {
        //NEXT: Proxima entrega
    }

    /// <summary>
    /// Metodo que permite actualizar las <c>Relaciones</c> entre los <c>Miembros</c>
    /// </summary>
    /// <param name="email">Email del <c>Miembro</c> a actualizar su lista de amigos</param>
    public List<Solicitud> ActualizarAmigos(string email)
    {
        //NEXT: Proxima entrega
        return null; /*Devuelve lista miembros (amigos)*/
    }

    /// <summary>
    /// Me    todo que muestra los <c>Miembros</c> disponibles para amistad
    /// </summary>
    /// <param name="miembro"><c>Miembro</c> al que se le mostrara la lista de amigos disponibles</param>
    /// <returns>Lista de <c>Miembros</c></returns>
    public List<Miembro> MostrarMiembrosDisponiblesParaAmistad()
    {
        //NEXT: Proxima entrega
        return null; /*Devuleve lista de miembros*/
    }

    /// <summary>
    /// Metodo que permite enviar una <c>Solicitud</c> de amistad
    /// </summary>
    /// <param name="miembro"><c>Miembro</c> al que se le enviara la solicitud</param>
    public void EnviarSolicitud(Miembro miembro)
    {
        //NEXT: Proxima entrega
    }

    /// <summary>
    /// Metodo que devuelve una lista con todos los <c>Comentarios</c>
    /// </summary>
    /// <returns>Lista de <c>Comentarios</c></returns>
    public List<Comentario> DevolverListaComentarios()
    {
        //NEXT: Proxima entrega
        return null; /*Dvuelve la lista total de comentarios*/
    }

    /// <summary>
    /// Metodo que muestra a los amigos de un <c>Miembro</c>
    /// </summary>
    /// <param name="miembro"> <c>Miembro</c> al que se le mostrara la lista de <c>Miembros</c> que son sus amigos</param>
    /// <returns>Lista de <c>Miembros</c></returns>
    public List<Miembro> BuscarAmigos(Miembro miembro)
    {
        //NEXT: Proxima entrega
        return null; /*Devuelve lista de miembros*/
    }

    #endregion

    #endregion

}
}
