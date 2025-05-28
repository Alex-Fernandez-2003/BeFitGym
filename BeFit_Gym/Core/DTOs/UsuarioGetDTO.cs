namespace BeFit_Gym.Core.DTOs
{
    public class UsuarioGetDTO
    {
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; } = "empleado";
    }
}
