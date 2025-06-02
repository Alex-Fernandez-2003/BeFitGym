using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Interfaces
{
    public interface IClienteMembresiaRepository
    {
        //GETS
        Task<IEnumerable<ClienteMembresiaGetDTO>> GetRegistrosByStatus();
        Task<IEnumerable<ClienteMembresiaGetDTO>> GetRegistroByDNI(string dni);

        //POSTS
        Task <ClienteMembresia?>CreateRegistro(ClienteMembresiaPostDTO registro);


        //PUTS
        //Task<ClientePutDTO?> UpdateCliente(ClientePutDTO cliente);


        //DELETE
        //Task<ClienteGetDTO?> DeleteCliente(ClienteDeleteDTO cliente);
    }
}
