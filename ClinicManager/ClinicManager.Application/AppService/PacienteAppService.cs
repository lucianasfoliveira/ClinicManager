using AutoMapper;
using ClinicManager.Application.Interfaces.AppService;
using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Application.ViewModel;
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

        public IEnumerable<PacienteViewModel> ListarTodos()
        {
            var pacientes = _pacienteService.ListarTodos();
            return _mapper.Map<IEnumerable<PacienteViewModel>>(pacientes);
        }

        public bool IncluiPaciente(PacienteViewModel model, out string msg)
        {
            msg = "";

            if (_pacienteService.ExistePaciente(model.CPF))
            {
                msg = "Já existe um paciente cadastrado com este Nome ou CPF.";
                return false;
            }

            var paciente = _mapper.Map<Paciente>(model);
            paciente.DTCADASTRO = DateTime.Now;

            _pacienteService.IncluiPaciente(paciente);

            msg = "";
            return true;
        }

    }
}
