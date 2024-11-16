using GestionPersonas.Application.Comunes;
using GestionPersonas.Application.Contratos;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasPaciente.Consultas.ConsultarTodosPacientes
{
    public class ConsultaManejadorPaciente : IRequestHandler<ConsultarTodosPacientes, List<PacienteVM>>
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public ConsultaManejadorPaciente(IPacienteRepositorio pacienteRepositorio, GenericMapperService genericMapperService)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _genericMapperService = genericMapperService;
        }
        public async Task<List<PacienteVM>> Handle(ConsultarTodosPacientes request, CancellationToken cancellationToken)
        {
            List<PacienteVM> lstMed = new List<PacienteVM>();
            var entities = await _pacienteRepositorio.GetAllAsync();
            var entityObjects = entities.Cast<object>().ToList(); // convertir la lista a List<object>
            return _genericMapperService.MapListFromObject<PacienteVM>(entityObjects);
        }
    }
}
