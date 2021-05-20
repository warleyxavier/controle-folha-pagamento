﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControleFolhaPagamento.API.Dto;
using ControleFolhaPagamento.API.Mappers;
using ControleFolhaPagamento.Aplicacao.Dominio.Services;
using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;

namespace ControleFolhaPagamento.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioMapper funcionarioMapper;
        private readonly IGerenciadorFuncionario gerenciadorFuncionario;

        public FuncionarioController(IFuncionarioMapper funcionarioMapper, IGerenciadorFuncionario gerenciadorFuncionario)
        {
            this.funcionarioMapper = funcionarioMapper;
            this.gerenciadorFuncionario = gerenciadorFuncionario;
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
    }
}
