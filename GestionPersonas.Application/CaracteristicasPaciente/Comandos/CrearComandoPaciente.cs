using GestionPersonas.Application.Comunes;
using GestionPersonas.Domain.Enums;
using GestionPersonas.Domain.ValueObjects;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasPaciente.Comandos
{
    public class CrearComandoPaciente : IRequest<PacienteVM>
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        public DateTime FechaNacimiento { get; init; }
        public Direccion Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; init; }
        public Rol Rol { get; set; }
        public string NumeroHistoriaClinica { get; init; }
        public DateTime FechaIngreso { get; init; }
        public string Diagnostico { get; init; }
    }
}
