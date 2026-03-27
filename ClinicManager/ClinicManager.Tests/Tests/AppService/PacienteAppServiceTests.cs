using Xunit;
using Moq;
using FluentAssertions;
using AutoMapper;
using ClinicManager.Application.AppService;
using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Application.ViewModel;
using ClinicManager.Domain.Entities;


namespace ClinicManager.Tests.Tests.AppService
{
    public class PacienteAppServiceTests
    {
        private readonly Mock<IPacienteService> _serviceMock;
        private readonly IMapper _mapper;
        private readonly PacienteAppService _appService;

        public PacienteAppServiceTests()
        {
            _serviceMock = new Mock<IPacienteService>();

            var config = new MapperConfiguration(expression =>
            {
                expression.CreateMap<Paciente, PacienteViewModel>().ReverseMap();
            });

            _mapper = config.CreateMapper();

            _appService = new PacienteAppService(_serviceMock.Object, _mapper);
        }

        [Fact]
        public void ListarTodos_DeveRetornarPacientes()
        {
            var lista = new List<Paciente>
            {
                new Paciente { Id = 1, Nome = "Maria", Cpf = "123" }
            };

            _serviceMock.Setup(x => x.ListarTodos()).Returns(lista);

            var resultado = _appService.ListarTodos();

            resultado.Should().NotBeNull();
            resultado.Should().HaveCount(1);
            resultado.First().Nome.Should().Be("Maria");
        }

    }
}
