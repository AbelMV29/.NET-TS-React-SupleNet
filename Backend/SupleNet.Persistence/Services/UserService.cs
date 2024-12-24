using Microsoft.AspNetCore.Identity;
using SupleNet.Application.Interfaces.Persistence.Identity;
using SupleNet.Application.Responses.Identity;
using SupleNet.Domain.Entities;

namespace SupleNet.Persistence.Services
{
    internal class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUserReponse?> GetUserById(string id)
        {
            var userFound = await _userManager.FindByIdAsync(id);
            if (userFound is null)
                return null;
            return new AppUserReponse(userFound.Id,
                userFound.Name, userFound.LastName
                , userFound.Email!, userFound.PhoneNumber!,
                (await _userManager.GetRolesAsync(userFound)).First());
        }
    }
}
