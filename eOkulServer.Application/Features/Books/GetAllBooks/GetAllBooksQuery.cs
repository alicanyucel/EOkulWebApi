using eOkulServer.Domain.Abstracts;
using MediatR;

namespace eOkulServer.Application.Features.Books.GetAllBooks;
public sealed record GetAllBooksQuery(
    Guid? CategoryId) : IRequest<Result<List<GetAllBooksQueryResponse>>>;