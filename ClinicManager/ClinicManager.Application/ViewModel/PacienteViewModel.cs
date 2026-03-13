using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.ViewModel
{
    public class PacienteViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtNascimento { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DtCadastro { get; set; }

    }
}
