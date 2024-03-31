using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmprestimoLivros.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CliNome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CliCPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    CliEndereco = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CliCidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CliBairro = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    id_livro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    autor = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    editora = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    disponivel = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.id_livro);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "integer", nullable: false),
                    IdLivro = table.Column<int>(type: "integer", nullable: false),
                    LivroIdLivro = table.Column<int>(type: "integer", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Livros_LivroIdLivro",
                        column: x => x.LivroIdLivro,
                        principalTable: "Livros",
                        principalColumn: "id_livro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_ClienteIdCliente",
                table: "Emprestimos",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_LivroIdLivro",
                table: "Emprestimos",
                column: "LivroIdLivro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
