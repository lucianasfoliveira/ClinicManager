using ClinicManager.Application.Interfaces.AppService;
using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Application.ViewModel;
using AutoMapper;


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

        public IEnumerable<PacienteViewModel> ListarTodos()
        {
            var pacientes = _pacienteService.ListarTodos();
            return _mapper.Map<IEnumerable<PacienteViewModel>>(pacientes);
        }
    }
}
