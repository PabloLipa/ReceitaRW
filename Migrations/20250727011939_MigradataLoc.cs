using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Localiza_Aplicattion.Migrations
{
    /// <inheritdoc />
    public partial class MigradataLoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SenhaHash = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEmpresarial = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Cnpj = table.Column<string>(type: "TEXT", maxLength: 18, nullable: false),
                    Situacao = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Abertura = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    NaturezaJuridica = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    AtividadePrincipal = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Logradouro = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Municipio = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Uf = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    Cep = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Cnpj_UsuarioId",
                table: "Empresas",
                columns: new[] { "Cnpj", "UsuarioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_UsuarioId",
                table: "Empresas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
