using eOkulServer.Domain.Abstracts;

namespace eOkulServer.Domain.Entities;

public sealed class BookImage : Entity
{
    public Guid BookId { get; set; }
    public string ImageUrl { get; set; } = default!;
    public bool IsCoverImage { get; set; }
}
