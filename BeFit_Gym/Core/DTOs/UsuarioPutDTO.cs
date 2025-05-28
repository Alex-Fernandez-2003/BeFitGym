namespace BeFit_Gym.Core.DTOs
{
    public class UsuarioPutDTO
    {
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; } = "empleado";
        public string Estado { get; set; } = "activo";
    }
}
