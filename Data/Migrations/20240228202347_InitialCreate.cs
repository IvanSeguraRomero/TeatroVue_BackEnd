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
                    title = table.Column<string>(type: "nvarchar(80)", nullable: true),
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
                    { 1, "Una obra intrigante que explora los misterios del teatro clásico.", null, null, "En el bullicioso mundo teatral del siglo XIX, un enmascarado misterioso acecha entre bambalinas, desentrañando secretos oscuros y rivalidades encubiertas. Con giros inesperados, 'La Máscara Oculta' transporta a la audiencia a un viaje lleno de intriga y emoción.", "La Máscara" },
                    { 2, "Una experiencia teatral única para toda la familia.", null, null, "Acompaña a personajes entrañables en un viaje mágico a través de cuentos clásicos y nuevos relatos. 'Cuentos en el Escenario' combina la magia del teatro con la nostalgia de los cuentos, creando un espectáculo encantador para todas las edades.", "En el Escenario" },
                    { 3, "Un thriller teatral que mantendrá al público al borde de sus asientos.", null, null, "En una ciudad envuelta en sombras, un detective atormentado se enfrenta a su caso más oscuro. 'El Misterio de la Noche' es un fascinante juego de ingenio y suspense que desafía al público a resolver el enigma antes de que se revele la verdad impactante.", "La Noche" },
                    { 4, "Una versión contemporánea del clásico de Shakespeare con un giro moderno.", null, null, "En las bulliciosas calles de la ciudad actual, dos almas destinadas se encuentran en medio de la rivalidad de sus familias. 'Romeo y Julieta Reimaginados' fusiona la poesía de Shakespeare con la vibrante energía de la cultura urbana, explorando el amor y la tragedia en el siglo XXI.", "Romeo y Julieta" },
                    { 5, "Una odisea surrealista a través de la mente humana.", null, null, "Sumérgete en el fascinante paisaje de los sueños con 'El Jardín de los Sueños'. Esta obra surrealista lleva al público a un viaje introspectivo a medida que los personajes navegan por los recovecos de la mente humana, explorando deseos, miedos y esperanzas ocultas.", "Los Sueños" },
                    { 6, "Un drama conmovedor sobre la vida, la pérdida y la redención.", null, null, "En un pequeño teatro al borde de la quiebra, un grupo de actores veteranos se reúne para una última actuación que cambiará sus vidas para siempre. 'El Último Acto' es un conmovedor tributo al poder del arte y la capacidad de encontrar significado incluso en los momentos más oscuros.", "El Último Acto" },
                    { 7, "Una comedia musical llena de risas y alegría.", null, null, "En un mundo donde la risa es la moneda de cambio, 'Sinfonía de Risas' lleva al público a un viaje musical hilarante. Con números pegajosos y situaciones cómicas, esta obra es un antídoto perfecto para el estrés diario, ofreciendo una experiencia teatral ligera y divertida.", "Sinfonía de Risas" },
                    { 8, "Un thriller psicológico que desafía la percepción de la realidad.", null, null, "En un manicomio abandonado, un psiquiatra se enfrenta a los fantasmas de su pasado mientras trata a un paciente con una conexión sorprendente. 'El Despertar de las Sombras' explora los límites de la cordura y la verdad en un viaje psicológico inolvidable.", "El Despertar" },
                    { 9, "Una experiencia teatral visualmente impactante que celebra la diversidad emocional.", null, null, "Con un enfoque innovador en la expresión emocional, 'Caleidoscopio de Emociones' fusiona la danza, el teatro y la tecnología para llevar al público a un viaje visualmente deslumbrante. Desde la euforia hasta la melancolía, esta obra invita a explorar la complejidad de las emociones humanas.", "Las Emociones" },
                    { 10, "Un homenaje a los clásicos del teatro a lo largo de los siglos.", null, null, "A través de escenas icónicas y monólogos inolvidables, 'El Legado del Escenario' rinde homenaje a las obras maestras que han definido el teatro a lo largo de la historia. Desde Shakespeare hasta Beckett, esta obra es un recordatorio conmovedor de la perdurabilidad del arte escénico.", "Legado del Escenario" },
                    { 11, "Un drama introspectivo sobre la identidad y el autodescubrimiento.", null, null, "Cuando un espejo mágico revela versiones alternativas de sí mismos, los personajes de 'El Espejo Roto' se ven obligados a confrontar sus verdaderas identidades. Esta obra provocativa invita a la audiencia a reflexionar sobre la percepción y la realidad en un mundo lleno de reflejos fragmentados.", "El Espejo Roto" },
                    { 12, "Una epopeya fantástica que desafía la realidad y la imaginación.", null, null, "En un reino donde los sueños tienen el poder de cambiar la realidad, un grupo de valientes aventureros emprende una búsqueda épica. 'Cazadores de Sueños' combina elementos de fantasía, acción y magia para ofrecer una experiencia teatral que transporta al público a mundos inexplorados.", "Sueños" }
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
