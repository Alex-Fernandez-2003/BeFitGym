using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class MembresiaPostMapper
    {
        public static Membresia ToEntity(this MembresiaPostDTO dto)
        {
            return new Membresia
            {
                Nombre = dto.Nombre,
                DuracionDias = dto.DuracionDias,
                Descripcion = dto.Descripcion,
            };
        }

    }
}
