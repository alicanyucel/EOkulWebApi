
using EOkul.Domain.Entities;
using EOkul.Domain.Repositories;
using MediatR;

namespace EOkul.Application.Features.UserTypes.CreateUserType;

internal sealed class CreateUserCommandHandler(IUserTypeRepository userTypeRepository) : IRequestHandler<CreateUserTypeCommand>
{
    public async Task Handle(CreateUserTypeCommand request, CancellationToken cancellationToken)
    {
        bool IsUserExits = await userTypeRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (IsUserExits)
        {
            throw new ArgumentException("user type already exists");
        }
        UserType userType = new()
        {
            Name = request.Name
        };
        await userTypeRepository.CreateAsync(userType, cancellationToken);
    }
}

