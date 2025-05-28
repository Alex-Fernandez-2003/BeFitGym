using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.DTOs
{
    public class ClientePostDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
