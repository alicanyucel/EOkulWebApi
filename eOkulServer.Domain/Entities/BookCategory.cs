using eOkulServer.Domain.Abstracts;

namespace eOkulServer.Domain.Entities;

public sealed class BookCategory : Entity
{
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}
