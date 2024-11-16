using GestionPersonas.Domain.Enums;
using GestionPersonas.Domain.ValueObjects;

namespace GestionPersonas.Application.Comunes
{
    public class PacienteVM
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
