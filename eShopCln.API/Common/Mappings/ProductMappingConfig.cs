using AutoMapper;
using eShopCln.Application.Products.Commands.CreateProduct;
using eShopCln.Application.Products.Commands.UpdateProduct;
using eShopCln.Contracts.Products;

namespace eShopCln.API.Common.Mappings
{
    public class ProductMappingConfig : Profile
    {
        public ProductMappingConfig()
        {
            CreateMap<UpdateProductRequest, UpdateProductCommand>();
            CreateMap<CreateProductRequest, CreateProductCommand>();
        }
    }
}
