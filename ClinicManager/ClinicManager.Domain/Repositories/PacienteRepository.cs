using ClinicManager.Domain.Entities;
using ClinicManager.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

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
            var sql = @"SELECT Id, Nome, CPF, DataNascimento, Telefone, Email, DataCadastro
                        FROM Paciente";
            return _connection.Query<Paciente>(sql);
        }

        public Paciente ObterPorId(int id)
        {
            var sql = @"SELECT Id, Nome, CPF, DataNascimento, Telefone, Email, DataCadastro
                        FROM Paciente
                        WHERE Id = @Id";
            return _connection.QueryFirstOrDefault<Paciente>(sql, new { Id = id });
        }

        public void Inserir(Paciente paciente)
        {
            var sql = @"INSERT INTO Paciente (Nome, CPF, DataNascimento, Telefone, Email)
                        VALUES (@Nome, @CPF, @DataNascimento, @Telefone, @Email)";
            _connection.Execute(sql, paciente);
        }

        public void Atualizar(Paciente paciente)
        {
            var sql = @"UPDATE Paciente
                        SET Nome = @Nome,
                            CPF = @CPF,
                            DataNascimento = @DataNascimento,
                            Telefone = @Telefone,
                            Email = @Email
                        WHERE Id = @Id";
            _connection.Execute(sql, paciente);
        }

        public void Excluir(int id)
        {
            var sql = @"DELETE FROM Paciente WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }

        public bool ExisteCpf(string cpf)
        {
            var sql = @"SELECT COUNT(*) FROM Paciente WHERE CPF = @CPF";
            int count = _connection.ExecuteScalar<int>(sql, new { CPF = cpf });
            return count > 0;
        }
    }
}