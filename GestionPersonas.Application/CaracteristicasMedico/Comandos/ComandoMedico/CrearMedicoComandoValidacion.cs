using FluentValidation;

namespace GestionPersonas.Application.CaracteristicasMedico.Comandos.ComandoMedico
{
    public class CrearMedicoComandoValidacion : AbstractValidator<CrearComandoMedico>
    {
        public CrearMedicoComandoValidacion()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} es requerido")
                .NotNull()
                .MaximumLength(100).WithMessage("{Nombre} el nombre excede los 100 caracteres");
        }
    }
}
