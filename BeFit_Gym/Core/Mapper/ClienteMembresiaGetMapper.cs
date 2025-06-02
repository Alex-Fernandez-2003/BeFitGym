using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class ClienteMembresiaGetMapper
    {
        public static ClienteMembresiaGetDTO ToGetDto(this ClienteMembresia registro)
        {
            return new ClienteMembresiaGetDTO
            {
                nombreCliente = registro.Cliente.Nombre,
                dniCliente = registro.Cliente.Dni,
                nombreMembresia = registro.Membresia.Nombre,
                duracionMembresia = registro.Membresia.DuracionDias,
                FechaInicio = registro.FechaInicio,
                FechaFin=registro.FechaFin,
            };
        }
    }
}
