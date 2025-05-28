using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class AsistenciaGetMapper
    {
        public static AsistenciaGetDTO ToGetDto(this Asistencia asistencia, Cliente cliente)
        {
            return new AsistenciaGetDTO
            {
                Nombre = cliente.Nombre,
                Dni = cliente.Dni,
                Telefono = cliente.Telefono,
                Correo=cliente.Correo,
                FechaHoraEntrada = asistencia.FechaHoraEntrada,
            };
        }
    }
}
