using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Interfaces;
using BeFit_Gym.Core.Mapper;
using BeFit_Gym.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BeFit_Gym.Infraestructure.Repository
{
    public sealed class ClienteRepository:IClienteRepository
    {
        private readonly BeFit_GymContext _context;
        public ClienteRepository(BeFit_GymContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<ClienteGetDTO>> GetClientes()
        {
            string estado = "eliminado";
            return await _context.Cliente
                                .Where(s => s.Estado != estado)
                                .Select(cliente => cliente.ToGetDto())
                                .ToListAsync();
        }

        public async Task<ClienteGetDTO?> GetClienteByDNI(string dni)
        {
            return (await _context.Cliente
                                .FirstOrDefaultAsync(s => s.Dni == dni.Trim()))
                               ?.ToGetDto();
        }

        public async Task CreateCliente(ClientePostDTO cliente)
        {
            var newClient = cliente.ToEntity();

            _context.Cliente.Add(newClient);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<ClientePutDTO?> UpdateCliente(ClientePutDTO cliente)
        {
            var existingClient = await _context.Cliente.FirstOrDefaultAsync(s => s.Dni == cliente.Dni.Trim());
            if (existingClient != null)
            {
                var refreshClient = cliente.MapToEntity(existingClient);
                _context.Entry(existingClient).CurrentValues.SetValues(refreshClient);
                await _context.SaveChangesAsync();
                return (cliente);
            }
            else
            {
                return (null);
            }
        }

        public async Task<ClienteGetDTO?> DeleteCliente(ClienteDeleteDTO cliente)
        {
            var existingClient = await _context.Cliente.FirstOrDefaultAsync(s => s.Dni == cliente.ClienteDni.Trim());
            if (existingClient != null)
            {
                var refreshUser = existingClient;
                refreshUser.Estado = "eliminado";
                _context.Entry(existingClient).CurrentValues.SetValues(refreshUser);
                await _context.SaveChangesAsync();
                return (refreshUser.ToGetDto());
            }
            else
            {
                return (null);
            }
        }
    }
}
