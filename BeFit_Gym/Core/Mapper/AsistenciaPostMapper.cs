using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class AsistenciaPostMapper
    {
        public static Asistencia ToEntity(this AsistenciaPostDTO dto, Cliente cliente)
        {
            return new Asistencia
            {
                ClienteId = cliente.Id,
                Cliente = cliente,
            };
        }
    }
}
