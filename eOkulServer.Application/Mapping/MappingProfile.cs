using AutoMapper;
using eOkulServer.Application.Features.Books.CreateBook;
using eOkulServer.Application.Features.Categories.CreateCategory;
using eOkulServer.Application.Features.Categories.UpdateCategory;
using eOkulServer.Application.Features.UserTypes.CreateUserType;
using eOkulServer.Application.Features.UserTypes.UpdateUserType;
using eOkulServer.Domain.Entities;

namespace eOkulServer.Application.Mapping;
internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserTypeCommand, UserType>();
        CreateMap<UpdateUserTypeCommand, UserType>();
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
        CreateMap<CreateBookCommand, Book>();
    }
}
