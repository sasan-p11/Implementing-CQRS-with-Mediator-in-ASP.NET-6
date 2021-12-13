
using Microsoft.AspNetCore.Identity;

namespace Domain.Data.Entities;
public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    public Photo? Photo { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}

