using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly string _connectionString;

        public MaterialRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<Material>> ObtenerTodosAsync()
        {
            var lista = new List<Material>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT IdMaterial, Descripcion, Stock FROM Materiales";
            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(new Material
                {
                    IdMaterial = reader.GetInt32(reader.GetOrdinal("IdMaterial")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock"))
                });
            }

            return lista;
        }

        public async Task<Material?> ObtenerPorIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT IdMaterial, Descripcion, Stock FROM Materiales WHERE IdMaterial = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Material
                {
                    IdMaterial = reader.GetInt32(reader.GetOrdinal("IdMaterial")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Stock = reader.GetInt32(reader.GetOrdinal("Stock"))
                };
            }

            return null;
        }

        public async Task AgregarAsync(Material material)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = @"INSERT INTO Materiales (Descripcion, Stock)
                          VALUES (@Descripcion, @Stock);
                          SELECT CAST(SCOPE_IDENTITY() AS int);";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Descripcion", material.Descripcion);
            command.Parameters.AddWithValue("@Stock", material.Stock);

            var nuevoId = (int)(await command.ExecuteScalarAsync())!;
            material.IdMaterial = nuevoId;
        }

        public async Task ActualizarAsync(Material material)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = @"UPDATE Materiales
                          SET Descripcion = @Descripcion, Stock = @Stock
                          WHERE IdMaterial = @Id";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", material.IdMaterial);
            command.Parameters.AddWithValue("@Descripcion", material.Descripcion);
            command.Parameters.AddWithValue("@Stock", material.Stock);

            await command.ExecuteNonQueryAsync();
        }

        public async Task EliminarAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "DELETE FROM Materiales WHERE IdMaterial = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }
    }
}