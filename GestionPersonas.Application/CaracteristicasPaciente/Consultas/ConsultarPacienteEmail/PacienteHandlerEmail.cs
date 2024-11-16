using GestionPersonas.Application.Comunes;
using GestionPersonas.Application.Contratos;
using GestionPersonas.Domain.Entities;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasPaciente.Consultas.ConsultarPacienteEmail
{
    public class PacienteHandlerEmail : IRequestHandler<ConsultarPacienteEmail, PacienteVM>
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public PacienteHandlerEmail(IPacienteRepositorio pacienteRepositorio, GenericMapperService genericMapperService)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _genericMapperService = genericMapperService;
        }
        public async Task<PacienteVM> Handle(ConsultarPacienteEmail request, CancellationToken cancellationToken)
        {
            var paciente = await _pacienteRepositorio.GetPatientByEmail(request.Email);
            PacienteVM resultadoPaciente = _genericMapperService.Map<Paciente, PacienteVM>(paciente);
            return resultadoPaciente;
        }
    }
}
