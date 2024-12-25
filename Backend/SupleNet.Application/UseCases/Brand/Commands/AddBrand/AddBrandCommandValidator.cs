using FluentValidation;

namespace SupleNet.Application.UseCases.Brand.Commands.AddBrand
{
    public class AddBrandCommandValidator : AbstractValidator<AddBrandCommand>
    {
        public AddBrandCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Nombre de la marca es requerido");
        }
    }
}
