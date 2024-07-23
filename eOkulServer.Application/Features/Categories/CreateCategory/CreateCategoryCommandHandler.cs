using AutoMapper;
using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;

namespace eOkulServer.Application.Features.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        bool isNameExists = await categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isNameExists)
        {
            return Result<string>.Failure("Kategori adı zaten oluşturulmuş");
        }

        Category category = mapper.Map<Category>(request);

        await categoryRepository.CreateAsync(category, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kategori başarıyla oluşturuldu";
    }
}
