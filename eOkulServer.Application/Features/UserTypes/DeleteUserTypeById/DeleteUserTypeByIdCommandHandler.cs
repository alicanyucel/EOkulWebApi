using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;

namespace eOkulServer.Application.Features.UserTypes.DeleteUserTypeById;

internal sealed class DeleteUserTypeByIdCommandHandler(
    IUserTypeRepository userTypeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserTypeByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteUserTypeByIdCommand request, CancellationToken cancellationToken)
    {
        UserType? userType = await userTypeRepository.GetByIdAsync(request.Id, cancellationToken);
        if (userType is null)
        {
            return Result<string>.Failure("Kullanıcı Tipi bulunamadı");
        }

        userType.IsDelete = true;
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kullanıcı Tipi silme işlemi başarılı";
    }
}
