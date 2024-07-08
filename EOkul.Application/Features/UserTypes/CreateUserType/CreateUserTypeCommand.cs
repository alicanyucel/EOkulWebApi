using MediatR;

namespace EOkul.Application.Features.UserTypes.CreateUserType;

public sealed record CreateUserTypeCommand(string Name) : IRequest;

