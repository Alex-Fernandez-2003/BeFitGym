using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.DTOs
{
    public class MembresiaPutDTO
    {
        public string NombreAntiguo { get; set; }
        public string NombreNuevo { get; set; }
        public int DuracionDias { get; set; }
        public string? Descripcion { get; set; }
    }
}
