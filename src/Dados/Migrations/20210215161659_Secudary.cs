using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class Secudary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Acumulativa",
                table: "Promocoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Formula",
                table: "Promocoes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acumulativa",
                table: "Promocoes");

            migrationBuilder.DropColumn(
                name: "Formula",
                table: "Promocoes");
        }
    }
}
