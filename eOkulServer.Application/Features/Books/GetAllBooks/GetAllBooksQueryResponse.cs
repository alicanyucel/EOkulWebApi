namespace eOkulServer.Application.Features.Books.GetAllBooks;

public sealed record GetAllBooksQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string Summary { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public List<string> BookImageNames { get; set; } = new();
    public string CoverImage { get; set; } = default!;
    public List<string> CategoryNames { get; set; } = new();
}