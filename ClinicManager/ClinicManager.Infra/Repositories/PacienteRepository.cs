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

        public Paciente ObterPorId(int id)
        {
            var sql = @"SELECT ID, NOME, CPF, DTNASCIMENTO, TELEFONE, EMAIL, DTCADASTRO
                        FROM PACIENTE
                        WHERE ID = @ID";

            return _connection.QueryFirstOrDefault<Paciente>(sql, new { ID = id });
        }

        public void IncluiPaciente(Paciente paciente)
        {
            var sql = @"INSERT INTO PACIENTE
                        (NOME, CPF, DTNASCIMENTO, TELEFONE, EMAIL, DTCADASTRO)
                        VALUES
                        (@NOME, @CPF, @DTNASCIMENTO, @TELEFONE, @EMAIL, @DTCADASTRO)";

            _connection.Execute(sql, paciente);
        }

        public void AlteraPaciente(Paciente paciente)
        {
            var sql = @"UPDATE PACIENTE
                        SET
                            DTNASCIMENTO = @DTNASCIMENTO,
                            TELEFONE = @TELEFONE,
                            EMAIL = @EMAIL
                        WHERE ID = @ID";

            _connection.Execute(sql, paciente);
        }
        public void ExcluirPaciente(int id)
        {
            var sql = @"DELETE FROM PACIENTE
                WHERE ID = @ID";

            _connection.Execute(sql, new { ID = id });
        }
    }
}