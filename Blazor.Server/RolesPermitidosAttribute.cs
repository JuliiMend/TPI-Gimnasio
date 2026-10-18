namespace Blazor.Server
{
    // Se usa en las páginas (@attribute [RolesPermitidos(...)]) para indicar qué roles pueden abrirlas.
    // Una página sin este atributo la puede ver cualquier usuario logueado.
    // La API valida lo mismo: esto solo evita mostrar pantallas que van a fallar.
    [AttributeUsage(AttributeTargets.Class)]
    public class RolesPermitidosAttribute : Attribute
    {
        public string[] Roles { get; }

        public RolesPermitidosAttribute(params string[] roles)
        {
            Roles = roles;
        }
    }
}
