using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class ClienteMembresiaPostMapper
    {
        public static ClienteMembresia ToEntity(this ClienteMembresiaPostDTO dto, Cliente cliente, Membresia membresia)
        {
            return new ClienteMembresia
            {
                ClienteId = cliente.Id,
                Cliente = cliente,
                MembresiaId = membresia.Id,
                Membresia = membresia,
                FechaInicio = DateTime.UtcNow.Date,
                FechaFin = DateTime.UtcNow.Date.AddDays(membresia.DuracionDias),
            };
        }
    }
}
