using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFolhaPagamento.API.Dto
{
    public class FuncionarioParaInsercaoDto
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string documento { get; set; }
        public string setor { get; set; }
        public double salariobruto { get; set; }
        public bool possuiPlanoSaude { get; set; }
        public bool possuiPlanoDental { get; set; }
        public bool possuiValeTransporte { get; set; }
    }
}
