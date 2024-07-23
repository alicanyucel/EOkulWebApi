using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eOkulServer.Application.Features.Books.GetAllBooks;

internal sealed class GetAllBooksQueryHandler(
    IBookRepository bookRepository) : IRequestHandler<GetAllBooksQuery, Result<List<GetAllBooksQueryResponse>>>
{
    public async Task<Result<List<GetAllBooksQueryResponse>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        List<GetAllBooksQueryResponse> response =
            await bookRepository
            .Where(p =>
                    request.CategoryId != null ?
                    p.BookCategories!.Any(p => p.Id == request.CategoryId) :
                    p.BookCategories!.Any())
            .Include(p => p.BookCategories)!
            .ThenInclude(i => i.Category)
            .Include(p => p.BookImages)
            .Select(s => new GetAllBooksQueryResponse()
            {
                Id = s.Id,
                Author = s.Author,
                ISBN = s.ISBN,
                Summary = s.Summary,
                Title = s.Title,
                CategoryNames = s.BookCategories!.Select(s => s.Category!.Name).ToList(),
                BookImages = s.BookImages!.Select(s => s.ImageUrl).ToList(),
                CoverImage = s.BookImages!.First(s => s.IsCoverImage == true).ImageUrl
            }).ToListAsync(cancellationToken);

        return response;
    }
}
