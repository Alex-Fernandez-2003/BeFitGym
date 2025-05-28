namespace BeFit_Gym.Core.Entities
{
    public class Asistencia
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public DateTime FechaHoraEntrada { get; set; } = DateTime.UtcNow.Date;
    }

}
