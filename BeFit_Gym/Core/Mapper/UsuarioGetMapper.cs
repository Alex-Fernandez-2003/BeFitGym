using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class UsuarioGetMapper
    {
        public static UsuarioGetDTO ToGetDto(this Usuario user)
        {
            return new UsuarioGetDTO
            {
                NombreUsuario = user.NombreUsuario,
                Nombre = user.Nombre,
                Telefono = user.Telefono,
                Correo=user.Correo,
                Rol=user.Rol,
            };
        }

    }
}
