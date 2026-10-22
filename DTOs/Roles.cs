namespace DTOs
{
    // Roles de usuario: se guardan en Usuario.Rol y viajan en el token JWT
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Profesor = "Profesor";
        public const string Socio = "Socio";
    }
}
