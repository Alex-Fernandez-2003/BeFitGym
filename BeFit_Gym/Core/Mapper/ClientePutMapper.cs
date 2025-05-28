using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class ClientePutMapper
    {
        public static Cliente MapToEntity(this ClientePutDTO dto, Cliente cliente)
        {
            return new Cliente
            {
                Id = cliente.Id,
                Nombre = dto.Nombre,
                Dni = cliente.Dni,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                FechaNacimiento = dto.FechaNacimiento,
                Estado= cliente.Estado,
                FechaRegistro= cliente.FechaRegistro,
                ClienteMembresias= cliente.ClienteMembresias,
                Asistencias=cliente.Asistencias,
            };
        }
    }
}
