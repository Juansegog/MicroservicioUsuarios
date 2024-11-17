using FluentValidation;
using GestionPersonas.Domain.Entities;

namespace GestionPersonas.Application.CaracteristicasPaciente.Comandos
{
    public class CrearComandoPacienteValidacion : AbstractValidator<Paciente>
    {
        public CrearComandoPacienteValidacion()
        {
            {
                RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacío");
                RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("El email no es válido");
                RuleFor(x => x.Nombre).MinimumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");
            }
        }
    }
}