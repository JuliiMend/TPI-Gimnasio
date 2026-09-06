using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly TPIContext context;

        public ClienteRepository(TPIContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Cliente?> GetAsync(int id)
        {
            return await context.Clientes
                .Include(c => c.Pais)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await context.Clientes
                .Include(c => c.Pais)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            var existingCliente = await context.Clientes.FindAsync(cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.SetNombre(cliente.Nombre);
                existingCliente.SetApellido(cliente.Apellido);
                existingCliente.SetEmail(cliente.Email);
                existingCliente.SetPaisId(cliente.PaisId);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            var query = context.Clientes.Where(c => c.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Cliente>> GetByCriteriaAsync(ClienteCriteria criteria)
        {
            const string sql = @"
                SELECT c.Id, c.Nombre, c.Apellido, c.Email, c.PaisId, c.FechaAlta,
                       p.Nombre as PaisNombre
                FROM Clientes c
                INNER JOIN Paises p ON c.PaisId = p.Id
                WHERE c.Nombre LIKE @SearchTerm
                   OR c.Apellido LIKE @SearchTerm
                   OR c.Email LIKE @SearchTerm
                ORDER BY c.Nombre, c.Apellido";

            var clientes = new List<Cliente>();
            string connectionString = context.Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var cliente = new Cliente(
                    reader.GetInt32(0),    // Id
                    reader.GetString(1),   // Nombre
                    reader.GetString(2),   // Apellido
                    reader.GetString(3),   // Email
                    reader.GetInt32(4),    // PaisId
                    reader.GetDateTime(5)  // FechaAlta
                );

                // Crear y asignar el País
                var pais = new Pais(reader.GetInt32(4), reader.GetString(6)); // PaisId, PaisNombre
                cliente.SetPais(pais);

                clientes.Add(cliente);
            }

            return clientes;
        }

    }
}