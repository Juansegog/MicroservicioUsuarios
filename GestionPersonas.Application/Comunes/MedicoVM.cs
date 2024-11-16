using GestionPersonas.Domain.Enums;
using GestionPersonas.Domain.ValueObjects;

namespace GestionPersonas.Application.Comunes
{
    public record class MedicoVM
    {
        public int Id { get; private init; }
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
