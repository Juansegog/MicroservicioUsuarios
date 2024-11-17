using GestionPersonas.Domain.Comunes;
using GestionPersonas.Domain.Enums;
using GestionPersonas.Domain.ValueObjects;

namespace GestionPersonas.Domain.Entities
{
    public class Medico : Persona
    {
        public Especialidad Especialidad { get; init; }
        public string NumeroLicencia { get; init; }
        public DateTime FechaContrato { get; init; }
        public Departamento Departamento { get; init; }

        private Medico() { }

        public static Medico CrearMedico(string nombre, string apellido, DateTime fechaNacimiento, Direccion direccion,
                                    string telefono, string email, Rol rol, Especialidad especialidad, string numeroLicencia,
                                    DateTime fechaContrato, Departamento departamento)
        {
            return new Medico
            {
                Nombre = nombre,
                Apellido = nombre,
                FechaNacimiento = fechaNacimiento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Rol = rol,
                Especialidad = especialidad,
                NumeroLicencia = numeroLicencia,
                FechaContrato = fechaContrato,
                Departamento = departamento
            };
        }
    }
}