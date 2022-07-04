using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutoriaisBlogApi.Migrations
{
    public partial class RelacionandoUsuariocomPostagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Postagens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Postagens",
                newName: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Postagens",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_Usuarios_UsuarioId",
                table: "Postagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_Usuarios_UsuarioId",
                table: "Postagens");

            migrationBuilder.DropIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Postagens");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Postagens",
                newName: "Usuario");

            migrationBuilder.InsertData(
                table: "Postagens",
                columns: new[] { "Id", "Conteudo", "Usuario" },
                values: new object[] { 1, "Teste", 1 });
        }
    }
}
