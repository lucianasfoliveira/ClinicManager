using ClinicManager.Domain.Entities;
using System;
using ClinicManager.Domain.Entities;

namespace ClinicManager.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente> ListarTodos();
        Paciente ObterPorId(int id);
        void IncluiPaciente(Paciente paciente);
        void AlteraPaciente(Paciente paciente);
        void ExcluirPaciente(int id);
    }
}
