using FluentValidation;

namespace SupleNet.Application.UseCases.AppUser.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage($"El Correo Electrónico es obligatorio")
                .EmailAddress().WithMessage($"El Correo Electrónico debe estar en un forma");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage($"El Nombre es obligatorio")
                .Length(3, 20).WithMessage("El Nombre debe contener entre 3 y 20 caracteres");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage($"El Apellido es obligatorio")
                .Length(3, 20).WithMessage("El Apellido debe contener entre 3 y 20 caracteres");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La Contraseña es obligatoria")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{6,15}").WithMessage("La contraseña debe tener entre 6 y 15 caracteres, incluir al menos una letra mayúscula, una letra minúscula, un número y un carácter especial.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("El número de telefono es obligatorio")
                .Matches(@"^\+54 \d{1,2} \d{1,4} \d{8}$").WithMessage("El número de teléfono debe comenzar con +54, seguido de 1 o 2 dígitos, luego 1 a 4 dígitos, y finalmente 8 dígitos.");

        }
    }
}
