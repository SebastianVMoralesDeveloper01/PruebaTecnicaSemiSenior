using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.DTOs;
using PruebaTecnica.Api.Interfa;

namespace PruebaTecnica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController(IPacientes pacientes) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CrearPacienteDto>> CrearPaciente (CrearPacienteDto crearPacienteDto)
        {
            var cerar = await pacientes.PacientesCrear(crearPacienteDto);

            return Ok(cerar);
        }
    }
}
