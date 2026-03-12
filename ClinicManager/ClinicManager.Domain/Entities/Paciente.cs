using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
