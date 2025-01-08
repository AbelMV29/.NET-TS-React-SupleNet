using FluentValidation;

namespace SupleNet.Application.UseCases.Category.Commands.AddCategory
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Nombre de la categoría es requerido");
        }
    }
}
