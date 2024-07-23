using eOkulServer.Domain.Abstracts;

namespace eOkulServer.Domain.Entities;
public sealed class Book : Entity
{
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string Summary { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public List<BookImage>? BookImages { get; set; }
    public List<BookCategory>? BookCategories { get; set; }
}
