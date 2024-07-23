using AutoMapper;
using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;

namespace eOkulServer.Application.Features.UserTypes.CreateUserType;

internal sealed class CreateUserTypeCommandHandler(
    IUserTypeRepository userTypeRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<CreateUserTypeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateUserTypeCommand request, CancellationToken cancellationToken)
    {
        bool isUserTypeExists = await userTypeRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (isUserTypeExists)
        {
            return Result<string>.Failure("Kullanıcı tipi daha önce oluşturulmuş");
        }

        UserType userType = mapper.Map<UserType>(request);

        await userTypeRepository.CreateAsync(userType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kullanıcı tipi kaydı başarıyla tamamlandı";
    }
}
