using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class initialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedoras",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, nullable: true),
                    PaisOrigem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedoras", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, nullable: true),
                    Email = table.Column<string>(unicode: false, nullable: true),
                    Senha = table.Column<string>(unicode: false, nullable: true),
                    CPF = table.Column<string>(unicode: false, nullable: true),
                    Pais = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Calssificacao = table.Column<int>(nullable: false),
                    DesenvolvedorDTOID = table.Column<int>(nullable: false),
                    GeneroDTOID = table.Column<int>(nullable: false),
                    DataLancamento = table.Column<DateTime>(nullable: false),
                    Especificacoes = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jogos_Desenvolvedoras_DesenvolvedorDTOID",
                        column: x => x.DesenvolvedorDTOID,
                        principalTable: "Desenvolvedoras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jogos_Generos_GeneroDTOID",
                        column: x => x.GeneroDTOID,
                        principalTable: "Generos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDTO_JogoDTO",
                columns: table => new
                {
                    UsuarioDTOID = table.Column<int>(nullable: false),
                    JogoDTOID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDTO_JogoDTO", x => new { x.UsuarioDTOID, x.JogoDTOID });
                    table.ForeignKey(
                        name: "FK_UsuarioDTO_JogoDTO_Jogos_JogoDTOID",
                        column: x => x.JogoDTOID,
                        principalTable: "Jogos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDTO_JogoDTO_Usuarios_UsuarioDTOID",
                        column: x => x.UsuarioDTOID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_DesenvolvedorDTOID",
                table: "Jogos",
                column: "DesenvolvedorDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_GeneroDTOID",
                table: "Jogos",
                column: "GeneroDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDTO_JogoDTO_JogoDTOID",
                table: "UsuarioDTO_JogoDTO",
                column: "JogoDTOID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioDTO_JogoDTO");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Desenvolvedoras");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
