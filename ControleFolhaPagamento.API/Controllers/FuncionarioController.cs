using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControleFolhaPagamento.API.Dto;
using ControleFolhaPagamento.API.Mappers;
using ControleFolhaPagamento.Aplicacao.Dominio.Services;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioMapper funcionarioMapper;
        private readonly IGerenciadorFuncionario gerenciadorFuncionario;
        private readonly IGeradorContraCheque geradorContraCheque;

        public FuncionarioController(IFuncionarioMapper funcionarioMapper, IGerenciadorFuncionario gerenciadorFuncionario, IGeradorContraCheque geradorContraCheque)
        {
            this.funcionarioMapper = funcionarioMapper;
            this.gerenciadorFuncionario = gerenciadorFuncionario;
            this.geradorContraCheque = geradorContraCheque;
        }

        [HttpGet]
        [Route("{id}")]
        public Funcionario Consultar(int id)
        {
            return this.gerenciadorFuncionario.pesquisar(id);
        }

        [HttpPost]
        public CodigoFuncionarioInseridoDto Criar([FromBody] FuncionarioParaInsercaoDto funcionarioDto)
        {
            var funcionario = this.funcionarioMapper.ParaEntidade(funcionarioDto);
            return this.funcionarioMapper.ParaCodigoInseridoDto(this.gerenciadorFuncionario.inserir(funcionario));
        }

        [HttpGet]
        [Route("{id}/contraCheque")]
        public ContraCheque GerarContraCheque(int id)
        {
            return this.geradorContraCheque.Gerar(id);
        }
    }
}
