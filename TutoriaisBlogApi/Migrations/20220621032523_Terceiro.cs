using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutoriaisBlogApi.Migrations
{
    public partial class Terceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Usuarios_UsuarioId",
                table: "Publicacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicacao",
                table: "Publicacao");

            migrationBuilder.DropIndex(
                name: "IX_Publicacao_UsuarioId",
                table: "Publicacao");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Publicacao",
                newName: "Postagens");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Postagens",
                newName: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postagens",
                table: "Postagens",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Postagens",
                columns: new[] { "Id", "Conteudo", "Usuario" },
                values: new object[] { 1, "Teste", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Postagens",
                table: "Postagens");

            migrationBuilder.DeleteData(
                table: "Postagens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Postagens",
                newName: "Publicacao");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Publicacao",
                newName: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicacao",
                table: "Publicacao",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Idade", "Nome" },
                values: new object[] { 1, "josefina@gmail.com", 20, "Josefina Da Silva" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Idade", "Nome" },
                values: new object[] { 2, "marlucio@gmail.com", 25, "Marlucio De Oliveira" });

            migrationBuilder.CreateIndex(
                name: "IX_Publicacao_UsuarioId",
                table: "Publicacao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Usuarios_UsuarioId",
                table: "Publicacao",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
