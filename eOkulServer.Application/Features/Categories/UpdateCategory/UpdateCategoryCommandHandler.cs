using AutoMapper;
using eOkulServer.Domain.Abstracts;
using eOkulServer.Domain.Entities;
using eOkulServer.Domain.Repositories;
using MediatR;

namespace eOkulServer.Application.Features.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IRequestHandler<UpdateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetByIdAsync(request.Id, cancellationToken);

        if (category is null)
        {
            return Result<string>.Failure("Kategori bulunamadı");
        }

        if (category.Name != request.Name)
        {
            bool isNameExists = await categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isNameExists)
            {
                return Result<string>.Failure("Kategori adı zaten oluşturulmuş");
            }
        }

        mapper.Map(request, category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kategori başarıyla güncellendi";
    }
}
