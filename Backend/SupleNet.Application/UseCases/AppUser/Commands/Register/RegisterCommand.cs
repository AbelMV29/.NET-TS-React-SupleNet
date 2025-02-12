using MediatR;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.AppUser.Command.Register
{
    public record RegisterCommand : IRequest<Result<Unit>>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}
