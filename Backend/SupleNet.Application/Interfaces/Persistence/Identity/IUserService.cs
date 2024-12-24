using SupleNet.Application.Responses.Identity;

namespace SupleNet.Application.Interfaces.Persistence.Identity
{
    public interface IUserService
    {
        Task<AppUserReponse> GetUserById(string id);
    }
}
