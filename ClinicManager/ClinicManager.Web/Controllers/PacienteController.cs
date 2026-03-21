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
        public IActionResult Inclui()
        {
            return PartialView("_PacienteForm", new PacienteViewModel());
        }

        public IActionResult Altera(int id)
        {
            var paciente = _pacienteAppService.ObterPorId(id);

            return PartialView("_PacienteForm", paciente);
        }

        [HttpPost]
        public IActionResult Salvar(PacienteViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { sucesso = false, mensagem = "Verifique os dados preenchidos." });

            var resultado = _pacienteAppService.Salvar(model);

            return Json(new { sucesso = resultado.Sucesso, mensagem = resultado.Mensagem });
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var resultado = _pacienteAppService.Excluir(id);

            if (!resultado.Sucesso)
                return Json(new { sucesso = false, mensagem = resultado.Mensagem });

            return Json(new { sucesso = true });
        }

    }
}
