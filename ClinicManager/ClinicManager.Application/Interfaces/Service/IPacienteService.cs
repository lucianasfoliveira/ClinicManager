using ClinicManager.Domain.Core;
using ClinicManager.Domain.Entities;

namespace ClinicManager.Application.Interfaces.Service
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> ListarTodos();
        Paciente ObterPorId(int id);
        RequestResult IncluiPaciente(Paciente paciente);
        RequestResult AlteraPaciente(Paciente paciente);
        bool ExistePaciente(string cpf);
        void ExcluirPaciente(int id);
    }
}
