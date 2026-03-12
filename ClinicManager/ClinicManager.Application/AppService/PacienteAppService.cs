using ClinicManager.Application.Interfaces.AppService;
using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.AppService
{
    public class PacienteAppService : IPacienteAppService
    {
        private readonly IPacienteService _pacienteService;

        public PacienteAppService(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public IEnumerable<PacienteViewModel> ListarTodos()
        {
            var pacientes = _pacienteService.ListarTodos();

            return pacientes.Select(p => new PacienteViewModel
            {
                Id = p.ID,
                Nome = p.NOME,
                CPF = p.CPF,
                DataNascimento = p.DTNASCIMENTO,
                Telefone = p.TELEFONE,
                Email = p.EMAIL
            });
        }
    }
}
