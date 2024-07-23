using FluentValidation;

namespace eOkulServer.Application.Features.Books.CreateBook;

public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(p => p.Title).MinimumLength(3).WithMessage("Kitap adı en az 3 karakter olmalıdır");
        RuleFor(p => p.Author).MinimumLength(3).WithMessage("Yazar adı en az 3 karakter olmalıdır");
        RuleFor(p => p.Summary).MinimumLength(100).WithMessage("Kitap özeti en az 100 karakter olmalıdır");
        RuleFor(p => p.ISBN).MinimumLength(10).WithMessage("ISBN numarası en az 10 karakter olmalıdır");
        RuleFor(p => p.ISBN).MaximumLength(13).WithMessage("ISBN numarası en fazla 13 karakter olmalıdır");
    }
}
