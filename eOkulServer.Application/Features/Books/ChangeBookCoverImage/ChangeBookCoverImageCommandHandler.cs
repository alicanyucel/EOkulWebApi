using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eOkulServer.Application.Features.Books.ChangeBookCoverImage;

internal sealed class ChangeBookCoverImageCommandHandler(
    IBookImageRepository bookImageRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ChangeBookCoverImageCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ChangeBookCoverImageCommand request, CancellationToken cancellationToken)
    {
        BookImage? bookImage = await bookImageRepository.Where(p => p.BookId == request.BookId && p.IsCoverImage == true).FirstOrDefaultAsync(cancellationToken);

        if (bookImage is not null)
        {
            bookImage.IsCoverImage = false;
        }

        BookImage? newBookImage = await bookImageRepository.Where(p => p.BookId == request.BookId && p.ImageUrl == request.ImageUrl).FirstOrDefaultAsync(cancellationToken);

        if (newBookImage is null)
        {
            return Result<string>.Failure("Resim bulunamadı");
        }

        newBookImage.IsCoverImage = true;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kapak resmi başarıyla değiştirildi";
    }
}
