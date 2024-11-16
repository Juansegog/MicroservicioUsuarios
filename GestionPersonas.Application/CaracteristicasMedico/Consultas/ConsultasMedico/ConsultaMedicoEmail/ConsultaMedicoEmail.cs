using GestionPersonas.Application.Comunes;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasMedico.Consultas.ConsultasMedico.ConsultaMedicoEmail
{
    public class ConsultaMedicoEmail : IRequest<MedicoVM>
    {
        public string Email { get; init; }
        public ConsultaMedicoEmail(string email)
        {
            Email = email;
        }
    }
}
