
using Microsoft.AspNetCore.Identity;

public sealed class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default;
    public string LastName { get; set; } = default;
    public string IdentityNumber { get; set; } = default;
    public DateOnly BirtOfDate { get; set; }
    public string? AvatarUrl { get; set; }
}