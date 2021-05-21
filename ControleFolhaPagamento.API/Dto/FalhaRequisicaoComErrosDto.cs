using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFolhaPagamento.API.Dto
{
    public class FalhaRequisicaoComErrosDto: FalhaRequisicaoDto
    {
        public FalhaRequisicaoComErrosDto(string mensagem, string[] falhas): base(mensagem)
        {
            this.falhas = falhas;
        }
        public string[] falhas { get; set; }
    }
}
