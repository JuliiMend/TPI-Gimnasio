using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class MaquinaRepository : IMaquinaRepository
    {
        private readonly string _connectionString;

        public MaquinaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<Maquina>> ObtenerTodosAsync()
        {
            var lista = new List<Maquina>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT IdMaquina, Nombre, Descripcion, Tipo, Estado FROM Maquinas";
            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(new Maquina
                {
                    IdMaquina = reader.GetInt32(reader.GetOrdinal("IdMaquina")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                });
            }

            return lista;
        }

        public async Task<Maquina?> ObtenerPorIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT IdMaquina, Nombre, Descripcion, Tipo, Estado FROM Maquinas WHERE IdMaquina = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Maquina
                {
                    IdMaquina = reader.GetInt32(reader.GetOrdinal("IdMaquina")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                };
            }

            return null;
        }

        public async Task AgregarAsync(Maquina maquina)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = @"INSERT INTO Maquinas (Nombre, Descripcion, Tipo, Estado)
                          VALUES (@Nombre, @Descripcion, @Tipo, @Estado);
                          SELECT CAST(SCOPE_IDENTITY() AS int);";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", maquina.Nombre);
            command.Parameters.AddWithValue("@Descripcion", maquina.Descripcion);
            command.Parameters.AddWithValue("@Tipo", maquina.Tipo);
            command.Parameters.AddWithValue("@Estado", maquina.Estado);

            var nuevoId = (int)(await command.ExecuteScalarAsync())!;
            maquina.IdMaquina = nuevoId;
        }

        public async Task ActualizarAsync(Maquina maquina)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = @"UPDATE Maquinas
                          SET Nombre = @Nombre, Descripcion = @Descripcion, Tipo = @Tipo, Estado = @Estado
                          WHERE IdMaquina = @Id";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", maquina.IdMaquina);
            command.Parameters.AddWithValue("@Nombre", maquina.Nombre);
            command.Parameters.AddWithValue("@Descripcion", maquina.Descripcion);
            command.Parameters.AddWithValue("@Tipo", maquina.Tipo);
            command.Parameters.AddWithValue("@Estado", maquina.Estado);

            await command.ExecuteNonQueryAsync();
        }

        public async Task EliminarAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "DELETE FROM Maquinas WHERE IdMaquina = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }
    }
}