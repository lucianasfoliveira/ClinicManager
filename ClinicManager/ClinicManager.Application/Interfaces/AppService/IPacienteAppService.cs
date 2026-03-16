using ClinicManager.Application.ViewModel;
using System;

namespace ClinicManager.Application.Interfaces.AppService
{
    public interface IPacienteAppService
    {
        IEnumerable<PacienteViewModel> ListarTodos();
        bool IncluiPaciente(PacienteViewModel model, out string msg);
    }
}
