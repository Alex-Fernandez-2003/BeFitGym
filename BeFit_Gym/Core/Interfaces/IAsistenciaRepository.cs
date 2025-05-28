using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Core.Interfaces
{
    public interface IAsistenciaRepository
    {

        //GETS
        Task<IEnumerable<AsistenciaGetDTO>> GetAsistenciaByDNI(string dni);


        //POSTS
        Task <Asistencia?> CreateAsistencia(AsistenciaPostDTO cliente);
    }
}
