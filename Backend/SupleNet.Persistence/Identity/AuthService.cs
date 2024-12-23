using Microsoft.AspNetCore.Identity;
using SupleNet.Application.Interfaces.Persistence.Identity;
using SupleNet.Application.Responses;
using SupleNet.Application.UseCases.AppUser.Command.Login;
using SupleNet.Application.UseCases.AppUser.Command.Register;
using SupleNet.Domain.Entities;

namespace SupleNet.Persistence.Identity
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResponse> SignIn(LoginCommand loginCommand)
        {
            var existsUser = await _userManager.FindByEmailAsync(loginCommand.Email);
        }

        public async Task SignUp(RegisterCommand registerCommand)
        {
            var existsUser = await _userManager.FindByEmailAsync(registerCommand.Email);

            if (existsUser is not null)
                throw new ArgumentException("Ya existe una cuenta con ese correo electrónico");

            var appUserToCreate = new AppUser
            {
                Email = registerCommand.Email,
                UserName = registerCommand.Email,
                Name = registerCommand.Name,
                LastName = registerCommand.Name,
                EmailConfirmed = false,
                PhoneNumber = registerCommand.PhoneNumber
            };

            var appUserCreated = await _userManager.CreateAsync(appUserToCreate, registerCommand.Password);

        }
    }
}
