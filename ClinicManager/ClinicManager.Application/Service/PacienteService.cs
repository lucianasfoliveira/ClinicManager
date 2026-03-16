using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Domain.Core;
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

        public RequestResult IncluiPaciente(Paciente paciente)
        {
            if (_pacienteRepository.ExisteCpf(paciente.CPF))
                return RequestResult.Erro("Já existe um paciente cadastrado com este CPF.");

            paciente.DTCADASTRO = DateTime.Now;
            _pacienteRepository.IncluiPaciente(paciente);
            return RequestResult.Ok();
        }

        public RequestResult AlteraPaciente(Paciente paciente)
        {
            if (_pacienteRepository.ExisteCpf(paciente.CPF, paciente.ID))
            {
                return RequestResult.Erro("Este CPF já está cadastrado para outro paciente.");
            }

            _pacienteRepository.AlteraPaciente(paciente);
            return RequestResult.Ok();
        }

        public bool ExistePaciente(string cpf)
        {
            var pacientes = _pacienteRepository.ListarTodos();

            return pacientes.Any(p => p.CPF == cpf);
        }
        public void ExcluirPaciente(int id)
        {
            _pacienteRepository.ExcluirPaciente(id);
        }
    }
}
