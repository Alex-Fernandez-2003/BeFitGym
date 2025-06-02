using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;
using BeFit_Gym.Core.Interfaces;
using BeFit_Gym.Core.Mapper;
using BeFit_Gym.Infraestructure.Data;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BeFit_Gym.Infraestructure.Repository
{
    public class ClienteMembresiaRepository:IClienteMembresiaRepository
    {
        private readonly BeFit_GymContext _context;
        public ClienteMembresiaRepository(BeFit_GymContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<ClienteMembresiaGetDTO>> GetRegistrosByStatus()
        {
            string estado = "vencida";
            return await _context.ClienteMembresia
                                 .Where(cm => cm.Estado != estado)
                                 .Include(cm => cm.Cliente)
                                 .Include(cm => cm.Membresia)
                                 .Select(cm => cm.ToGetDto())
                                 .ToListAsync();
        }
        public async Task<IEnumerable<ClienteMembresiaGetDTO>> GetRegistroByDNI(string dni)
        {
            string estadoCliente = "eliminado";
            string estadoMembresia = "vencida";

            // Buscar cliente válido por DNI
            var cliente = await _context.Cliente
                                        .Where(c => c.Estado != estadoCliente && c.Dni == dni.Trim())
                                        .FirstOrDefaultAsync();

            if (cliente == null)
                return Enumerable.Empty<ClienteMembresiaGetDTO>();

            // Buscar todas las membresías activas del cliente
            var clienteMembresias = await _context.ClienteMembresia
                                                  .Where(cm => cm.Estado != estadoMembresia && cm.ClienteId == cliente.Id)
                                                  .Include(cm => cm.Cliente)
                                                  .Include(cm => cm.Membresia)
                                                  .Select(cm => cm.ToGetDto())
                                                  .ToListAsync();

            return clienteMembresias;
        }


        public async Task <ClienteMembresia?>CreateRegistro(ClienteMembresiaPostDTO registro)
        {
            var existingClient = await _context.Cliente
            .FirstOrDefaultAsync(c => c.Dni == registro.dniCliente.Trim());

            if (existingClient == null || existingClient.Estado.ToLower() != "activo")
                return null;

            var hoy = DateTime.UtcNow.Date;

            var existingMembresia = await _context.Membresia
            .FirstOrDefaultAsync(c => c.Nombre == registro.nombreMembresia.Trim());

            if (existingMembresia == null || existingMembresia.Estado.ToLower() != "activa")
                return null;

            var newRegistro = registro.ToEntity(existingClient, existingMembresia);

            _context.ClienteMembresia.Add(newRegistro);
            await _context.SaveChangesAsync();

            return newRegistro;
        }
    }
}
