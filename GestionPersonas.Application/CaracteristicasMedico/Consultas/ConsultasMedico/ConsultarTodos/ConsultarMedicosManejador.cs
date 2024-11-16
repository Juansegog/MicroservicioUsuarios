using GestionPersonas.Application.Comunes;
using GestionPersonas.Application.Contratos;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasMedico.Consultas.ConsultasMedico.ConsultarTodos
{
    public class ConsultarMedicosManejador : IRequestHandler<ConsultarTodosMedicos, List<MedicoVM>>
    {
        private readonly IMedicoRepositorio _doctorRepository;
        private readonly GenericMapperService _genericMapperService;

        public ConsultarMedicosManejador(IMedicoRepositorio doctorRepository, GenericMapperService genericMapperService)
        {
            _doctorRepository = doctorRepository;
            _genericMapperService = genericMapperService;
        }

        public async Task<List<MedicoVM>> Handle(ConsultarTodosMedicos request, CancellationToken cancellationToken)
        {
            List<MedicoVM> lstMed = new List<MedicoVM>();
            var entities = await _doctorRepository.GetAllAsync();
            var entityObjects = entities.Cast<object>().ToList(); // convertir la lista a List<object>
            return _genericMapperService.MapListFromObject<MedicoVM>(entityObjects);
        }

    }
}
