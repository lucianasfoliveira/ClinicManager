using ClinicManager.Domain.Entities;

namespace ClinicManager.Application.Interfaces.Service
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> ListarTodos();
        Paciente ObterPorId(int id);
        void IncluiPaciente(Paciente paciente);
        bool AlteraPaciente(Paciente paciente, out string msg);
        bool ExistePaciente(string cpf);
        void ExcluirPaciente(int id);
    }
}
