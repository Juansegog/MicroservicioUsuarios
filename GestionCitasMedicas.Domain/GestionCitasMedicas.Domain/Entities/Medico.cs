using GestionPersonas.Domain.Comunes;
using GestionPersonas.Domain.Enums;

namespace GestionPersonas.Domain.Entities
{
    public class Medico : Persona
    {
        public Especialidad Especialidad { get; init; }
        public string NumeroLicencia { get; init; }
        public DateTime FechaContrato { get; init; }
        public Departamento Departamento { get; init; }
    }
}
