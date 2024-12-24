using MediatR;
using SupleNet.Application.Interfaces.Persistence.Identity;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.Responses.Identity;

namespace SupleNet.Application.UseCases.AppUser.Command.Login
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponse>>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authService.SignIn(request);
        }
    }
}
