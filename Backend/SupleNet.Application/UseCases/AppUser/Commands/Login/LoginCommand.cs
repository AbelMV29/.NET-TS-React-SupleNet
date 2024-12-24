using MediatR;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.Responses.Identity;

namespace SupleNet.Application.UseCases.AppUser.Command.Login
{
    public record LoginCommand : IRequest<Result<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
