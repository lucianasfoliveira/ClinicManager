using ClinicManager.Application.ViewModel;
using System;

namespace ClinicManager.Application.Interfaces.AppService
{
    public interface IPacienteAppService
    {
        IEnumerable<PacienteViewModel> ListarTodos();
        PacienteViewModel ObterPorId(int id);
        bool IncluiPaciente(PacienteViewModel model, out string msg);
        bool AlteraPaciente(PacienteViewModel model, out string msg);
        bool ExcluirPaciente(int id, out string msg);
    }
}
