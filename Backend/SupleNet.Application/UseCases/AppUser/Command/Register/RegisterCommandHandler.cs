using MediatR;
using SupleNet.Application.Interfaces.Persistence.Identity;

namespace SupleNet.Application.UseCases.AppUser.Command.Register
{
    internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authService.SignUp(request);

            return Unit.Value;
        }
    }
}
