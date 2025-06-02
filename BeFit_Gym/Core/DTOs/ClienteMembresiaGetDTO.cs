using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.DTOs
{
    public class ClienteMembresiaGetDTO
    {
        public string nombreCliente {  get; set; }
        public string dniCliente { get; set; }
        public string nombreMembresia { get; set; }
        public int duracionMembresia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
