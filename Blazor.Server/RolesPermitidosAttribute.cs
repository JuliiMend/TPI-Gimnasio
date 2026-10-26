namespace Blazor.Server
{
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
