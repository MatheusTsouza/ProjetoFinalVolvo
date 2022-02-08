using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalVolvo.Migrations
{
    public partial class mudarMotor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "motor",
                table: "Veiculos",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "motor",
                table: "Veiculos",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
