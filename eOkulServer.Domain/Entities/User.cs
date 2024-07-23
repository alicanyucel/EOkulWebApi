using eOkulServer.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace eOkulServer.Domain.Entities;
public sealed class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string IdentityNumber { get; set; } = default!;
    public DateOnly BirthOfDate { get; set; }
    public string? AvatarUrl { get; set; }
    public Address Address { get; set; } = default!;
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
}
