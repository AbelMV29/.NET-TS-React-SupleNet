using FluentValidation;

namespace SupleNet.Application.UseCases.Product.Commands.AddProduct
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción del producto es obligatoria.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0.");

            RuleFor(x => x.Files)
                .NotEmpty().WithMessage("Debe adjuntar al menos un archivo.")
                .NotNull().WithMessage("Debe adjuntar al menos un archivo.")
                .Must(files => files != null && files.Any(f => f?.Length > 0)).WithMessage("Ningún archivo puede ser nulo ni tener longitud 0.");
        }
    }
}
 