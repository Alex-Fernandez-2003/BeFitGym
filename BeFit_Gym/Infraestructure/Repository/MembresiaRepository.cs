using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;
using BeFit_Gym.Core.Interfaces;
using BeFit_Gym.Core.Mapper;
using BeFit_Gym.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BeFit_Gym.Infraestructure.Repository
{
    public class MembresiaRepository:IMembresiaRepository
    {
        private readonly BeFit_GymContext _context;
        public MembresiaRepository(BeFit_GymContext context)
        {
            this._context = context;
        }


        public async Task<IEnumerable<MembresiaGetDTO>> GetMembresia()
        {
            string estado = "inactiva";
            return await _context.Membresia
                                .Where(s => s.Estado != estado)
                                .Select(membresia => membresia.ToGetDto())
                                .ToListAsync();
        }
        public async Task<MembresiaGetDTO?> GetMembresiaByNombre(string nombre)
        {
            string estado = "inactiva";
            return (await _context.Membresia
                                            .Where(s => s.Estado != estado)
                                            .FirstOrDefaultAsync(s => s.Nombre == nombre.Trim()))
                                           ?.ToGetDto();
        }

        public async Task CreateMembresia(MembresiaPostDTO membresia)
        {

            var newMembresia = membresia.ToEntity();

            _context.Membresia.Add(newMembresia);
            await _context.SaveChangesAsync();
            return;
            
        }

        public async Task<MembresiaPutDTO?> UpdateMembresia(MembresiaPutDTO membresia)
        {
            var exisitingMembresia = await _context.Membresia.FirstOrDefaultAsync(s => s.Nombre == membresia.NombreAntiguo.Trim());
            if (exisitingMembresia != null)
            {
                var refreshMembresia = membresia.MapToEntity(exisitingMembresia);
                _context.Entry(exisitingMembresia).CurrentValues.SetValues(refreshMembresia);
                await _context.SaveChangesAsync();
                return (membresia);
            }
            else
            {
                return (null);
            }
        }

        public async Task<MembresiaGetDTO?> DeleteMembresia(MembresiaDeleteDTO membresia)
        {
            var exisitingMembresia = await _context.Membresia.FirstOrDefaultAsync(s => s.Nombre == membresia.Nombre.Trim());
            if (exisitingMembresia != null)
            {
                var refreshMembresia = exisitingMembresia;
                refreshMembresia.Estado = "inactiva";
                _context.Entry(exisitingMembresia).CurrentValues.SetValues(refreshMembresia);
                await _context.SaveChangesAsync();
                return (refreshMembresia.ToGetDto());
            }
            else
            {
                return (null);
            }
        }
    }
}
