Projeto criado com o intuito de testar e aprimorar os conhecimentos em .NET.
A aplicação é responsável pela gestão de funcionários (cadastro e consulta), bem como a geração de seu contra-cheque.

## Tecnologias e bibliotecas utilizadas

* .NET Core
* Entity Framework
* AssertValidation
* XUnit
* Moq

## EndPoints disponíveis

* **/Funcionario**: Responsável pela criação de um funcionário. É esperado que os dados sejam inseridos no seguinte formato:

```
{
	"nome": "",
	"sobrenome": "",
	"documento": "",
	"setor": "",
	"salariobruto": 0,
    "dataAdmissao": "YYYY-MM-DD",
	"possuiplanosaude": false,
	"possuiplanodental": false,
	"possuivaletransporte": false
}
```

* **/Funcionario/{id}**: Responsável pela consulta de um funcionário pelo seu código

* **/Funcionario/{id}/contraCheque**: Responsável pela geração do contra-cheque do funcionário. A resposta é fornecida no formato abaixo:

```
{
  "mes": "",
  "salarioBruto": 0,
  "totalDescontos": 0,
  "salarioLiquido": 0,
  "lancamentos": [
    {
      "tipo": "",
      "valor": 0,
      "descricao": ""
    }
  ]
}
```

## Como inicializar a aplicação

1. Clone o projeto
2. Abra no Visual Studio ou editor de sua preferência
3. Selecione o projeto ControleFolhaPagamento.API
4. Execute a aplicação ou execute o comando dotnet run

Só isso. Simples assim ;).

A inicialização rápida se dá pois a aplicação já vai configurada com um banco de dados padrão.

Caso queira configurar um banco em outra instância será necessário seguir os seguintes passos:

1. Configure o banco
2. Altere a configuração de conexão para o novo banco. A configuração encontra-se no arquivo ControleFolhaPagamento.API\appsettings.json
3. Execute os migrations que constam no projeto ControleFolhaPagamento.Aplicacao
4. Pronto. Só executar a aplicação.
