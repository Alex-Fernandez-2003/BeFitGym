using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.DTOs
{
    public class ClienteGetDTO
    {
        public string Nombre { get; set; } 
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; } 
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
