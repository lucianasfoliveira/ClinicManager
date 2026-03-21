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

        public RequestResult Inclui(Paciente paciente)
        {
            var resultadoData = ValidarDataNascimento(paciente.DtNascimento);
            if (!resultadoData.Sucesso)
                return resultadoData;

            if (_pacienteRepository.ExisteCpf(paciente.Cpf))
                return RequestResult.Erro("Já existe um paciente com este CPF.");

            paciente.DtCadastro = DateTime.Now;

            _pacienteRepository.Inclui(paciente);

            return RequestResult.Ok();
        }

        public RequestResult Altera(Paciente paciente)
        {
            var resultadoData = ValidarDataNascimento(paciente.DtNascimento);
            if (!resultadoData.Sucesso)
                return resultadoData;

            if (_pacienteRepository.ExisteCpf(paciente.Cpf, paciente.Id))
                return RequestResult.Erro("CPF já pertence a outro paciente.");

            _pacienteRepository.Altera(paciente);

            return RequestResult.Ok();
        }

        private RequestResult ValidarDataNascimento(DateTime? data)
        {
            if (!data.HasValue)
                return RequestResult.Erro("A data de nascimento é obrigatória.");

            var hoje = DateTime.Today;

            if (data > hoje)
                return RequestResult.Erro("A data de nascimento não pode ser no futuro.");

            if (data < new DateTime(1910, 1, 1))
                return RequestResult.Erro("Data de nascimento inválida (mínimo 01/01/1910).");

            return RequestResult.Ok();
        }

        public void Excluir(int id)
        {
            _pacienteRepository.Excluir(id);
        }
    }
}
