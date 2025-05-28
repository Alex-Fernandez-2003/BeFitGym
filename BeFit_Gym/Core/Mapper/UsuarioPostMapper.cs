using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Mapper
{
    public static class UsuarioPostMapper
    {
        public static Usuario ToEntity(this UsuarioPostDTO dto)
        {
            if (dto.Rol=="")
            {
                return new Usuario
                {
                    NombreUsuario = dto.NombreUsuario,
                    Nombre = dto.Nombre,
                    Dni = dto.Dni,
                    Telefono = dto.Telefono,
                    Correo=dto.Correo,
                    PasswordHash=dto.PasswordHash,
                };
            }
            else
            {
                return new Usuario
                {
                    NombreUsuario = dto.NombreUsuario,
                    Nombre = dto.Nombre,
                    Dni = dto.Dni,
                    Telefono = dto.Telefono,
                    Correo=dto.Correo,
                    PasswordHash=dto.PasswordHash,
                    Rol = dto.Rol,
                };
            }
        }
    }
}
