using SupleNet.Application.Responses;
using SupleNet.Application.UseCases.AppUser.Command.Login;
using SupleNet.Application.UseCases.AppUser.Command.Register;

namespace SupleNet.Application.Interfaces.Persistence.Identity
{
    public interface IAuthService
    {
        Task SignUp(RegisterCommand registerCommand);   
        Task<LoginResponse> SignIn(LoginCommand loginCommand);
    }
}
