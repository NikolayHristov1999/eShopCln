using AutoMapper;
using eShopCln.Application.Products.Commands.CreateProduct;
using eShopCln.Contracts.Products;

namespace eShopCln.API.Common.Mappings
{
    public class ProductMappingConfig : Profile
    {
        public ProductMappingConfig()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>();
        }
    }
}
