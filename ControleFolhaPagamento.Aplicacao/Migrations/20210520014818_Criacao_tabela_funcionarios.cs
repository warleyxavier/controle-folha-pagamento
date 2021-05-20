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
                    Id = table.Column<int>(type: "integer", nullable: false).Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    SobreNome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(11)", nullable: false),
                    Setor = table.Column<string>(type: "varchar(20)", nullable: false),
                    SalarioBruto = table.Column<double>(type: "numeric(8,2)", defaultValue: 0, nullable: false),
                    PossuiPlanoSaude = table.Column<bool>(type: "bool", defaultValue: false, nullable: false),
                    PossuiPlanoDental = table.Column<bool>(type: "bool", defaultValue: false, nullable: false),
                    PossuiValeTransporte = table.Column<bool>(type: "bool", defaultValue: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Funcionarios");
        }
    }
}
