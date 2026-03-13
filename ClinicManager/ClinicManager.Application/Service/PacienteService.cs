using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Domain.Entities;
using ClinicManager.Domain.Interfaces;

namespace ClinicManager.Application.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public IEnumerable<Paciente> ListarTodos()
        {
            return _pacienteRepository.ListarTodos();
        }

        public void IncluiPaciente(Paciente paciente)
        {
            _pacienteRepository.IncluiPaciente(paciente);
        }
    }
}
