namespace SupleNet.Application.Responses.Identity
{
    public record AppUserReponse(Guid id, string name, string lastName, string email, string phoneNumber, string role);
}
