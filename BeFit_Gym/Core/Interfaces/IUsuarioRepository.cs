using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        //VALIDATIONS
        Task<bool> ValidateUsuario(string DNI);
        Task<bool> ValidatePassword(string Password);
        Task<bool> ValidateAccount(UsuarioDeleteDTO credentials);


        //GETS
        Task<IEnumerable<UsuarioGetDTO>> GetUsuario();
        Task<UsuarioGetDTO?> GetUsuarioByDNI(string dni);


        //POSTS
        Task CreateUsuario(UsuarioPostDTO user);


        //PUTS
        Task<UsuarioPutDTO?> UpdateUsuario(UsuarioPutDTO user);


        //DELETE
        Task<UsuarioGetDTO?> DeleteUsuario(UsuarioDeleteDTO user);
    }
}
