using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SupleNet.Application.Interfaces.Persistence.Identity;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.Responses.Identity;
using SupleNet.Application.UseCases.AppUser.Command.Login;
using SupleNet.Application.UseCases.AppUser.Command.Register;
using SupleNet.Domain.Entities;
using SupleNet.Persistence.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace SupleNet.Persistence.Services
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOptions<JwtSettings> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = options.Value;
        }

        public async Task<Result<LoginResponse>> SignIn(LoginCommand loginCommand)
        {
            var existsUser = await _userManager.FindByEmailAsync(loginCommand.Email);
            if (existsUser is null || !await _userManager.CheckPasswordAsync(existsUser, loginCommand.Password))
                return Result<LoginResponse>.Failed("Tu correo y/o contraseña son incorrectos", HttpStatusCode.BadRequest);

            if (!await _userManager.IsEmailConfirmedAsync(existsUser))
                return Result<LoginResponse>.Failed("Debes validar tu correo antes de iniciar sesión, revisa tu casilla de mensajes", HttpStatusCode.Forbidden);

            var signInResult = await _signInManager.PasswordSignInAsync(existsUser, loginCommand.Password, false, false);
            if (!signInResult.Succeeded)
                return Result<LoginResponse>.Failed("Error al iniciar sesión, intentalo más tarde", HttpStatusCode.InternalServerError);

            return Result<LoginResponse>.Success(new LoginResponse { Token = GetToken(existsUser, await GetRoleName(existsUser)) },
                                                "Sesión iniciada con éxito", HttpStatusCode.OK);
        }

        public async Task<Result<Unit>> SignUp(RegisterCommand registerCommand)
        {
            var existsUser = await _userManager.FindByEmailAsync(registerCommand.Email);

            if (existsUser is not null)
                return Result<Unit>.Failed("Ya existe una cuenta con ese correo electrónico", HttpStatusCode.BadRequest);

            // Crear el nuevo usuario
            var appUserToCreate = new AppUser
            {
                Email = registerCommand.Email,
                UserName = registerCommand.Email,
                Name = registerCommand.Name,
                LastName = registerCommand.LastName,
                EmailConfirmed = false,
                PhoneNumber = registerCommand.PhoneNumber
            };

            var appUserCreatedResult = await _userManager.CreateAsync(appUserToCreate, registerCommand.Password);
            if (!appUserCreatedResult.Succeeded)
                return Result<Unit>.Failed(string.Join(", ", appUserCreatedResult.Errors.Select(error => error.Description)), HttpStatusCode.InternalServerError);

            var asignedRoleResult = await _userManager.AddToRoleAsync(appUserToCreate, "Customer");
            if (!asignedRoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(appUserToCreate);
                return Result<Unit>.Failed(string.Join(", ", asignedRoleResult.Errors.Select(error => error.Description)), HttpStatusCode.InternalServerError);
            }

            return Result<Unit>.Success(Unit.Value, "Usuario registrado exitosamente", HttpStatusCode.Created);
        }

        private async Task<string> GetRoleName(AppUser user)
        {
            return (await _userManager.GetRolesAsync(user)).First();
        }

        private string GetToken(AppUser appUser, string role)
        {
            byte[] keyInBytes = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: GetClaimsUser(appUser, role),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(keyInBytes), SecurityAlgorithms.HmacSha256),
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        private List<Claim> GetClaimsUser(AppUser appUser, string role)
        {
            var claimList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                new Claim("name", appUser.Name),
                new Claim("lastName", appUser.LastName),
                new Claim("email", appUser.Email),
                new Claim(ClaimTypes.Role,role)
            };
            return claimList;
        }
    }
}
