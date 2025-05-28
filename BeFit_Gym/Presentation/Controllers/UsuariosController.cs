using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeFit_Gym.Core.Entities;
using BeFit_Gym.Infraestructure.Data;
using BeFit_Gym.Core.Interfaces;
using BeFit_Gym.Core.DTOs;

namespace BeFit_Gym.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        //GET: api/Usuarios
        [HttpGet("/Usuarios/Lista")]
        public async Task<ActionResult<IEnumerable<UsuarioGetDTO>>> GetUsuario()
        {
            var usuarios = await _usuarioRepository.GetUsuario();
            if (usuarios == null || !usuarios.Any())
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        //GET: api/Usuarios/name
        [HttpGet("/Usuario/DNI")]
        public async Task<ActionResult<UsuarioGetDTO>> GetUsuarioByDNI([FromQuery] string DNI)
        {
            var user = await _usuarioRepository.GetUsuarioByDNI(DNI);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Usuarios
        [HttpPost("/Usuario/Crear")]
        public async Task<ActionResult<UsuarioPostDTO>> CreateUsuario([FromBody] UsuarioPostDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Los datos de la solicitud son requeridos.");
            }
            var usuario = await _usuarioRepository.GetUsuarioByDNI(userDto.Dni);
            if (usuario == null)
            {
                // Guardado en la BD
                await _usuarioRepository.CreateUsuario(userDto);

                return Ok(userDto);
            }
            return BadRequest("El Usuario ya existe");
        }


        // PUT: api/Usuarios

        [HttpPut("/Usuario/Actualizar")]
        public async Task<IActionResult> UpdateUsuario([FromBody] UsuarioPutDTO user)
        {
            if (user == null)
            {
                return BadRequest("Los datos del usuario son requeridos.");
            }

            var existingUser = await _usuarioRepository.GetUsuarioByDNI(user.Dni);
            var validation = await _usuarioRepository.ValidatePassword(user.PasswordHash);
            if (existingUser == null || validation==false)
            {
                return NotFound($"El usuario '{user.NombreUsuario}' con Dni {user.Dni} no existe.");
            }

            await _usuarioRepository.UpdateUsuario(user);
            return Ok(new { Message = "Usuario actualizado exitosamente." });
        }

        // DELETE: api/Usuarios

        [HttpDelete("/Usuario/Eliminar")]
        public async Task<IActionResult> DeleteUsuario([FromBody] UsuarioDeleteDTO user)
        {
            if (user == null)
            {
                return BadRequest("Se requieren los datos.");
            }

            var existingUser = await _usuarioRepository.GetUsuarioByDNI(user.Dni);
            if (existingUser == null)
            {
                return NotFound($"El usuario '{user.NombreUsuario}' con Dni {user.Dni} no existe.");
            }

            await _usuarioRepository.DeleteUsuario(user);
            return Ok(new { Message = "Usuario eliminado exitosamente." });
        }
    }
}
