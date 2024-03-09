using Microsoft.EntityFrameworkCore;
using TeatroWeb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace TeatroWeb.Data{

public class TeatroBackendContext : DbContext{

    public TeatroBackendContext(DbContextOptions<TeatroBackendContext> options)
    :base(options)
    {
    }
    public DbSet<Play> Plays {get;set;}
    public DbSet<Ticket> Tickets {get;set;}
    public DbSet<User> Users {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
             // Una Play tiene una lista de Tickets
            modelBuilder.Entity<Play>()
                .HasMany(p => p.tickets)
                .WithOne(t => t.play)
                .HasForeignKey(t => t.playId);

            // Un Ticket tiene una Play
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.play)
                .WithMany(p => p.tickets)
                .HasForeignKey(t => t.playId);

            // Un User tiene una lista de Tickets
            modelBuilder.Entity<User>()
                .HasMany(u => u.tickets)
                .WithOne(t => t.user)
                .HasForeignKey(t => t.userId);

            // Un Ticket tiene un User
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.user)
                .WithMany(u => u.tickets)
                .HasForeignKey(t => t.userId);

            modelBuilder.Entity<Play>().HasData(
        new Play
        {
            id = 1,
            title = "La Máscara",
            descriptionPlay = "Una obra intrigante que explora los misterios del teatro clásico.",
            synopsis = "En el bullicioso mundo teatral del siglo XIX, un enmascarado misterioso acecha entre bambalinas, desentrañando secretos oscuros y rivalidades encubiertas. Con giros inesperados, 'La Máscara Oculta' transporta a la audiencia a un viaje lleno de intriga y emoción.",
            director = "Ramón Peón (La Habana, Cuba; 1897 - San Juan, Puerto Rico; 1971) fue un periodista, bailarín, músico, productor, director, camarógrafo, actor y guionista de cine cubano. Se inició como camarógrafo en los antiguos estudios Kalem y Vitagraph, de Nueva York.",
            genre = "Horror",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 4,
            title = "Romeo y Julieta",
            descriptionPlay = "Una versión contemporánea del clásico de Shakespeare con un giro moderno.",
            synopsis = "En las bulliciosas calles de la ciudad actual, dos almas destinadas se encuentran en medio de la rivalidad de sus familias. 'Romeo y Julieta Reimaginados' fusiona la poesía de Shakespeare con la vibrante energía de la cultura urbana, explorando el amor y la tragedia en el siglo XXI.",
            director = "Mark Anthony Luhrmann (Sídney, Nueva Gales del Sur, 17 de septiembre de 1962), conocido como Baz Luhrmann, es un actor, director, guionista y productor de cine australiano. Es ampliamente considerado como uno de los más destacados directores de cine.",
            genre = "Romance",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 5,
            title = "Los Sueños",
            descriptionPlay = "Una odisea surrealista a través de la mente humana.",
            synopsis = "Sumérgete en el fascinante paisaje de los sueños con 'El Jardín de los Sueños'. Esta obra surrealista lleva al público a un viaje introspectivo a medida que los personajes navegan por los recovecos de la mente humana, explorando deseos, miedos y esperanzas ocultas.",
            director = "Gerardo Vera Perales (Miraflores de la Sierra (Madrid) 10 de marzo de 1947 - 20 de septiembre de 2020)fue un escenógrafo, diseñador de vestuario, actor y director de cine y de teatro español. Dirigió el espectáculo 'Azabache' en la Expo92 de Sevilla, cosechando un fabuloso éxito.",
            genre = "Drama",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 6,
            title = "El Último Acto",
            descriptionPlay = "Un drama conmovedor sobre la vida, la pérdida y la redención.",
            synopsis = "En un pequeño teatro al borde de la quiebra, un grupo de actores veteranos se reúne para una última actuación que cambiará sus vidas para siempre. 'El Último Acto' es un conmovedor tributo al poder del arte y la capacidad de encontrar significado incluso en los momentos más oscuros.",
            director = "El último acto es el nuevo largometraje de Kenneth Branagh. Un homenaje a los últimos años de William Shakespeare. Cómo, por qué y en qué circunstancias decidió, una de las grandes figuras de la literatura universal, dejar el teatro y volver al pueblo con su familia.",
            genre = "Drama",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 2,
            title = "En el Escenario",
            descriptionPlay = "Una experiencia teatral única para toda la familia.",
            synopsis = "Acompaña a personajes entrañables en un viaje mágico a través de cuentos clásicos y nuevos relatos. 'Cuentos en el Escenario' combina la magia del teatro con la nostalgia de los cuentos, creando un espectáculo encantador para todas las edades.",
            director = "Juanjo Pastor es un joven actor, que siempre ha tenido claro que quería dedicarse al mundo del espectáculo. Desde bien pequeño, en el colegio ya tenía teatro como asignatura extraescolar, y  también más tarde en el instituto.",
            genre = "Drama",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 3,
            title = "La Noche",
            descriptionPlay = "Un thriller teatral que mantendrá al público al borde de sus asientos.",
            synopsis = "En una ciudad envuelta en sombras, un detective atormentado se enfrenta a su caso más oscuro. 'El Misterio de la Noche' es un fascinante juego de ingenio y suspense que desafía al público a resolver el enigma antes de que se revele la verdad impactante.",
            director = "Abel González Melo (La Habana, 14 de enero de 1980) es doctor en Estudios Literarios y máster en Teatro por la Universidad Complutense de Madrid, así como licenciado en Teatrología por el Instituto Superior de Arte de Cuba.",
            genre = "Thriller",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 7,
            title = "Sinfonía de Risas",
            descriptionPlay = "Una comedia musical llena de risas y alegría.",
            synopsis = "En un mundo donde la risa es la moneda de cambio, 'Sinfonía de Risas' lleva al público a un viaje musical hilarante. Con números pegajosos y situaciones cómicas, esta obra es un antídoto perfecto para el estrés diario, ofreciendo una experiencia teatral ligera y divertida.",
            director = "Nacido en Granada, Zapata inició sus estudios de canto en Madrid con Toñi Rosado Casas y los perfeccionó con Ana Luisa Chova en el Conservatorio Superior de Música de Valencia. Ha asistido a clases magistrales y cursos de perfeccionamiento con Yelena Obraztsova, Pedro Lavirgen, Renata Scotto.",
            genre = "Comedia",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 10,
            title = "Legado del Escenario",
            descriptionPlay = "Un homenaje a los clásicos del teatro a lo largo de los siglos.",
            synopsis = "A través de escenas icónicas y monólogos inolvidables, 'El Legado del Escenario' rinde homenaje a las obras maestras que han definido el teatro a lo largo de la historia. Desde Shakespeare hasta Beckett, esta obra es un recordatorio conmovedor de la perdurabilidad del arte escénico.",
            director = "Andrés Lima Fernández de Toro es un actor y director teatral español vinculado a la compañía de teatro Animalario. El 30 de septiembre de 2019 fue galardonado con el Premio Nacional de Teatro.Comienza su carrera como actor y director teatral, desde muy temprana edad.",
            genre = "Historia",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 11,
            title = "El Espejo Roto",
            descriptionPlay = "Un drama introspectivo sobre la identidad y el autodescubrimiento.",
            synopsis = "Cuando un espejo mágico revela versiones alternativas de sí mismos, los personajes de 'El Espejo Roto' se ven obligados a confrontar sus verdaderas identidades. Esta obra provocativa invita a la audiencia a reflexionar sobre la percepción y la realidad en un mundo lleno de reflejos fragmentados.",
            director = "Estudios de Teatro en el Taller de Actores Profesionales que dirigió José Monleón en la RESAD (Real Escuela Superior de Arte Dramático) Madrid -España. Pertenece al grupo de investigación en Estéticas Urbanas, con artículos como Los Demonios hacen catarsis en el Palacio de Justicia.",
            genre = "Drama",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 12,
            title = "Sueños",
            descriptionPlay = "Una epopeya fantástica que desafía la realidad y la imaginación.",
            synopsis = "En un reino donde los sueños tienen el poder de cambiar la realidad, un grupo de valientes aventureros emprende una búsqueda épica. 'Cazadores de Sueños' combina elementos de fantasía, acción y magia para ofrecer una experiencia teatral que transporta al público a mundos inexplorados.",
            director = "Gerardo Vera Perales (Miraflores de la Sierra (Madrid) 10 de marzo de 1947 - 20 de septiembre de 2020)fue un escenógrafo, diseñador de vestuario, actor y director de cine y de teatro español. Dirigió el espectáculo 'Azabache' en la Expo92 de Sevilla, cosechando un fabuloso éxito.",
            genre = "Fantasía",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 8,
            title = "El Despertar",
            descriptionPlay = "Un thriller psicológico que desafía la percepción de la realidad.",
            synopsis = "En un manicomio abandonado, un psiquiatra se enfrenta a los fantasmas de su pasado mientras trata a un paciente con una conexión sorprendente. 'El Despertar de las Sombras' explora los límites de la cordura y la verdad en un viaje psicológico inolvidable.",
            director = "Iván Morales inició su trayectoria en el underground español como editor de fanzines y locutor de radios libres en la década de los ochenta, para iniciar en su infancia una carrera de actor que le ha llevado a participar en series de televisión como Nissaga: Amistades peligrosas o Poblenou.",
            genre = "Thriller",
            tickets = new List<Ticket>()
        },
        new Play
        {
            
            id = 9,
            title = "Las Emociones",
            descriptionPlay = "Una experiencia teatral visualmente impactante que celebra la diversidad emocional.",
            synopsis = "Con un enfoque innovador en la expresión emocional, 'Caleidoscopio de Emociones' fusiona la danza, el teatro y la tecnología para llevar al público a un viaje visualmente deslumbrante. Desde la euforia hasta la melancolía, esta obra invita a explorar la complejidad de las emociones humanas.",
            director = "David Fernández Troncoso, desde que debutó con diez años, su vida profesional ha estado dedicada en exclusiva al teatro. Por su carrera pasan nombres como Titirimundi, Instituto del Teatro, Comedia de Buenos Aires, CAT…",
            genre = "Drama",
            tickets = new List<Ticket>()
        }
    );
            modelBuilder.Entity<User>().HasData(
                        new User
                        {
                            id = 1,
                            username = "admin",
                            surname = "admin",
                            passwd = "passexample",
                            direction = "addressexample",
                            email = "admin@svalero.com",
                            notes = "Note 1",
                            tlf = 123456789,
                            payment = "Credit Card",
                            tickets = new List<Ticket>()
                        },
                        new User
                        {
                            id = 2,
                            username = "no-admin",
                            surname = "no-admin",
                            passwd = "passexample",
                            direction = "addressexample",
                            email = "user2@example.com",
                            notes = "Note 2",
                            tlf = 987654321,
                            payment = "PayPal",
                            tickets = new List<Ticket>()
                        }
                        
                    );
            base.OnModelCreating(modelBuilder);
        }
    }
}