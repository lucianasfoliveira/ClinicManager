using ClinicManager.Application.ViewModel;
using ClinicManager.Domain.Core;
using System;

namespace ClinicManager.Application.Interfaces.AppService
{
    public interface IPacienteAppService
    {
        IEnumerable<PacienteViewModel> ListarTodos();
        PacienteViewModel ObterPorId(int id);
        RequestResult IncluiPaciente(PacienteViewModel model); 
        RequestResult AlteraPaciente(PacienteViewModel model); 
        RequestResult ExcluirPaciente(int id);
    }
}
