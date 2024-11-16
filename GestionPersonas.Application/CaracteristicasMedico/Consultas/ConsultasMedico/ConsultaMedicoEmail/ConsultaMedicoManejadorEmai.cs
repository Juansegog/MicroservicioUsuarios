using GestionPersonas.Application.Comunes;
using GestionPersonas.Application.Contratos;
using GestionPersonas.Domain.Entities;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasMedico.Consultas.ConsultasMedico.ConsultaMedicoEmail
{
    public class ConsultaMedicoManejadorEmai : IRequestHandler<ConsultaMedicoEmail, MedicoVM>
    {
        private readonly IMedicoRepositorio _doctorRepository;
        private readonly GenericMapperService _genericMapperService;

        public ConsultaMedicoManejadorEmai(IMedicoRepositorio doctorRepository, GenericMapperService genericMapperService)
        {
            _doctorRepository = doctorRepository;
            _genericMapperService = genericMapperService;
        }

        public async Task<MedicoVM> Handle(ConsultaMedicoEmail request, CancellationToken cancellationToken)
        {
            var medico = await _doctorRepository.GetDoctorByEmail(request.Email);
            MedicoVM resultadoMedico = _genericMapperService.Map<Medico, MedicoVM>(medico);
            return resultadoMedico;
        }
    }
}
