using GestionPersonas.Domain.Comunes;

namespace GestionPersonas.Domain.Entities
{
    public class Paciente : Persona
    {

        //Es un Value Object
        public string NumeroHistoriaClinica { get; init; }
        public DateTime FechaIngreso { get; init; }
        public string Diagnostico { get; init; }
    }
}
