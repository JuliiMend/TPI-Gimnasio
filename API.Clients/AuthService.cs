using System;
using System.Threading.Tasks;

namespace API.Clients
{
    public class AuthService : IAuthService
    {
        private readonly AuthApiClient _apiClient = new AuthApiClient();

        public event Action<bool>? AuthenticationStateChanged;

        public Task<bool> IsAuthenticatedAsync() => Task.FromResult(true);
        public Task<string?> GetTokenAsync() => Task.FromResult<string?>("token_simulado");
        public Task<string?> GetUsernameAsync() => Task.FromResult<string?>("SocioTest");

        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new DTOs.LoginRequest { Username = username, Password = password };

            var response = await _apiClient.LoginAsync(request);

            if (response != null)
            {
                AuthenticationStateChanged?.Invoke(true);
                return true;
            }

            return false;
        }

        public Task LogoutAsync() => Task.CompletedTask;
        public Task CheckTokenExpirationAsync() => Task.CompletedTask;
        public Task<bool> HasPermissionAsync(string permission) => Task.FromResult(true);
    }
}