using ClinicManager.Application.ViewModel;
using System;

namespace ClinicManager.Application.Interfaces.AppService
{
    public interface IPacienteAppService
    {
        IEnumerable<PacienteViewModel> ListarTodos();
        void IncluiPaciente(PacienteViewModel model);
    }
}
