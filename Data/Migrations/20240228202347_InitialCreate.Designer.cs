﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeatroWeb.Data;

#nullable disable

namespace TeatroWeb.Data.Migrations
{
    [DbContext(typeof(TeatroBackendContext))]
    [Migration("20240228202347_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TeatroWeb.Models.Play", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descriptionPlay")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("director")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("genre")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("synopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("id");

                    b.ToTable("Plays");

                    b.HasData(
                        new
                        {
                            id = 1,
                            descriptionPlay = "Una obra intrigante que explora los misterios del teatro clásico.",
                            synopsis = "En el bullicioso mundo teatral del siglo XIX, un enmascarado misterioso acecha entre bambalinas, desentrañando secretos oscuros y rivalidades encubiertas. Con giros inesperados, 'La Máscara Oculta' transporta a la audiencia a un viaje lleno de intriga y emoción.",
                            title = "La Máscara"
                        },
                        new
                        {
                            id = 4,
                            descriptionPlay = "Una versión contemporánea del clásico de Shakespeare con un giro moderno.",
                            synopsis = "En las bulliciosas calles de la ciudad actual, dos almas destinadas se encuentran en medio de la rivalidad de sus familias. 'Romeo y Julieta Reimaginados' fusiona la poesía de Shakespeare con la vibrante energía de la cultura urbana, explorando el amor y la tragedia en el siglo XXI.",
                            title = "Romeo y Julieta"
                        },
                        new
                        {
                            id = 5,
                            descriptionPlay = "Una odisea surrealista a través de la mente humana.",
                            synopsis = "Sumérgete en el fascinante paisaje de los sueños con 'El Jardín de los Sueños'. Esta obra surrealista lleva al público a un viaje introspectivo a medida que los personajes navegan por los recovecos de la mente humana, explorando deseos, miedos y esperanzas ocultas.",
                            title = "Los Sueños"
                        },
                        new
                        {
                            id = 6,
                            descriptionPlay = "Un drama conmovedor sobre la vida, la pérdida y la redención.",
                            synopsis = "En un pequeño teatro al borde de la quiebra, un grupo de actores veteranos se reúne para una última actuación que cambiará sus vidas para siempre. 'El Último Acto' es un conmovedor tributo al poder del arte y la capacidad de encontrar significado incluso en los momentos más oscuros.",
                            title = "El Último Acto"
                        },
                        new
                        {
                            id = 2,
                            descriptionPlay = "Una experiencia teatral única para toda la familia.",
                            synopsis = "Acompaña a personajes entrañables en un viaje mágico a través de cuentos clásicos y nuevos relatos. 'Cuentos en el Escenario' combina la magia del teatro con la nostalgia de los cuentos, creando un espectáculo encantador para todas las edades.",
                            title = "En el Escenario"
                        },
                        new
                        {
                            id = 3,
                            descriptionPlay = "Un thriller teatral que mantendrá al público al borde de sus asientos.",
                            synopsis = "En una ciudad envuelta en sombras, un detective atormentado se enfrenta a su caso más oscuro. 'El Misterio de la Noche' es un fascinante juego de ingenio y suspense que desafía al público a resolver el enigma antes de que se revele la verdad impactante.",
                            title = "La Noche"
                        },
                        new
                        {
                            id = 7,
                            descriptionPlay = "Una comedia musical llena de risas y alegría.",
                            synopsis = "En un mundo donde la risa es la moneda de cambio, 'Sinfonía de Risas' lleva al público a un viaje musical hilarante. Con números pegajosos y situaciones cómicas, esta obra es un antídoto perfecto para el estrés diario, ofreciendo una experiencia teatral ligera y divertida.",
                            title = "Sinfonía de Risas"
                        },
                        new
                        {
                            id = 10,
                            descriptionPlay = "Un homenaje a los clásicos del teatro a lo largo de los siglos.",
                            synopsis = "A través de escenas icónicas y monólogos inolvidables, 'El Legado del Escenario' rinde homenaje a las obras maestras que han definido el teatro a lo largo de la historia. Desde Shakespeare hasta Beckett, esta obra es un recordatorio conmovedor de la perdurabilidad del arte escénico.",
                            title = "Legado del Escenario"
                        },
                        new
                        {
                            id = 11,
                            descriptionPlay = "Un drama introspectivo sobre la identidad y el autodescubrimiento.",
                            synopsis = "Cuando un espejo mágico revela versiones alternativas de sí mismos, los personajes de 'El Espejo Roto' se ven obligados a confrontar sus verdaderas identidades. Esta obra provocativa invita a la audiencia a reflexionar sobre la percepción y la realidad en un mundo lleno de reflejos fragmentados.",
                            title = "El Espejo Roto"
                        },
                        new
                        {
                            id = 12,
                            descriptionPlay = "Una epopeya fantástica que desafía la realidad y la imaginación.",
                            synopsis = "En un reino donde los sueños tienen el poder de cambiar la realidad, un grupo de valientes aventureros emprende una búsqueda épica. 'Cazadores de Sueños' combina elementos de fantasía, acción y magia para ofrecer una experiencia teatral que transporta al público a mundos inexplorados.",
                            title = "Sueños"
                        },
                        new
                        {
                            id = 8,
                            descriptionPlay = "Un thriller psicológico que desafía la percepción de la realidad.",
                            synopsis = "En un manicomio abandonado, un psiquiatra se enfrenta a los fantasmas de su pasado mientras trata a un paciente con una conexión sorprendente. 'El Despertar de las Sombras' explora los límites de la cordura y la verdad en un viaje psicológico inolvidable.",
                            title = "El Despertar"
                        },
                        new
                        {
                            id = 9,
                            descriptionPlay = "Una experiencia teatral visualmente impactante que celebra la diversidad emocional.",
                            synopsis = "Con un enfoque innovador en la expresión emocional, 'Caleidoscopio de Emociones' fusiona la danza, el teatro y la tecnología para llevar al público a un viaje visualmente deslumbrante. Desde la euforia hasta la melancolía, esta obra invita a explorar la complejidad de las emociones humanas.",
                            title = "Las Emociones"
                        });
                });

            modelBuilder.Entity("TeatroWeb.Models.Ticket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("TicketColumn")
                        .HasColumnType("int");

                    b.Property<int>("TicketRow")
                        .HasColumnType("int");

                    b.Property<int>("playId")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("scheduleTicket")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("playId");

                    b.HasIndex("userId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TeatroWeb.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("direction")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("passwd")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("payment")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("tlf")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeatroWeb.Models.Ticket", b =>
                {
                    b.HasOne("TeatroWeb.Models.Play", "play")
                        .WithMany("tickets")
                        .HasForeignKey("playId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeatroWeb.Models.User", "user")
                        .WithMany("tickets")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("play");

                    b.Navigation("user");
                });

            modelBuilder.Entity("TeatroWeb.Models.Play", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("TeatroWeb.Models.User", b =>
                {
                    b.Navigation("tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
