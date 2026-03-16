using ClinicManager.Domain.Entities;

namespace ClinicManager.Application.Interfaces.Service
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> ListarTodos();
        void IncluiPaciente(Paciente paciente);
        bool ExistePaciente(string cpf);
    }
}
