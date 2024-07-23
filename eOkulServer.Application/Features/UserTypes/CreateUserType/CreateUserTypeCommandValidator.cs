using FluentValidation;

namespace eOkulServer.Application.Features.UserTypes.CreateUserType;

public sealed class CreateUserTypeCommandValidator : AbstractValidator<CreateUserTypeCommand>
{
    public CreateUserTypeCommandValidator()
    {
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Kullanıcı Tipi en az 3 karakter olmalıdır");
    }
}