using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalVolvo.Migrations
{
    public partial class adicionandoEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endereco",
                table: "Proprietarios");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Vendedores",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "enderecoCidade",
                table: "Proprietarios",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "enderecoNumero",
                table: "Proprietarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "enderecoRua",
                table: "Proprietarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enderecoCidade",
                table: "Proprietarios");

            migrationBuilder.DropColumn(
                name: "enderecoNumero",
                table: "Proprietarios");

            migrationBuilder.DropColumn(
                name: "enderecoRua",
                table: "Proprietarios");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "Proprietarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
