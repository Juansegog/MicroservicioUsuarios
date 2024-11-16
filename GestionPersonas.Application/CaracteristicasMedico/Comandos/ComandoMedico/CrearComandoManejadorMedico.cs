using GestionPersonas.Application.Contratos;
using GestionPersonas.Domain.Entities;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasMedico.Comandos.ComandoMedico
{
    public class CrearComandoManejadorMedico : IRequestHandler<CrearComandoMedico, int>
    {
        private readonly IMedicoRepositorio _medicoRepositorio;
        private readonly GenericMapperService _genericMapperService;

        public CrearComandoManejadorMedico(IMedicoRepositorio medicoRepositorio, GenericMapperService genericMapperService)
        {
            _medicoRepositorio = medicoRepositorio;
            _genericMapperService = genericMapperService;
        }

        public async Task<int> Handle(CrearComandoMedico request, CancellationToken cancellationToken)
        {
            var medico = _genericMapperService.Map<CrearComandoMedico, Medico>(request);
            var nuevoMedico = await _medicoRepositorio.AddAsync(medico);
            return nuevoMedico.Id;
        }
    }
}
