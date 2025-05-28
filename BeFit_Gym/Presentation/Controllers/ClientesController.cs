using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;
using BeFit_Gym.Core.Interfaces;
using BeFit_Gym.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BeFit_Gym.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        //GET: api/Clientes
        [HttpGet("/Clientes/Lista")]
        public async Task<ActionResult<IEnumerable<ClienteGetDTO>>> GetUsuario()
        {
            var clientes = await _clienteRepository.GetClientes();
            if (clientes == null || !clientes.Any())
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        //GET: api/Clientes/DNI
        [HttpGet("/Clientes/DNI")]
        public async Task<ActionResult<ClienteGetDTO>> GetClienteByDNI([FromQuery] string DNI)
        {
            var user = await _clienteRepository.GetClienteByDNI(DNI);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Clientes
        [HttpPost("/Cliente/Crear")]
        public async Task<ActionResult<ClientePostDTO>> CreateCliente([FromBody] ClientePostDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Los datos de la solicitud son requeridos.");
            }
            var cliente = await _clienteRepository.GetClienteByDNI(dto.Dni);
            if (cliente == null)
            {
                // Guardado en la BD
                await _clienteRepository.CreateCliente(dto);

                return Ok(dto);
            }
            return BadRequest("El Usuario ya existe");
        }

        // PUT: api/Clientes

        [HttpPut("/Cliente/Actualizar")]
        public async Task<IActionResult> UpdateCliente([FromBody] ClientePutDTO cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Los datos del cliente son requeridos.");
            }

            var existingClient = await _clienteRepository.GetClienteByDNI(cliente.Dni);
            if (existingClient == null)
            {
                return NotFound($"El cliente '{cliente.Nombre}' no existe.");
            }

            await _clienteRepository.UpdateCliente(cliente);
            return Ok(new { Message = "Cliente actualizado exitosamente." });
        }

        // DELETE: api/Clientes

        [HttpDelete("/Cliente/Eliminar")]
        public async Task<IActionResult> DeleteCliente([FromBody] ClienteDeleteDTO user)
        {
            if (user == null)
            {
                return BadRequest("Se requieren los datos.");
            }

            var existingClient = await _clienteRepository.GetClienteByDNI(user.ClienteDni);
            if (existingClient == null)
            {
                return NotFound($"El cliente con Dni {user.ClienteDni} no existe.");
            }

            await _clienteRepository.DeleteCliente(user);
            return Ok(new { Message = "Usuario eliminado exitosamente." });
        }
    }
}