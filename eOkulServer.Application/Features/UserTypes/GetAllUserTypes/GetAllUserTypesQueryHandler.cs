using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eOkulServer.Application.Features.UserTypes.GetAllUserTypes;

internal sealed class GetAllUserTypesQueryHandler(
    IUserTypeRepository userTypeRepository) : IRequestHandler<GetAllUserTypesQuery, Result<List<UserType>>>
{
    public async Task<Result<List<UserType>>> Handle(GetAllUserTypesQuery request, CancellationToken cancellationToken)
    {
        var response = await userTypeRepository.GetAll().ToListAsync(cancellationToken);
        return response;
    }
}
