namespace BeFit_Gym.Core.Entities
{
    public class ClienteMembresia
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int MembresiaId { get; set; }
        public Membresia Membresia { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = "activa"; // "activa", "vencida", "cancelada"
    }

}
