using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class Terciary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorDesconto",
                table: "PedidosItens",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorDesconto",
                table: "PedidosItens");
        }
    }
}
