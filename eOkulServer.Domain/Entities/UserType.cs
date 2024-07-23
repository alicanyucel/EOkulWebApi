using eOkulServer.Domain.Abstracts;

namespace eOkulServer.Domain.Entities;
public sealed class UserType : Entity
{
    public string Name { get; set; } = default!;
}