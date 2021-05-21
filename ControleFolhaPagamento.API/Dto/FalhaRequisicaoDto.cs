using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFolhaPagamento.API.Dto
{
    public class FalhaRequisicaoDto
    {

        public FalhaRequisicaoDto(string message)
        {
            this.message = message;
        }
        public string message { get; set; }
    }
}
