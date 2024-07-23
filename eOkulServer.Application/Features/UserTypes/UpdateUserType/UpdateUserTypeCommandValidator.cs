using FluentValidation;

namespace eOkulServer.Application.Features.UserTypes.UpdateUserType;

public sealed class UpdateUserTypeCommandValidator : AbstractValidator<UpdateUserTypeCommand>
{
    public UpdateUserTypeCommandValidator()
    {
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Kullanıcı Tipi en az 3 karakter olmalıdır");
    }
}
