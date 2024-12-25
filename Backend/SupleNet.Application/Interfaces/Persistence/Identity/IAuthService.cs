using MediatR;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.Responses.Identity;
using SupleNet.Application.UseCases.AppUser.Command.Login;
using SupleNet.Application.UseCases.AppUser.Command.Register;

namespace SupleNet.Application.Interfaces.Persistence.Identity
{
    public interface IAuthService
    {
        Task<Result<Unit>> SignUp(RegisterCommand registerCommand);   
        Task<Result<LoginResponse>> SignIn(LoginCommand loginCommand);
    }
}
