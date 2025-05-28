namespace BeFit_Gym.Core.DTOs
{
    public class UsuarioPostDTO
    {
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }

        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; } = "empleado";
    }
}
