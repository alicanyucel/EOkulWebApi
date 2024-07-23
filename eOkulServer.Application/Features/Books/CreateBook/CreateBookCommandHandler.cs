using AutoMapper;
using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;
using TS.FileMimeTypeControl;

namespace eOkulServer.Application.Features.Books.CreateBook;

internal sealed class CreateBookCommandHandler(
    IBookRepository bookRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateBookCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        #region Check ISBN Is Valid
        bool isISBNIsValid =
            request.ISBN.Length == 10 ?
            ISBNValidator.IsValidISBN10(request.ISBN) :
            ISBNValidator.IsValidISBN13(request.ISBN);
        if (!isISBNIsValid)
        {
            return Result<string>.Failure("Geçerli bir isbn numarası girin");
        }

        #endregion

        #region Book Unique Check
        bool isISBNExists = await bookRepository.AnyAsync(p => p.ISBN == request.ISBN, cancellationToken);
        if (isISBNExists)
        {
            return Result<string>.Failure("Bu ISBN numarası daha önce kullanılmış");
        }
        #endregion

        #region Image Type Control
        bool checkForJpg = request.CoverImage.CheckForJpg();
        bool checkForPng = request.CoverImage.CheckForPng();

        if (!checkForJpg && !checkForPng)
        {
            return Result<string>.Failure("Kapak resmi geçerli bir resim formatında değil. Lütfen jpg ya da png yükleyin");
        }

        foreach (var image in request.Images)
        {
            checkForJpg = image.CheckForJpg();
            checkForPng = image.CheckForPng();

            if (!checkForJpg && !checkForPng)
            {
                return Result<string>.Failure("Kitap resmi geçerli bir resim formatında değil. Lütfen jpg ya da png yükleyin");
            }
        }
        #endregion

        List<BookImage> bookImages = new();

        #region Save Cover Image
        string coverImageFileName = string.Join(".", DateTime.Now.ToFileTime(), request.CoverImage.FileName);

        using (var stream = File.Create($"wwwroot/book-images/{coverImageFileName}"))
        {
            request.CoverImage.CopyTo(stream);
        }

        BookImage coverBookImage = new()
        {
            ImageUrl = coverImageFileName,
            IsCoverImage = true,
        };
        bookImages.Add(coverBookImage);
        #endregion

        #region Save Images
        foreach (var image in request.Images)
        {
            string imageName = string.Join(".", DateTime.Now.ToFileTime(), image.FileName);

            using (var stream = System.IO.File.Create($"wwwroot/book-images/{imageName}"))
            {
                image.CopyTo(stream);
            }

            BookImage bookImage = new()
            {
                ImageUrl = imageName,
            };
            bookImages.Add(bookImage);
        }
        #endregion

        #region Create Book Categories
        List<BookCategory> bookCategories = request.CategoryIds.Select(s => new BookCategory()
        {
            CategoryId = s
        }).ToList();
        #endregion

        #region Create Book
        Book book = mapper.Map<Book>(request);
        book.BookImages = bookImages;
        book.BookCategories = bookCategories;

        await bookRepository.CreateAsync(book, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        #endregion

        return "Kitap kaydı başarıyla tamamlandı";
    }
}
