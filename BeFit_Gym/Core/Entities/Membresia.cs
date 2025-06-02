namespace BeFit_Gym.Core.Entities
{
    public class Membresia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DuracionDias { get; set; }
        public string? Descripcion { get; set; }

        public ICollection<ClienteMembresia> ClienteMembresias { get; set; } = new List<ClienteMembresia>();
        public string Estado { get; set; } = "activa";
    }

}
