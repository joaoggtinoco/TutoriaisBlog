using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutoriaisBlogApi.Migrations
{
    public partial class AdicionandoRelacaoentreUsuarioePostagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Postagens");

            migrationBuilder.CreateIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Postagens",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Postagens");

            migrationBuilder.CreateIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Postagens",
                column: "UsuarioId",
                unique: true);
        }
    }
}
