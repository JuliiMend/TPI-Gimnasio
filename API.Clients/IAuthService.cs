namespace API.Clients
{
    public interface IAuthService
    {
        event Action<bool>? AuthenticationStateChanged;
        
        Task<bool> IsAuthenticatedAsync();
        Task<string?> GetTokenAsync();
        Task<string?> GetUsernameAsync();
        Task<string?> GetRolAsync();
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task CheckTokenExpirationAsync();
        // true si el usuario logueado tiene alguno de los roles indicados
        Task<bool> HasPermissionAsync(params string[] roles);
    }
}