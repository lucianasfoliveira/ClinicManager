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

        public string Cpf { get; set; }

        public DateTime? DtNascimento { get; set; }
        public string Telefone { get; set; }

        public string? Email { get; set; }

        public DateTime DtCadastro { get; set; }
    }
}
