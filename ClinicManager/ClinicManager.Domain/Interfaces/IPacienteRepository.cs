using ClinicManager.Domain.Entities;
using System;
using ClinicManager.Domain.Entities;

namespace ClinicManager.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente> ListarTodos();
    }
}
