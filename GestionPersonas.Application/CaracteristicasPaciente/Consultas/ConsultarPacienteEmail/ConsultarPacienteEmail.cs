using GestionPersonas.Application.Comunes;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasPaciente.Consultas.ConsultarPacienteEmail
{
    public class ConsultarPacienteEmail : IRequest<PacienteVM>
    {
        public string Email { get; init; }

        public ConsultarPacienteEmail(string email)
        {
            Email = email;
        }
    }
}
