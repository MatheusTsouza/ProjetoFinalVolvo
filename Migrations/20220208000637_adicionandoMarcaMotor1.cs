using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalVolvo.Migrations
{
    public partial class adicionandoMarcaMotor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "marca",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "motor",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "marca",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "motor",
                table: "Veiculos");
        }
    }
}
