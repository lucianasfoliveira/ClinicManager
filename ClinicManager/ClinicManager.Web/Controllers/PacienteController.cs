using Microsoft.AspNetCore.Mvc;
using ClinicManager.Application.Interfaces.AppService;

namespace ClinicManager.Web.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteAppService _pacienteAppService;

        public PacienteController(IPacienteAppService pacienteAppService)
        {
            _pacienteAppService = pacienteAppService;
        }

        public IActionResult Index()
        {
            var pacientes = _pacienteAppService.ListarTodos();
            return View(pacientes);
        }
    }
}
