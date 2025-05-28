using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class ClientePostMapper
    {
        public static Cliente ToEntity(this ClientePostDTO dto)
        {
            return new Cliente
            {
                Nombre = dto.Nombre,
                Dni = dto.Dni,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                FechaNacimiento=dto.FechaNacimiento,
            };
        }
    }
}
