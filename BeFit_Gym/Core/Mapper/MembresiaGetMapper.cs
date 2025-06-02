using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class MembresiaGetMapper
    {
        public static MembresiaGetDTO ToGetDto(this Membresia membresia)
        {
            return new MembresiaGetDTO
            {
                Nombre = membresia.Nombre,
                DuracionDias = membresia.DuracionDias,
                Descripcion=membresia.Descripcion,
            };
        }
    }
}
