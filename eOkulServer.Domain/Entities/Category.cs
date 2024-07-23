using eOkulServer.Domain.Abstracts;

namespace eOkulServer.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; set; } = default!;
}