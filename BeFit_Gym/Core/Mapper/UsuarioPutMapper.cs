using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class UsuarioPutMapper
    {
        public static Usuario MapToEntity(this UsuarioPutDTO dto, Usuario user)
        {
            return new Usuario
            {
                Id = user.Id,
                NombreUsuario = dto.NombreUsuario,
                Nombre = dto.Nombre,
                Dni = dto.Dni,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                PasswordHash = dto.PasswordHash,
                Rol= dto.Rol,
                Estado= dto.Estado,
            };
        }
    }
}
