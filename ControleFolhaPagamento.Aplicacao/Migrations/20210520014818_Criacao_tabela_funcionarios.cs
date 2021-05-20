using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ControleFolhaPagamento.Aplicacao.Migrations
{
    public partial class Criacao_tabela_funcionarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    SobreNome = table.Column<string>(type: "text", nullable: true),
                    Documento = table.Column<string>(type: "text", nullable: true),
                    Setor = table.Column<string>(type: "text", nullable: true),
                    SalarioBruto = table.Column<double>(type: "double precision", nullable: false),
                    PossuiPlanoSaude = table.Column<bool>(type: "boolean", nullable: false),
                    PossuiPlanoDental = table.Column<bool>(type: "boolean", nullable: false),
                    PossuiValeTransporte = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
