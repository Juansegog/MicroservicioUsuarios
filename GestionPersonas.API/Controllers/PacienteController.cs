using GestionPersonas.Application.CaracteristicasPaciente.Comandos;
using GestionPersonas.Application.CaracteristicasPaciente.Consultas.ConsultarPacienteEmail;
using GestionPersonas.Application.CaracteristicasPaciente.Consultas.ConsultarTodosPacientes;
using GestionPersonas.Application.Comunes;
using GestionPersonas.Domain.ExcepcionesGenerales;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionPersonas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreatePaciente")]
        public async Task<ActionResult<PacienteVM>> CreateMedico([FromBody] CrearComandoPaciente paciente)
        {
            var result = await _mediator.Send(paciente);
            return result;
        }

        [HttpGet(Name = "GetPacientes")]
        public async Task<ActionResult<List<PacienteVM>>> GetPacientes()
        {
            var result = await _mediator.Send(new ConsultarTodosPacientes());
            return result;
        }

        [HttpGet("GetPacienteEmail")]
        public async Task<ActionResult<PacienteVM>> GetPacienteEmail(string email)
        {
            try
            {
                var query = new ConsultarPacienteEmail(email);
                var respPaciente = await _mediator.Send(query);
                return respPaciente;
            }
            catch (NoHayDatosException ex)
            {
                return NotFound(new
                {
                    Message = ex.Message
                });
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }
    }
}
