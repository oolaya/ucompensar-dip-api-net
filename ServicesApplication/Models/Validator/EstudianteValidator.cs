using Domian.Entity;
using FluentValidation;
using ServiceApplication.Dto;

namespace ServiceApplication
{
    public class EstudianteValidator : AbstractValidator<EstudianteDto>
    {
        public EstudianteValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithErrorCode($"NameEmpty")
            .WithMessage(x => x.Name)
                 .WithName(nameof(Estudiante.Name));
        }
    }
}
