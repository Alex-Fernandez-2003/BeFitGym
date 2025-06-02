using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class MembresiaPutMapper
    {
        public static Membresia MapToEntity(this MembresiaPutDTO dto, Membresia membresia)
        {
            return new Membresia
            {
                Id = membresia.Id,
                Nombre = dto.NombreNuevo,
                DuracionDias = dto.DuracionDias,
                Descripcion = dto.Descripcion,
                ClienteMembresias = membresia.ClienteMembresias,
            };
        }
    }
}
