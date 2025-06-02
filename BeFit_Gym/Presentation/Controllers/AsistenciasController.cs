using BeFit_Gym.Core.DTOs;
using BeFit_Gym.Core.Entities;
using BeFit_Gym.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeFit_Gym.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciasController : ControllerBase
    {
        private readonly IAsistenciaRepository _asistenciaRepository;

        public AsistenciasController(IAsistenciaRepository asistenciaRepository)
        {
            _asistenciaRepository = asistenciaRepository;
        }

        //GET: api/Asistencias/DNI
        [HttpGet("/Asistencia/DNI")]
        public async Task<ActionResult<IEnumerable<AsistenciaGetDTO>>> GetAsistenciaByDNI([FromQuery] string DNI)
        {
            var asistencias = await _asistenciaRepository.GetAsistenciaByDNI(DNI);

            if (asistencias == null)
            {
                return NotFound();
            }
            return Ok(asistencias);
        }

        // POST: api/Asistencias
        [HttpPost("/Asistencia/Crear")]
        public async Task<ActionResult<Asistencia?>> CreateAsistencia([FromBody] AsistenciaPostDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Los datos de la solicitud son requeridos.");
            }
            var asistencia = await _asistenciaRepository.CreateAsistencia(dto);
            if (asistencia != null)
            {
                // Guardado en la BD
                return Ok(asistencia);
            }
            return BadRequest("Error");
        }

        
    }
}
