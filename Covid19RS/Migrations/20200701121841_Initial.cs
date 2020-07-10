using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19RS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Covid19",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UkupanBrRegSlucajeva = table.Column<int>(nullable: false),
                    BrojSmrtnihSlucajeva = table.Column<int>(nullable: false),
                    ProcenatSmrtnosti = table.Column<decimal>(nullable: false),
                    BrojTestiranihOsoba = table.Column<int>(nullable: false),
                    BrojTestiranihOsoba24h = table.Column<int>(nullable: false),
                    BrojPotvrdjenihSlucajeva24h = table.Column<int>(nullable: false),
                    BrojPreminulihosoba24h = table.Column<int>(nullable: false),
                    BrojAktivnihSlucajeva = table.Column<int>(nullable: false),
                    BrojOsobaNaRespiratorima = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covid19", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Covid19");
        }
    }
}
