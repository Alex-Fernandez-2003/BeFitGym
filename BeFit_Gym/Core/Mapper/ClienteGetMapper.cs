using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class ClienteGetMapper
    {
        public static ClienteGetDTO ToGetDto(this Cliente cliente)
        {
            return new ClienteGetDTO
            {
                Nombre = cliente.Nombre,
                Dni = cliente.Dni,
                Telefono = cliente.Telefono,
                Correo=cliente.Correo,
                FechaNacimiento=cliente.FechaNacimiento,
                FechaRegistro = cliente.FechaRegistro,
            };
        }
    }
}
