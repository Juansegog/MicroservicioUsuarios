using GestionPersonas.Application.Comunes;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasPaciente.Consultas.ConsultarTodosPacientes
{
    public class ConsultarTodosPacientes : IRequest<List<PacienteVM>>
    {
        public ConsultarTodosPacientes()
        {
        }
    }
}
