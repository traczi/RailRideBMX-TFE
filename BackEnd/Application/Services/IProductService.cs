using Application.Models.Product;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponseModel>> GetAllProductAsync();
    Task<ProductResponseModel> CreateProductAsync(ProductResponseModel productResponseModel, IFormFile imgFile);
    Task<ProductResponseModel> GetProductByIdAsync(Guid guid);
    Task<ProductResponseModel> DeleteProduct(Guid guid);
    Task<ProductResponseModel> UpdateProduct(Guid guid,  ProductResponseModel productResponseModel);
}