using ClinicManager.Domain.Core;
using ClinicManager.Domain.Entities;

namespace ClinicManager.Application.Interfaces.Service
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> ListarTodos();
        Paciente ObterPorId(int id);
        RequestResult Inclui(Paciente paciente);
        RequestResult Altera(Paciente paciente);
        void Excluir(int id);
    }
}
