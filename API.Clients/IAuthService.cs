namespace API.Clients
{
    public interface IAuthService
    {
        event Action<bool>? AuthenticationStateChanged;
        
        Task<bool> IsAuthenticatedAsync();
        Task<string?> GetTokenAsync();
        Task<string?> GetUsernameAsync();
        Task<string?> GetRolAsync();
        Task<DTOs.LoginResponse> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task CheckTokenExpirationAsync();
        Task<bool> HasPermissionAsync(params string[] roles);
    }
}