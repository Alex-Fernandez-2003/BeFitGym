using BeFit_Gym.Core.DTOs;

namespace BeFit_Gym.Core.Interfaces
{
    public interface IClienteRepository
    {
        //GETS
        Task<IEnumerable<ClienteGetDTO>> GetClientes();
        Task<ClienteGetDTO?> GetClienteByDNI(string dni);


        //POSTS
        Task CreateCliente(ClientePostDTO cliente);


        //PUTS
        Task<ClientePutDTO?> UpdateCliente(ClientePutDTO cliente);


        //DELETE
        Task<ClienteGetDTO?> DeleteCliente(ClienteDeleteDTO cliente);
    }
}
