using MediatR;
using SupleNet.Application.Responses;

namespace SupleNet.Application.UseCases.AppUser.Command.Login
{
    public record LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
