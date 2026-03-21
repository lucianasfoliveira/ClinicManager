using AutoMapper;
using ClinicManager.Application.Interfaces.AppService;
using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Application.ViewModel;
using ClinicManager.Domain.Core;
using ClinicManager.Domain.Entities;


namespace ClinicManager.Application.AppService
{
    public class PacienteAppService : IPacienteAppService
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteAppService(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        public RequestResult Salvar(PacienteViewModel model)
        {
            var paciente = _mapper.Map<Paciente>(model);

            if (model.Id == 0)
                return _pacienteService.Inclui(paciente);

            return _pacienteService.Altera(paciente);
        }

        public RequestResult Excluir(int id)
        {
            _pacienteService.Excluir(id);
            return RequestResult.Ok();
        }

        public IEnumerable<PacienteViewModel> ListarTodos()
            => _mapper.Map<IEnumerable<PacienteViewModel>>(_pacienteService.ListarTodos());

        public PacienteViewModel ObterPorId(int id)
            => _mapper.Map<PacienteViewModel>(_pacienteService.ObterPorId(id));
    }
}