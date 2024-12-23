using Microsoft.AspNetCore.Identity;

namespace SupleNet.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
