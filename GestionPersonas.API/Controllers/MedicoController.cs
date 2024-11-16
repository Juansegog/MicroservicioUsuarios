using GestionPersonas.Application.CaracteristicasMedico.Comandos.ComandoMedico;
using GestionPersonas.Application.CaracteristicasMedico.Consultas.ConsultasMedico.ConsultaMedicoEmail;
using GestionPersonas.Application.CaracteristicasMedico.Consultas.ConsultasMedico.ConsultarTodos;
using GestionPersonas.Application.Comunes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionPersonas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateMedico")]
        public async Task<ActionResult<int>> CreateMedico([FromBody] CrearComandoMedico patient)
        {
            var result = await _mediator.Send(patient);
            return result;
        }


        [HttpGet(Name = "GetDoctors")]
        public async Task<ActionResult<List<MedicoVM>>> GetDoctors()
        {
            var result = await _mediator.Send(new ConsultarTodosMedicos());
            return result;
        }

        [HttpGet("GetMedicoEmail")]
        public async Task<ActionResult<MedicoVM>> GetMedicoEmail(string email)
        {
            var query = new ConsultaMedicoEmail(email);
            var respPaciente = await _mediator.Send(query);
            return respPaciente;
        }
    }
}
