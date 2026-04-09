using AutoMapper;
using ClinicManager.Application.AppService;
using ClinicManager.Application.Interfaces.Service;
using ClinicManager.Application.ViewModel;
using ClinicManager.Domain.Core;
using ClinicManager.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

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

        [Fact]
        public void Salvar_DeveChamarInclui_QuandoIdForZero()
        {
            var model = new PacienteViewModel
            {
                Id = 0,
                Nome = "Maria",
                Cpf = "123",
                DtNascimento = new DateTime(1990, 1, 1)
            };

            _serviceMock
                .Setup(x => x.Inclui(It.IsAny<Paciente>()))
                .Returns(RequestResult.Ok());
            var resultado = _appService.Salvar(model);

            resultado.Sucesso.Should().BeTrue();

            _serviceMock.Verify(x => x.Inclui(It.IsAny<Paciente>()), Times.Once);
            _serviceMock.Verify(x => x.Altera(It.IsAny<Paciente>()), Times.Never);
        }

        [Fact]
        public void Salvar_DeveChamarAltera_QuandoIdForMaiorQueZero()
        {
            var model = new PacienteViewModel
            {
                Id = 1,
                Nome = "Maria",
                Cpf = "123",
                DtNascimento = new DateTime(1990, 1, 1)
            };

            _serviceMock
                .Setup(x => x.Altera(It.IsAny<Paciente>()))
                .Returns(RequestResult.Ok());
            var resultado = _appService.Salvar(model);

            resultado.Sucesso.Should().BeTrue();

            _serviceMock.Verify(x => x.Altera(It.IsAny<Paciente>()), Times.Once);
            _serviceMock.Verify(x => x.Inclui(It.IsAny<Paciente>()), Times.Never);
        }

        [Fact]
        public void Excluir_DeveChamarServiceERetornarSucesso()
        {
            var id = 1;

            _serviceMock
                .Setup(x => x.Excluir(id));

            var resultado = _appService.Excluir(id);

            resultado.Sucesso.Should().BeTrue();
            _serviceMock.Verify(x => x.Excluir(id), Times.Once);
        }
    }
}
