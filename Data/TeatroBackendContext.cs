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
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 4,
            title = "Romeo y Julieta",
            descriptionPlay = "Una versión contemporánea del clásico de Shakespeare con un giro moderno.",
            synopsis = "En las bulliciosas calles de la ciudad actual, dos almas destinadas se encuentran en medio de la rivalidad de sus familias. 'Romeo y Julieta Reimaginados' fusiona la poesía de Shakespeare con la vibrante energía de la cultura urbana, explorando el amor y la tragedia en el siglo XXI.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 5,
            title = "Los Sueños",
            descriptionPlay = "Una odisea surrealista a través de la mente humana.",
            synopsis = "Sumérgete en el fascinante paisaje de los sueños con 'El Jardín de los Sueños'. Esta obra surrealista lleva al público a un viaje introspectivo a medida que los personajes navegan por los recovecos de la mente humana, explorando deseos, miedos y esperanzas ocultas.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 6,
            title = "El Último Acto",
            descriptionPlay = "Un drama conmovedor sobre la vida, la pérdida y la redención.",
            synopsis = "En un pequeño teatro al borde de la quiebra, un grupo de actores veteranos se reúne para una última actuación que cambiará sus vidas para siempre. 'El Último Acto' es un conmovedor tributo al poder del arte y la capacidad de encontrar significado incluso en los momentos más oscuros.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 2,
            title = "En el Escenario",
            descriptionPlay = "Una experiencia teatral única para toda la familia.",
            synopsis = "Acompaña a personajes entrañables en un viaje mágico a través de cuentos clásicos y nuevos relatos. 'Cuentos en el Escenario' combina la magia del teatro con la nostalgia de los cuentos, creando un espectáculo encantador para todas las edades.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 3,
            title = "La Noche",
            descriptionPlay = "Un thriller teatral que mantendrá al público al borde de sus asientos.",
            synopsis = "En una ciudad envuelta en sombras, un detective atormentado se enfrenta a su caso más oscuro. 'El Misterio de la Noche' es un fascinante juego de ingenio y suspense que desafía al público a resolver el enigma antes de que se revele la verdad impactante.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 7,
            title = "Sinfonía de Risas",
            descriptionPlay = "Una comedia musical llena de risas y alegría.",
            synopsis = "En un mundo donde la risa es la moneda de cambio, 'Sinfonía de Risas' lleva al público a un viaje musical hilarante. Con números pegajosos y situaciones cómicas, esta obra es un antídoto perfecto para el estrés diario, ofreciendo una experiencia teatral ligera y divertida.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 10,
            title = "Legado del Escenario",
            descriptionPlay = "Un homenaje a los clásicos del teatro a lo largo de los siglos.",
            synopsis = "A través de escenas icónicas y monólogos inolvidables, 'El Legado del Escenario' rinde homenaje a las obras maestras que han definido el teatro a lo largo de la historia. Desde Shakespeare hasta Beckett, esta obra es un recordatorio conmovedor de la perdurabilidad del arte escénico.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 11,
            title = "El Espejo Roto",
            descriptionPlay = "Un drama introspectivo sobre la identidad y el autodescubrimiento.",
            synopsis = "Cuando un espejo mágico revela versiones alternativas de sí mismos, los personajes de 'El Espejo Roto' se ven obligados a confrontar sus verdaderas identidades. Esta obra provocativa invita a la audiencia a reflexionar sobre la percepción y la realidad en un mundo lleno de reflejos fragmentados.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 12,
            title = "Sueños",
            descriptionPlay = "Una epopeya fantástica que desafía la realidad y la imaginación.",
            synopsis = "En un reino donde los sueños tienen el poder de cambiar la realidad, un grupo de valientes aventureros emprende una búsqueda épica. 'Cazadores de Sueños' combina elementos de fantasía, acción y magia para ofrecer una experiencia teatral que transporta al público a mundos inexplorados.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            id = 8,
            title = "El Despertar",
            descriptionPlay = "Un thriller psicológico que desafía la percepción de la realidad.",
            synopsis = "En un manicomio abandonado, un psiquiatra se enfrenta a los fantasmas de su pasado mientras trata a un paciente con una conexión sorprendente. 'El Despertar de las Sombras' explora los límites de la cordura y la verdad en un viaje psicológico inolvidable.",
            tickets = new List<Ticket>()
        },
        new Play
        {
            
            id = 9,
            title = "Las Emociones",
            descriptionPlay = "Una experiencia teatral visualmente impactante que celebra la diversidad emocional.",
            synopsis = "Con un enfoque innovador en la expresión emocional, 'Caleidoscopio de Emociones' fusiona la danza, el teatro y la tecnología para llevar al público a un viaje visualmente deslumbrante. Desde la euforia hasta la melancolía, esta obra invita a explorar la complejidad de las emociones humanas.",
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
                            email = "user1@example.com",
                            notes = "Note 1",
                            tlf = 123456789,
                            payment = "Credit Card",
                            tickets = new List<Ticket>()
                        }
                        
                    );
            modelBuilder.Entity<Ticket>().HasData(
                        new Ticket
                        {
                            id = 1,
                            TicketRow = 1,
                            TicketColumn = 1,
                            price = 15.00m,
                            // meter tambien el horario y sala para las reservas en venta
                            scheduleTicket = DateTime.Now.AddDays(1),
                            userId = 1,
                            playId = 1
                        }
                    );

            base.OnModelCreating(modelBuilder);
        }
}
}