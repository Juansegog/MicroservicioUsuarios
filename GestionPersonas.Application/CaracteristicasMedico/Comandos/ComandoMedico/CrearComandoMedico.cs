using GestionPersonas.Domain.Enums;
using GestionPersonas.Domain.ValueObjects;
using MediatR;

namespace GestionPersonas.Application.CaracteristicasMedico.Comandos.ComandoMedico
{
    public record CrearComandoMedico : IRequest<int>
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        public DateTime FechaNacimiento { get; init; }
        public Direccion Direccion { get; init; }
        public string Telefono { get; init; }
        public string Email { get; init; }
        public Rol Rol { get; init; }
        public Especialidad Especialidad { get; init; }
        public string NumeroLicencia { get; init; }
        public DateTime FechaContrato { get; init; }
        public Departamento Departamento { get; init; }
    }
}
