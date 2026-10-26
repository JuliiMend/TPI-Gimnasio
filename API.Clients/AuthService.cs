using System;
using System.Threading.Tasks;

namespace API.Clients
{
    public class AuthService : IAuthService
    {
        private readonly AuthApiClient _apiClient = new AuthApiClient();
        private string? _token;
        private string? _username;
        private string? _rol;
        private DateTime? _expiraUtc;

        public event Action<bool>? AuthenticationStateChanged;
        public Task<bool> IsAuthenticatedAsync() => Task.FromResult(!string.IsNullOrEmpty(_token) && !TokenVencido());
        public Task<string?> GetTokenAsync() => Task.FromResult(_token);
        public Task<string?> GetUsernameAsync() => Task.FromResult(_username);
        public Task<string?> GetRolAsync() => Task.FromResult(_rol);

        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new DTOs.LoginRequest { Username = username, Password = password };

            var response = await _apiClient.LoginAsync(request);

            if (response != null && response.Exito && !string.IsNullOrEmpty(response.Token))
            {
                _token = response.Token;
                _username = response.Username;
                _rol = response.Rol;
                _expiraUtc = response.ExpiresAt;
                AuthenticationStateChanged?.Invoke(true);
                return true;
            }

            return false;
        }

        public Task LogoutAsync()
        {
            _token = null;
            _username = null;
            _rol = null;
            _expiraUtc = null;
            AuthenticationStateChanged?.Invoke(false);
            return Task.CompletedTask;
        }
        public async Task CheckTokenExpirationAsync()
        {
            if (!string.IsNullOrEmpty(_token) && TokenVencido())
            {
                await LogoutAsync();
            }
        }

        private bool TokenVencido() => _expiraUtc.HasValue && DateTime.UtcNow >= _expiraUtc.Value;

        public Task<bool> HasPermissionAsync(params string[] roles) => Task.FromResult(_rol != null && roles.Contains(_rol));
    }
}