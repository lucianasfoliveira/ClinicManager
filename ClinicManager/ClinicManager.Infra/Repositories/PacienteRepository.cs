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

        public bool ExisteCpf(string cpf, int? idAtual = null)
        {
            var sql = @"SELECT COUNT(1) 
                FROM PACIENTE 
                WHERE CPF = @CPF 
                AND (@ID IS NULL OR ID <> @ID)";

            return _connection.ExecuteScalar<int>(sql, new { CPF = cpf, ID = idAtual }) > 0;
        }

        public void Inclui(Paciente paciente)
        {
            var sql = @"INSERT INTO PACIENTE
                        (NOME, CPF, DTNASCIMENTO, TELEFONE, EMAIL, DTCADASTRO)
                        VALUES
                        (@NOME, @CPF, @DTNASCIMENTO, @TELEFONE, @EMAIL, @DTCADASTRO)";

            _connection.Execute(sql, paciente);
        }

        public void Altera(Paciente paciente)
        {
            var sql = @"UPDATE PACIENTE
                        SET
                            DTNASCIMENTO = @DTNASCIMENTO,
                            TELEFONE = @TELEFONE,
                            EMAIL = @EMAIL
                        WHERE ID = @ID";

            _connection.Execute(sql, paciente);
        }

        public void Excluir(int id)
        {
            var sql = @"DELETE FROM PACIENTE
                WHERE ID = @ID";

            _connection.Execute(sql, new { ID = id });
        }
    }
}