using GestionPersonas.Application.Comunes;
using GestionPersonas.Application.Contratos;
using GestionPersonas.Domain.Entities;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasPaciente.Comandos
{
    public class CrearComandoManejadorPaciente : IRequestHandler<CrearComandoPaciente, PacienteVM>
    {
        GenericMapperService _genericMapperService;
        IPacienteRepositorio _pacienteRepositorio;

        public CrearComandoManejadorPaciente(GenericMapperService genericMapperService, IPacienteRepositorio pacienteRepositorio)
        {
            _genericMapperService = genericMapperService;
            _pacienteRepositorio = pacienteRepositorio;
        }
        public async Task<PacienteVM> Handle(CrearComandoPaciente request, CancellationToken cancellationToken)
        {
            var MapPaciente = _genericMapperService.Map<CrearComandoPaciente, Paciente>(request);
            var pacienteInsertado = await _pacienteRepositorio.AddAsync(MapPaciente);

            var resultado = _genericMapperService.Map<Paciente, PacienteVM>(pacienteInsertado);

            return resultado;
        }
    }
}
