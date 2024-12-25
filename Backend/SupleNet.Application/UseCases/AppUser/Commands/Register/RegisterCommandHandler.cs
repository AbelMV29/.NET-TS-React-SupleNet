using MediatR;
using SupleNet.Application.Interfaces.Persistence.Identity;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.AppUser.Command.Register
{
    internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<Unit>>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result<Unit>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authService.SignUp(request);
        }
    }
}
