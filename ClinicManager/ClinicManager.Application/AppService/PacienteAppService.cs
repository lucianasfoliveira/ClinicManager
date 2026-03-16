using AutoMapper;
using ClinicManager.Application.Interfaces.AppService;
using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Application.ViewModel;
using ClinicManager.Domain.Core;
using ClinicManager.Domain.Entities;


namespace ClinicManager.Application.AppService
{
    // Local: ClinicManager.Application.AppService
    public class PacienteAppService : IPacienteAppService
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteAppService(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        public RequestResult IncluiPaciente(PacienteViewModel model)
        {
            var paciente = _mapper.Map<Paciente>(model);
            return _pacienteService.IncluiPaciente(paciente);
        }

        public RequestResult AlteraPaciente(PacienteViewModel model)
        {
            var paciente = _mapper.Map<Paciente>(model);
            return _pacienteService.AlteraPaciente(paciente);
        }

        public RequestResult ExcluirPaciente(int id)
        {
            _pacienteService.ExcluirPaciente(id);
            return RequestResult.Ok();
        }

        public IEnumerable<PacienteViewModel> ListarTodos()
            => _mapper.Map<IEnumerable<PacienteViewModel>>(_pacienteService.ListarTodos());

        public PacienteViewModel ObterPorId(int id)
            => _mapper.Map<PacienteViewModel>(_pacienteService.ObterPorId(id));
    }
}