using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFolhaPagamento.Aplicacao.Migrations
{
    public partial class Criacao_coluna_data_emissao_funcionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdmissao",
                table: "Funcionarios",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DataAdmissao", table: "Funcionarios");
        }
    }
}
