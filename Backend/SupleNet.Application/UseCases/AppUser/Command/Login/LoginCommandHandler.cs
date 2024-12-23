using MediatR;
using SupleNet.Application.Interfaces.Persistence.Identity;
using SupleNet.Application.Responses;

namespace SupleNet.Application.UseCases.AppUser.Command.Login
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return _authService.SignIn(request);
        }
    }
}
