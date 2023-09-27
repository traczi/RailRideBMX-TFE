using Application.Helpers;
using Application.Models.Product;
using Application.Services;
using Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RailRideBMX.Controllers;

public class ProductController : ApiController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetAllProductAsync()
    {
        var product = await _productService.GetAllProductAsync();
        return Ok(product);
    }
    
    [HttpGet]
    [Route("{guid}")]
    public async Task<IActionResult> GetProductByIdAsync(Guid guid)
    {
        var product = await _productService.GetProductByIdAsync(guid);
        return Ok(product);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductResponseModel productResponseModel)
    {
        var createProduct = await _productService.CreateProductAsync(productResponseModel);
        return SuccessResponseHelper.CreatedResponse("Vous avez bien ajouté un article");
    }
    
    [HttpPut]
    [Route("{guid}")]
    public async Task<IActionResult> UpdateProduct(Guid guid, ProductResponseModel productResponseModel)
    {
        var updateProduct = await _productService.UpdateProduct(guid, productResponseModel);
        return Ok(updateProduct);
    }
    
    [HttpDelete]
    [Route("{guid}")]
    public async Task<IActionResult> DeleteProduct(Guid guid)
    {
        var deleteProduct = await _productService.DeleteProduct(guid);
        return Ok(deleteProduct);
    }
}