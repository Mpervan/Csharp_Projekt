using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceptiNoviApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Idkorisnik = table.Column<long>(type: "INTEGER", nullable: false),
                    Idrecept = table.Column<long>(type: "INTEGER", nullable: false),
                    Ocjena = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recepti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Priprema = table.Column<string>(type: "TEXT", nullable: true),
                    KratkiOpis = table.Column<string>(type: "TEXT", nullable: true),
                    Sastojci = table.Column<string>(type: "TEXT", nullable: true),
                    Img = table.Column<string>(type: "TEXT", nullable: true),
                    Vege = table.Column<string>(type: "TEXT", nullable: true),
                    Idkorisnik = table.Column<int>(type: "INTEGER", nullable: false),
                    Idkategorije = table.Column<int>(type: "INTEGER", nullable: false),
                    KategorijaId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepti_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_KategorijaId",
                table: "Recepti",
                column: "KategorijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Recepti");

            migrationBuilder.DropTable(
                name: "Kategorije");
        }
    }
}
