using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeatroWeb.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    descriptionPlay = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    synopsis = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    director = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    genre = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    passwd = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    direction = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    tlf = table.Column<int>(type: "int", nullable: false),
                    payment = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketRow = table.Column<int>(type: "int", nullable: false),
                    TicketColumn = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    scheduleTicket = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    playId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tickets_Plays_playId",
                        column: x => x.playId,
                        principalTable: "Plays",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plays",
                columns: new[] { "id", "descriptionPlay", "director", "genre", "synopsis", "title" },
                values: new object[,]
                {
                    { 1, "Una obra intrigante que explora los misterios del teatro clásico.", "Ramón Peón (La Habana, Cuba; 1897 - San Juan, Puerto Rico; 1971) fue un periodista, bailarín, músico, productor, director, camarógrafo, actor y guionista de cine cubano. Se inició como camarógrafo en los antiguos estudios Kalem y Vitagraph, de Nueva York.", "Horror", "En el bullicioso mundo teatral del siglo XIX, un enmascarado misterioso acecha entre bambalinas, desentrañando secretos oscuros y rivalidades encubiertas. Con giros inesperados, 'La Máscara Oculta' transporta a la audiencia a un viaje lleno de intriga y emoción.", "La Máscara" },
                    { 2, "Una experiencia teatral única para toda la familia.", "Juanjo Pastor es un joven actor, que siempre ha tenido claro que quería dedicarse al mundo del espectáculo. Desde bien pequeño, en el colegio ya tenía teatro como asignatura extraescolar, y  también más tarde en el instituto.", "Drama", "Acompaña a personajes entrañables en un viaje mágico a través de cuentos clásicos y nuevos relatos. 'Cuentos en el Escenario' combina la magia del teatro con la nostalgia de los cuentos, creando un espectáculo encantador para todas las edades.", "En el Escenario" },
                    { 3, "Un thriller teatral que mantendrá al público al borde de sus asientos.", "Abel González Melo (La Habana, 14 de enero de 1980) es doctor en Estudios Literarios y máster en Teatro por la Universidad Complutense de Madrid, así como licenciado en Teatrología por el Instituto Superior de Arte de Cuba.", "Thriller", "En una ciudad envuelta en sombras, un detective atormentado se enfrenta a su caso más oscuro. 'El Misterio de la Noche' es un fascinante juego de ingenio y suspense que desafía al público a resolver el enigma antes de que se revele la verdad impactante.", "La Noche" },
                    { 4, "Una versión contemporánea del clásico de Shakespeare con un giro moderno.", "Mark Anthony Luhrmann (Sídney, Nueva Gales del Sur, 17 de septiembre de 1962), conocido como Baz Luhrmann, es un actor, director, guionista y productor de cine australiano. Es ampliamente considerado como uno de los más destacados directores de cine.", "Romance", "En las bulliciosas calles de la ciudad actual, dos almas destinadas se encuentran en medio de la rivalidad de sus familias. 'Romeo y Julieta Reimaginados' fusiona la poesía de Shakespeare con la vibrante energía de la cultura urbana, explorando el amor y la tragedia en el siglo XXI.", "Romeo y Julieta" },
                    { 5, "Una odisea surrealista a través de la mente humana.", "Gerardo Vera Perales (Miraflores de la Sierra (Madrid) 10 de marzo de 1947 - 20 de septiembre de 2020)fue un escenógrafo, diseñador de vestuario, actor y director de cine y de teatro español. Dirigió el espectáculo 'Azabache' en la Expo92 de Sevilla, cosechando un fabuloso éxito.", "Drama", "Sumérgete en el fascinante paisaje de los sueños con 'El Jardín de los Sueños'. Esta obra surrealista lleva al público a un viaje introspectivo a medida que los personajes navegan por los recovecos de la mente humana, explorando deseos, miedos y esperanzas ocultas.", "Los Sueños" },
                    { 6, "Un drama conmovedor sobre la vida, la pérdida y la redención.", "El último acto es el nuevo largometraje de Kenneth Branagh. Un homenaje a los últimos años de William Shakespeare. Cómo, por qué y en qué circunstancias decidió, una de las grandes figuras de la literatura universal, dejar el teatro y volver al pueblo con su familia.", "Drama", "En un pequeño teatro al borde de la quiebra, un grupo de actores veteranos se reúne para una última actuación que cambiará sus vidas para siempre. 'El Último Acto' es un conmovedor tributo al poder del arte y la capacidad de encontrar significado incluso en los momentos más oscuros.", "El Último Acto" },
                    { 7, "Una comedia musical llena de risas y alegría.", "Nacido en Granada, Zapata inició sus estudios de canto en Madrid con Toñi Rosado Casas y los perfeccionó con Ana Luisa Chova en el Conservatorio Superior de Música de Valencia. Ha asistido a clases magistrales y cursos de perfeccionamiento con Yelena Obraztsova, Pedro Lavirgen, Renata Scotto.", "Comedia", "En un mundo donde la risa es la moneda de cambio, 'Sinfonía de Risas' lleva al público a un viaje musical hilarante. Con números pegajosos y situaciones cómicas, esta obra es un antídoto perfecto para el estrés diario, ofreciendo una experiencia teatral ligera y divertida.", "Sinfonía de Risas" },
                    { 8, "Un thriller psicológico que desafía la percepción de la realidad.", "Iván Morales inició su trayectoria en el underground español como editor de fanzines y locutor de radios libres en la década de los ochenta, para iniciar en su infancia una carrera de actor que le ha llevado a participar en series de televisión como Nissaga: Amistades peligrosas o Poblenou.", "Thriller", "En un manicomio abandonado, un psiquiatra se enfrenta a los fantasmas de su pasado mientras trata a un paciente con una conexión sorprendente. 'El Despertar de las Sombras' explora los límites de la cordura y la verdad en un viaje psicológico inolvidable.", "El Despertar" },
                    { 9, "Una experiencia teatral visualmente impactante que celebra la diversidad emocional.", "David Fernández Troncoso, desde que debutó con diez años, su vida profesional ha estado dedicada en exclusiva al teatro. Por su carrera pasan nombres como Titirimundi, Instituto del Teatro, Comedia de Buenos Aires, CAT…", "Drama", "Con un enfoque innovador en la expresión emocional, 'Caleidoscopio de Emociones' fusiona la danza, el teatro y la tecnología para llevar al público a un viaje visualmente deslumbrante. Desde la euforia hasta la melancolía, esta obra invita a explorar la complejidad de las emociones humanas.", "Las Emociones" },
                    { 10, "Un homenaje a los clásicos del teatro a lo largo de los siglos.", "Andrés Lima Fernández de Toro es un actor y director teatral español vinculado a la compañía de teatro Animalario. El 30 de septiembre de 2019 fue galardonado con el Premio Nacional de Teatro.Comienza su carrera como actor y director teatral, desde muy temprana edad.", "Historia", "A través de escenas icónicas y monólogos inolvidables, 'El Legado del Escenario' rinde homenaje a las obras maestras que han definido el teatro a lo largo de la historia. Desde Shakespeare hasta Beckett, esta obra es un recordatorio conmovedor de la perdurabilidad del arte escénico.", "Legado del Escenario" },
                    { 11, "Un drama introspectivo sobre la identidad y el autodescubrimiento.", "Estudios de Teatro en el Taller de Actores Profesionales que dirigió José Monleón en la RESAD (Real Escuela Superior de Arte Dramático) Madrid -España. Pertenece al grupo de investigación en Estéticas Urbanas, con artículos como Los Demonios hacen catarsis en el Palacio de Justicia.", "Drama", "Cuando un espejo mágico revela versiones alternativas de sí mismos, los personajes de 'El Espejo Roto' se ven obligados a confrontar sus verdaderas identidades. Esta obra provocativa invita a la audiencia a reflexionar sobre la percepción y la realidad en un mundo lleno de reflejos fragmentados.", "El Espejo Roto" },
                    { 12, "Una epopeya fantástica que desafía la realidad y la imaginación.", "Gerardo Vera Perales (Miraflores de la Sierra (Madrid) 10 de marzo de 1947 - 20 de septiembre de 2020)fue un escenógrafo, diseñador de vestuario, actor y director de cine y de teatro español. Dirigió el espectáculo 'Azabache' en la Expo92 de Sevilla, cosechando un fabuloso éxito.", "Fantasía", "En un reino donde los sueños tienen el poder de cambiar la realidad, un grupo de valientes aventureros emprende una búsqueda épica. 'Cazadores de Sueños' combina elementos de fantasía, acción y magia para ofrecer una experiencia teatral que transporta al público a mundos inexplorados.", "Sueños" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "direction", "email", "notes", "passwd", "payment", "surname", "tlf", "username" },
                values: new object[,]
                {
                    { 1, "addressexample", "admin@svalero.com", "Note 1", "passexample", "Credit Card", "admin", 123456789, "admin" },
                    { 2, "addressexample", "user2@example.com", "Note 2", "passexample", "PayPal", "no-admin", 987654321, "no-admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_playId",
                table: "Tickets",
                column: "playId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_userId",
                table: "Tickets",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
