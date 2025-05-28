using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;
using BeFit_Gym.Core.Interfaces;
using BeFit_Gym.Core.Mapper;
using BeFit_Gym.Infraestructure.Data;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace BeFit_Gym.Infraestructure.Repository
{
    public sealed class AsistenciaRepository:IAsistenciaRepository
    {
        private readonly BeFit_GymContext _context;
        public AsistenciaRepository(BeFit_GymContext context)
        {
            this._context = context;
        }

        public async Task<Asistencia?> CreateAsistencia(AsistenciaPostDTO dto)
        {
            var existingUser = await _context.Cliente
                .FirstOrDefaultAsync(c => c.Dni == dto.ClienteDni.Trim());

            if (existingUser == null)
                return null;

            var asistencia = dto.ToEntity(existingUser);

            _context.Asistencia.Add(asistencia);
            await _context.SaveChangesAsync();

            return asistencia;
        }

        public async Task<IEnumerable<AsistenciaGetDTO>> GetAsistenciaByDNI(string dni)
        {
            var cliente = await _context.Cliente
                .Include(c => c.Asistencias)
                .FirstOrDefaultAsync(c => c.Dni == dni.Trim());

            if (cliente == null)
                return null;

            var asistenciasDto = cliente.Asistencias
                .Select(a => a.ToGetDto(cliente))
                .OrderByDescending(a => a.FechaHoraEntrada) // Opcional: ordenar por fecha
                .ToList();

            return asistenciasDto;
        }
    }
}
