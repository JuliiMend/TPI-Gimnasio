namespace API.Clients
{
    public static class AuthServiceProvider
    {
        private static IAuthService? _instance;
        private static readonly object _lock = new object();

        // Sesión del flujo de ejecución actual (en Blazor Server, una por circuito/usuario).
        // Si no hay una, se usa la instancia global registrada (WinForms).
        private static readonly AsyncLocal<IAuthService?> _actual = new AsyncLocal<IAuthService?>();

        public static IAuthService Instance
        {
            get
            {
                var actual = _actual.Value ?? _instance;

                if (actual == null)
                {
                    throw new InvalidOperationException(
                        "AuthService has not been registered. Call AuthServiceProvider.Register() first.");
                }
                return actual;
            }
        }

        public static void SetActual(IAuthService? authService)
        {
            _actual.Value = authService;
        }

        public static void Register(IAuthService authService)
        {
            lock (_lock)
            {
                _instance = authService;
            }
        }

        public static void Clear()
        {
            lock (_lock)
            {
                _instance = null;
            }
        }
    }
}