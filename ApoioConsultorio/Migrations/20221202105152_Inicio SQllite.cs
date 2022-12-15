using Microsoft.EntityFrameworkCore.Migrations;

namespace ApoioConsultorio.Migrations
{
    public partial class InicioSQllite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImpostoTaxas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    imposto_nf = table.Column<decimal>(type: "decimal(4,4)", nullable: false),
                    taxa_avista = table.Column<decimal>(type: "decimal(4,4)", nullable: false),
                    taxa_Parcelado = table.Column<decimal>(type: "decimal(4,4)", nullable: false),
                    ativo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpostoTaxas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    ValorAvista = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorParcelado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Material_1 = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialCustos_1 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Material_2 = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialCustos_2 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Material_3 = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialCustos_3 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Material_4 = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialCustos_4 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EquipeCustos1 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EquipeCustos2 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EquipeCustos3 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EquipeCustos4 = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImpostoTaxas");

            migrationBuilder.DropTable(
                name: "Procedimentos");
        }
    }
}
