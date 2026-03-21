using ClinicManager.Application.ViewModel;
using ClinicManager.Domain.Core;

namespace ClinicManager.Application.Interfaces.AppService
{
    public interface IPacienteAppService
    {
        IEnumerable<PacienteViewModel> ListarTodos();
        PacienteViewModel ObterPorId(int id);

        public RequestResult Salvar(PacienteViewModel model);

        RequestResult Excluir(int id);
    }
}
