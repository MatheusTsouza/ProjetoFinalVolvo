using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalVolvo.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    proprietarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cpfCnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.proprietarioId);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    vendedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.vendedorId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    veiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroChassi = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ano = table.Column<short>(type: "smallint", nullable: false),
                    cor = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false),
                    quilometragem = table.Column<int>(type: "int", nullable: false),
                    acessorios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    versaoSistema = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    proprietarioId = table.Column<int>(type: "int", nullable: false),
                    vendedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.veiculoId);
                    table.ForeignKey(
                        name: "FK_Veiculos_Proprietarios_proprietarioId",
                        column: x => x.proprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "proprietarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculos_Vendedores_vendedorId",
                        column: x => x.vendedorId,
                        principalTable: "Vendedores",
                        principalColumn: "vendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_proprietarioId",
                table: "Veiculos",
                column: "proprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_vendedorId",
                table: "Veiculos",
                column: "vendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Proprietarios");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
