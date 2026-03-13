using ClinicManager.Application.Interfaces.AppService;
using ClinicManager.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult IncluiPaciente()
        {
            return PartialView("_IncluiPaciente");
        }

        [HttpPost]
        public IActionResult IncluiPaciente(PacienteViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_IncluiPaciente", model);

            _pacienteAppService.IncluiPaciente(model);

            return RedirectToAction("Index");
        }
    }
}
