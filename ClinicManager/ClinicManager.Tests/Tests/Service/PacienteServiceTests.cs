using Xunit;
using Moq;
using FluentAssertions;
using ClinicManager.Application.Service;
using ClinicManager.Domain.Entities;
using ClinicManager.Domain.Interfaces;

namespace ClinicManager.Tests.Tests.Service
{
    public class PacienteServiceTests
    {
        private readonly Mock<IPacienteRepository> _repoMock;
        private readonly PacienteService _service;

        public PacienteServiceTests()
        {
            _repoMock = new Mock<IPacienteRepository>();
            _service = new PacienteService(_repoMock.Object);
        }

        [Fact]
        public void Inclui_DeveSalvarPaciente_QuandoDadosValidos()
        {
            var paciente = new Paciente
            {
                Nome = "Maria",
                Cpf = "123",
                DtNascimento = new DateTime(1990, 1, 1)
            };

                _repoMock
        .Setup(x => x.ExisteCpf(It.IsAny<string>(), It.IsAny<int?>()))
        .Returns(false);
            var resultado = _service.Inclui(paciente);

            resultado.Sucesso.Should().BeTrue();
            _repoMock.Verify(x => x.Inclui(It.IsAny<Paciente>()), Times.Once);
        }

        [Fact]
        public void Inclui_DeveRetornarErro_QuandoCpfDuplicado()
        {
            var paciente = new Paciente
            {
                Nome = "Maria",
                Cpf = "123",
                DtNascimento = new DateTime(1990, 1, 1)
            };

                    _repoMock
        .Setup(x => x.ExisteCpf(paciente.Cpf, It.IsAny<int?>()))
        .Returns(true);
            var resultado = _service.Inclui(paciente);

            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().Be("Já existe um paciente com este CPF.");
        }

        [Fact]
        public void Inclui_DeveRetornarErro_QuandoDataFutura()
        {
            var paciente = new Paciente
            {
                Nome = "Maria",
                Cpf = "123",
                DtNascimento = DateTime.Today.AddDays(1)
            };

            var resultado = _service.Inclui(paciente);

            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().Be("A data de nascimento não pode ser no futuro.");
        }

        [Fact]
        public void Inclui_DeveRetornarErro_QuandoDataMuitoAntiga()
        {
            var paciente = new Paciente
            {
                Nome = "Maria",
                Cpf = "123",
                DtNascimento = new DateTime(1900, 1, 1)
            };

            var resultado = _service.Inclui(paciente);

            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().Be("Data de nascimento inválida (mínimo 01/01/1910).");
        }

        [Fact]
        public void Inclui_DeveRetornarErro_QuandoDataNula()
        {
            var paciente = new Paciente
            {
                Nome = "Maria",
                Cpf = "123",
                DtNascimento = null
            };

            var resultado = _service.Inclui(paciente);

            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().Be("A data de nascimento é obrigatória.");
        }
    }
}