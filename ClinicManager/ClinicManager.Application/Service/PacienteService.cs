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
        public Paciente ObterPorId(int id)
        {
            return _pacienteRepository.ObterPorId(id);
        }

        public void IncluiPaciente(Paciente paciente)
        {
            _pacienteRepository.IncluiPaciente(paciente);
        }
        public bool AlteraPaciente(Paciente paciente, out string msg)
        {
            msg = "";

            var existente = _pacienteRepository.ObterPorId(paciente.ID);

            if (existente == null)
            {
                msg = "Paciente não encontrado.";
                return false;
            }

            _pacienteRepository.AlteraPaciente(paciente);

            msg = "";

            return true;
        }

        public bool ExistePaciente(string cpf)
        {
            var pacientes = _pacienteRepository.ListarTodos();

            return pacientes.Any(p => p.CPF == cpf);
        }
    }
}
