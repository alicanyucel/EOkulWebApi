using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eOkulServer.Application.Features.Books.RemoveBookImage;

internal sealed class RemoveBookImageCommandHandler(
    IBookImageRepository bookImageRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveBookImageCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RemoveBookImageCommand request, CancellationToken cancellationToken)
    {
        int count = await bookImageRepository.Where(p => p.BookId == request.BookId).CountAsync(cancellationToken);

        if (count <= 1)
        {
            return Result<string>.Failure("Son resmi silemezsiniz!", 500);
        }

        BookImage? bookImage = await bookImageRepository.Where(p => p.BookId == request.BookId && p.ImageUrl == request.ImageUrl).FirstOrDefaultAsync(cancellationToken);

        if (bookImage is null)
        {
            return Result<string>.Failure("Kitap resmi bulunamadı", 404);
        }

        if (bookImage.IsCoverImage)
        {
            BookImage? newBookImage = await bookImageRepository.Where(p => p.BookId == request.BookId && p.ImageUrl != request.ImageUrl).FirstOrDefaultAsync(cancellationToken);

            if (newBookImage is not null)
            {
                newBookImage.IsCoverImage = true;
            }
        }

        bookImageRepository.Delete(bookImage);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        System.IO.File.Delete($"wwwroot/book-images/{request.ImageUrl}");

        return "Kitap resmi başarıyla silindi";
    }
}
