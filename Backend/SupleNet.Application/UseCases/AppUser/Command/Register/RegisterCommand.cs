using MediatR;

namespace SupleNet.Application.UseCases.AppUser.Command.Register
{
    public record RegisterCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
