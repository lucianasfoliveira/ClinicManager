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
        public PacienteViewModel ObterPorId(int id)
        {
            var paciente = _pacienteService.ObterPorId(id);

            return _mapper.Map<PacienteViewModel>(paciente);
        }

        public bool IncluiPaciente(PacienteViewModel model, out string msg)
        {
            msg = "";

            if (_pacienteService.ExistePaciente(model.CPF))
            {
                msg = "Já existe um paciente cadastrado com este CPF.";
                return false;
            }

            var paciente = _mapper.Map<Paciente>(model);
            paciente.DTCADASTRO = DateTime.Now;

            _pacienteService.IncluiPaciente(paciente);

            msg = "";
            return true;
        }
        public bool AlteraPaciente(PacienteViewModel model, out string msg)
        {
            var paciente = _mapper.Map<Paciente>(model);

            return _pacienteService.AlteraPaciente(paciente, out msg);
        }
    }
}
