using ClinicManager.Application.ViewModel;
using System;
using ClinicManager.Application.ViewModel;

namespace ClinicManager.Application.Interfaces.AppService
{
    public interface IPacienteAppService
    {
        IEnumerable<PacienteViewModel> ListarTodos();
        void IncluiPaciente(PacienteViewModel model);
    }
}
