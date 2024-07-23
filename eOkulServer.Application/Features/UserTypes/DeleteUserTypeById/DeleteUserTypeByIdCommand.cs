using eOkulServer.Domain.Abstracts;
using MediatR;

namespace eOkulServer.Application.Features.UserTypes.DeleteUserTypeById;
public sealed record DeleteUserTypeByIdCommand(Guid Id) : IRequest<Result<string>>;
