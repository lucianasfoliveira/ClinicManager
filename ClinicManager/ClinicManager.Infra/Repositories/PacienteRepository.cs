using Dapper;
using System.Data;
using ClinicManager.Domain.Interfaces;
using ClinicManager.Domain.Entities;

namespace ClinicManager.Infra.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IDbConnection _connection;

        public PacienteRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Paciente> ListarTodos()
        {
            var sql = @"SELECT ID, NOME, CPF, DTNASCIMENTO, TELEFONE, EMAIL, DTCADASTRO
                        FROM PACIENTE";

            return _connection.Query<Paciente>(sql);
        }
    }
}