using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class UsuarioApiClient : BaseApiClient
    {
        public static async Task<UsuarioMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();

            return await client.GetFromJsonAsync<UsuarioMostrarDTO>(
                $"api/usuarios/{id}");
        }

        public static async Task<IEnumerable<UsuarioMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();

            var result = await client.GetFromJsonAsync<IEnumerable<UsuarioMostrarDTO>>(
                "api/usuarios");

            return result ?? new List<UsuarioMostrarDTO>();
        }

        public static async Task AddAsync(UsuarioCreaActualizaDTO usuario)
        {
            using var client = await CreateHttpClientAsync();

            var response = await client.PostAsJsonAsync(
                "api/usuarios", usuario);

            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(
            int id,
            UsuarioCreaActualizaDTO usuario)
        {
            using var client = await CreateHttpClientAsync();

            var response = await client.PutAsJsonAsync(
                $"api/usuarios/{id}", usuario);

            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();

            var response = await client.DeleteAsync(
                $"api/usuarios/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}