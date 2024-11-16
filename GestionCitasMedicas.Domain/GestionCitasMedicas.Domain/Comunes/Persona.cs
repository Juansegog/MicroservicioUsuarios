using GestionPersonas.Domain.Enums;
using GestionPersonas.Domain.ValueObjects;

namespace GestionPersonas.Domain.Comunes
{
    public class Persona
    {
        public int Id { get; init; }
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        public DateTime FechaNacimiento { get; init; }
        public Direccion Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; init; }
        public Rol Rol { get; set; }
    }
}
