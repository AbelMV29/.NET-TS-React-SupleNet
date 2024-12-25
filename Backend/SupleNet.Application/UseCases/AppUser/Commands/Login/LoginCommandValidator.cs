using FluentValidation;

namespace SupleNet.Application.UseCases.AppUser.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage($"El Correo Electrónico es obligatorio")
                .EmailAddress().WithMessage($"El Correo Electrónico debe estar en un forma");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La Contraseña es obligatoria")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{6,15}").WithMessage("La contraseña debe tener entre 6 y 15 caracteres, incluir al menos una letra mayúscula, una letra minúscula, un número y un carácter especial.");

        }
    }
}
