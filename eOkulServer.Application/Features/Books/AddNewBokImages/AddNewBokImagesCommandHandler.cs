using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;

namespace eOkulServer.Application.Features.Books.AddNewBokImages;

internal sealed class AddNewBokImagesCommandHandler(
    IBookImageRepository bookImageRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<AddNewBokImagesCommand, Result<List<string>>>
{
    public async Task<Result<List<string>>> Handle(AddNewBokImagesCommand request, CancellationToken cancellationToken)
    {
        List<BookImage> bookImages = new();

        foreach (var file in request.Files)
        {
            string fileName = string.Join(".", DateTime.Now.ToFileTime(), file.FileName);
            using (var stream = File.Create($"wwwroot/book-images/{fileName}"))
            {
                file.CopyTo(stream);
            };

            BookImage bookImage = new()
            {
                BookId = request.BookId,
                ImageUrl = fileName,
            };
            bookImages.Add(bookImage);
        }

        await bookImageRepository.CreateRangeAsync(bookImages, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        List<string> imageUrls = bookImages.Select(s => s.ImageUrl).ToList();

        return imageUrls;
    }
}
