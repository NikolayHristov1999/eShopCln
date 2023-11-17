using AutoMapper;
using eShopCln.Application.Categories.Commands.CreateCategory;
using eShopCln.Contracts.Categories;

namespace eShopCln.API.Common.Mappings
{
    public sealed class CategoryMappingConfig : Profile
    {
        public CategoryMappingConfig()
        {
            CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
        }
    }
}
