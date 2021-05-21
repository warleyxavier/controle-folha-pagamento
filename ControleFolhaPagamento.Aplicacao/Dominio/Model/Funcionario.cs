using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Model
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Documento { get; set; }
        public string Setor { get; set; }
        public double SalarioBruto { get; set; }
        public bool PossuiPlanoSaude { get; set; }
        public bool PossuiPlanoDental { get; set; }
        public bool PossuiValeTransporte { get; set; }

        public void RemoverCaracteresDoDocumento()
        {
            Documento = Documento.Replace(".", "").Replace("-", "");
        }
    }
}
