using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Domain.Entities
{
    public class Paciente
    {
        public int ID { get; set; }

        public string NOME { get; set; }

        public string CPF { get; set; }

        public DateTime DTNASCIMENTO { get; set; }

        public string TELEFONE { get; set; }

        public string? EMAIL { get; set; }

        public DateTime DTCADASTRO { get; set; }
    }
}
