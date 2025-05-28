using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.DTOs
{
    public class ClientePutDTO
    {
        public string Dni { get; set; }
        public string Nombre { get; set; } 
        public string Telefono { get; set; } 
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
