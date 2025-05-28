using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Interfaces;
using BeFit_Gym.Core.Mapper;
using BeFit_Gym.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BeFit_Gym.Infraestructure.Repository
{
    public sealed class UsuarioRepository : IUsuarioRepository
    {
        private readonly BeFit_GymContext _context;
        public UsuarioRepository(BeFit_GymContext context)
        {
            this._context = context;
        }

        public async Task<bool> ValidatePassword(string Password)
        {
            var verification = await _context.Usuario.FirstOrDefaultAsync(s => s.PasswordHash.Trim() == Password.Trim());
            if (verification != null) { return true; }
            return false;
        }

        public async Task<bool> ValidateUsuario(string NombreUsuario)
        {
            var verification = await _context.Usuario.FirstOrDefaultAsync(s => s.NombreUsuario.Trim() == NombreUsuario.Trim());
            if (verification != null) { return true; }
            return false;
        }

        public async Task<bool> ValidateAccount(UsuarioDeleteDTO credentials)
        {
            var verificationUser = await ValidateUsuario(credentials.NombreUsuario);
            var verificatePassword = await ValidatePassword(credentials.PasswordHash);
            if (verificatePassword==true && verificationUser==true)
            {
                return true;
            }
            return false;
        }

        async Task<IEnumerable<UsuarioGetDTO>> IUsuarioRepository.GetUsuario()
        {
            string estado = "eliminado";
            return await _context.Usuario
                                .Where(s => s.Estado != estado)
                                .Select(usuario => usuario.ToGetDto())
                                .ToListAsync();
        }

        public async Task<UsuarioGetDTO?> GetUsuarioByDNI(string dni)
        {
            return (await _context.Usuario
                    .FirstOrDefaultAsync(s => s.Dni == dni.Trim()))
                   ?.ToGetDto();
        }
        
        public async Task CreateUsuario(UsuarioPostDTO user)
        {
            var newUser = user.ToEntity();

            _context.Usuario.Add(newUser);
            await _context.SaveChangesAsync();
            return;
        }
        public async Task<UsuarioPutDTO?> UpdateUsuario(UsuarioPutDTO user)
        {
            var existingUser = await _context.Usuario.FirstOrDefaultAsync(s => s.Dni == user.Dni.Trim() && s.PasswordHash == user.PasswordHash.Trim());
            if (existingUser != null)
            {
                var refreshUser = user.MapToEntity(existingUser);
                _context.Entry(existingUser).CurrentValues.SetValues(refreshUser);
                await _context.SaveChangesAsync();
                return (user);
            }
            else
            {
                return (null);
            }

        }

        public async Task<UsuarioGetDTO?> DeleteUsuario(UsuarioDeleteDTO user)
        {
            var existingUser = await _context.Usuario.FirstOrDefaultAsync(s => s.Dni == user.Dni.Trim() && s.PasswordHash == user.PasswordHash.Trim());
            if (existingUser != null)
            {
                var refreshUser = existingUser;
                refreshUser.Estado = "eliminado";
                _context.Entry(existingUser).CurrentValues.SetValues(refreshUser);
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
