using Microsoft.EntityFrameworkCore.Migrations;

namespace FormWeb.Migrations
{
    public partial class AdicioneiSiglas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "Nacionalidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "Estado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "Cidade",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "Nacionalidade");

            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "Cidade");
        }
    }
}
