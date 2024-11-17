using GestionPersonas.Domain.Comunes;
using GestionPersonas.Domain.Enums;
using GestionPersonas.Domain.ValueObjects;

namespace GestionPersonas.Domain.Entities
{
    public class Paciente : Persona
    {

        //Es un Value Object
        public string NumeroHistoriaClinica { get; init; }
        public DateTime FechaIngreso { get; init; }
        public string Diagnostico { get; init; }


        private Paciente() { }

        public static Paciente CreatePaciente(string nombre, string apellido, DateTime fechaNacimiento,
            Direccion direccion, string telefono, string email, Rol rol, string numeroHistoriaClinica,
            DateTime fechaIngreso, string diagnostico)
        {
            return new Paciente()
            {
                Nombre = nombre,
                Apellido = nombre,
                FechaNacimiento = fechaNacimiento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Rol = rol,
                NumeroHistoriaClinica = numeroHistoriaClinica,
                FechaIngreso = fechaIngreso,
                Diagnostico = diagnostico
            };
        }
    }
}
