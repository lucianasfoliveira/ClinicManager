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
            var resultadoData = ValidarDataNascimento(paciente.DTNASCIMENTO);
            if (!resultadoData.Sucesso) return resultadoData;

            if (_pacienteRepository.ExisteCpf(paciente.CPF))
                return RequestResult.Erro("Já existe um paciente cadastrado com este CPF.");

            paciente.DTCADASTRO = DateTime.Now;
            _pacienteRepository.IncluiPaciente(paciente);
            return RequestResult.Ok();
        }

        public RequestResult AlteraPaciente(Paciente paciente)
        {
            var resultadoData = ValidarDataNascimento(paciente.DTNASCIMENTO);
            if (!resultadoData.Sucesso) return resultadoData;

            if (_pacienteRepository.ExisteCpf(paciente.CPF, paciente.ID))
                return RequestResult.Erro("O CPF informado já pertence a outro paciente.");

            _pacienteRepository.AlteraPaciente(paciente);
            return RequestResult.Ok();
        }

        private RequestResult ValidarDataNascimento(DateTime data)
        {
            if (data > DateTime.Now)
                return RequestResult.Erro("A data de nascimento não pode ser no futuro.");

            if (data < new DateTime(1900, 1, 1))
                return RequestResult.Erro("Data de nascimento inválida (mínimo ano 1900).");

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
