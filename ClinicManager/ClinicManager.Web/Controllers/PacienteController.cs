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
            return PartialView("_PacienteForm", new PacienteViewModel());
        }

        public IActionResult AlteraPaciente(int id)
        {
            var paciente = _pacienteAppService.ObterPorId(id);

            return PartialView("_PacienteForm", paciente);
        }

        [HttpPost]
        public IActionResult SalvarPaciente(PacienteViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { sucesso = false, mensagem = "Preencha os campos obrigatórios." });

            string msg;

            var ok = _pacienteAppService.IncluiPaciente(model, out msg);

            if (!ok)
                return Json(new { sucesso = false, mensagem = msg });

            return Json(new { sucesso = true });
        }

        [HttpPost]
        public IActionResult SalvarAlteraPaciente(PacienteViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { sucesso = false, mensagem = "Preencha os campos obrigatórios." });

            string msg;

            var ok = _pacienteAppService.AlteraPaciente(model, out msg);

            if (!ok)
                return Json(new { sucesso = false, mensagem = msg });

            return Json(new { sucesso = true });
        }

    }
}
