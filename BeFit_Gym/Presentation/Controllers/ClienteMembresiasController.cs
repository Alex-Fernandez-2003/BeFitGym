using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeFit_Gym.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteMembresiasController : ControllerBase
    {
        private readonly IClienteMembresiaRepository _clienteMembresiaRepository;

        public ClienteMembresiasController(IClienteMembresiaRepository clienteMembresiaRepository)
        {
            _clienteMembresiaRepository = clienteMembresiaRepository;
        }

        //GET: api/Retgistros
        [HttpGet("/Registros/Lista")]
        public async Task<ActionResult<IEnumerable<ClienteMembresiaGetDTO>>> GetRegistrosByStatus()
        {
            var registros = await _clienteMembresiaRepository.GetRegistrosByStatus();
            if (registros == null || !registros.Any())
            {
                return NotFound();
            }
            return Ok(registros);
        }

        //GET: api/Clientes/DNI
        [HttpGet("/Registros/DNI")]
        public async Task<ActionResult<ClienteMembresiaGetDTO>> GetRegistroByDNI([FromQuery] string DNI)
        {
            var user = await _clienteMembresiaRepository.GetRegistroByDNI(DNI);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Registro
        [HttpPost("/Registro/Crear")]
        public async Task<ActionResult<ClienteMembresiaPostDTO>> CreateRegistro([FromBody] ClienteMembresiaPostDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Los datos de la solicitud son requeridos.");
            }
            var registro = await _clienteMembresiaRepository.CreateRegistro(dto);
            if (registro != null)
            {
                return Ok(dto);
            }
            return BadRequest("Error");
        }

        //// PUT: api/Clientes

        //[HttpPut("/Cliente/Actualizar")]
        //public async Task<IActionResult> UpdateCliente([FromBody] ClientePutDTO cliente)
        //{
        //    if (cliente == null)
        //    {
        //        return BadRequest("Los datos del cliente son requeridos.");
        //    }

        //    var existingClient = await _clienteRepository.GetClienteByDNI(cliente.Dni);
        //    if (existingClient == null)
        //    {
        //        return NotFound($"El cliente '{cliente.Nombre}' no existe.");
        //    }

        //    await _clienteRepository.UpdateCliente(cliente);
        //    return Ok(new { Message = "Cliente actualizado exitosamente." });
        //}

        //// DELETE: api/Clientes

        //[HttpDelete("/Cliente/Eliminar")]
        //public async Task<IActionResult> DeleteCliente([FromBody] ClienteDeleteDTO user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest("Se requieren los datos.");
        //    }

        //    var existingClient = await _clienteRepository.GetClienteByDNI(user.ClienteDni);
        //    if (existingClient == null)
        //    {
        //        return NotFound($"El cliente con Dni {user.ClienteDni} no existe.");
        //    }

        //    await _clienteRepository.DeleteCliente(user);
        //    return Ok(new { Message = "Usuario eliminado exitosamente." });
        //}
    }
}
