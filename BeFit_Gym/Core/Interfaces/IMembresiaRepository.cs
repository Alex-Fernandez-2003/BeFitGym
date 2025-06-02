using BeFit_Gym.Core.DTOs;

namespace BeFit_Gym.Core.Interfaces
{
    public interface IMembresiaRepository
    { 
        //GETS
        Task<IEnumerable<MembresiaGetDTO>> GetMembresia();
        Task<MembresiaGetDTO?> GetMembresiaByNombre(string nombre);



        //POSTS
        Task CreateMembresia(MembresiaPostDTO membresia);


        //PUTS
        Task<MembresiaPutDTO?> UpdateMembresia(MembresiaPutDTO membresia);


        //DELETE
        Task<MembresiaGetDTO?> DeleteMembresia(MembresiaDeleteDTO membresia);
    }
}
