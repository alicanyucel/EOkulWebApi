using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using MediatR;

namespace eOkulServer.Application.Features.UserTypes.GetAllUserTypes;
public sealed record GetAllUserTypesQuery() : IRequest<Result<List<UserType>>>;
