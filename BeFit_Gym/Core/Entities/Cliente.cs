namespace BeFit_Gym.Core.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; } = "activo";
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<ClienteMembresia> ClienteMembresias { get; set; } = new List<ClienteMembresia>();
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    }
}
