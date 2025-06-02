using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeFit_Gym.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembresiasController : ControllerBase
    {
        private readonly IMembresiaRepository _membresiaRepository;

        public MembresiasController(IMembresiaRepository membresiaRepository)
        {
            _membresiaRepository = membresiaRepository;
        }

        //GET: api/Membresias
        [HttpGet("/Membresias/Lista")]
        public async Task<ActionResult<IEnumerable<MembresiaGetDTO>>> GetMembresia()
        {
            var membresias = await _membresiaRepository.GetMembresia();
            if (membresias == null || !membresias.Any())
            {
                return NotFound();
            }
            return Ok(membresias);
        }

        // POST: api/Membresias
        [HttpPost("/Membresia/Crear")]
        public async Task<ActionResult<MembresiaPostDTO>> CreateMembresia([FromBody] MembresiaPostDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Los datos de la Membresia son requeridos.");
            }
            var cliente = await _membresiaRepository.GetMembresiaByNombre(dto.Nombre);
            if (cliente == null)
            {
                // Guardado en la BD
                await _membresiaRepository.CreateMembresia(dto);

                return Ok(dto);
            }
            return BadRequest("La Membresia ya existe");
        }

        // PUT: api/Membresias

        [HttpPut("/Membresia/Actualizar")]
        public async Task<IActionResult> UpdateMembresia([FromBody] MembresiaPutDTO membresia)
        {
            if (membresia == null)
            {
                return BadRequest("Los datos de la membresia son requeridos.");
            }

            var existingMembresia = await _membresiaRepository.GetMembresiaByNombre(membresia.NombreAntiguo);
            if (existingMembresia == null)
            {
                return NotFound($"La membresia '{membresia.NombreAntiguo}' no existe.");
            }

            await _membresiaRepository.UpdateMembresia(membresia);
            return Ok(new { Message = "Membresia actualizada exitosamente." });
        }

        // DELETE: api/Membresias

        [HttpDelete("/Membresia/Eliminar")]
        public async Task<IActionResult> DeleteMembresia([FromBody] MembresiaDeleteDTO membresia)
        {
            if (membresia == null)
            {
                return BadRequest("Se requieren los datos.");
            }

            var existingMembresia = await _membresiaRepository.GetMembresiaByNombre(membresia.Nombre);
            if (existingMembresia == null)
            {
                return NotFound($"La membresia con nombre {membresia.Nombre} no existe.");
            }

            await _membresiaRepository.DeleteMembresia(membresia);
            return Ok(new { Message = "Membresia eliminada exitosamente." });
        }
    }
}
