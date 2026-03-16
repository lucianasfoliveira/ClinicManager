using AutoMapper;
using ClinicManager.Application.ViewModel;
using ClinicManager.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicManager.Application.Mapping
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
        }
    }
}
