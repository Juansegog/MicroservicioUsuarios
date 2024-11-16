using GestionPersonas.Application.Comunes;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasMedico.Consultas.ConsultasMedico.ConsultarTodos
{
    public class ConsultarTodosMedicos : IRequest<List<MedicoVM>>
    {
        public ConsultarTodosMedicos()
        {

        }
    }
}
