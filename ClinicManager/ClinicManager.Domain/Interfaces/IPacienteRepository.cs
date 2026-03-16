using ClinicManager.Domain.Entities;
using System;
using ClinicManager.Domain.Entities;

namespace ClinicManager.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente> ListarTodos();
        Paciente ObterPorId(int id);
        bool ExisteCpf(string cpf, int idAtual);
        void IncluiPaciente(Paciente paciente);
        void AlteraPaciente(Paciente paciente);
        void ExcluirPaciente(int id);
    }
}
