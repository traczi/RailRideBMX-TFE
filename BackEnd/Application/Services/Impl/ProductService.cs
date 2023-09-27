﻿using Application.Models.Product;
using Core.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Impl;

public class ProductService : IProductService
{
    private readonly string _imageDirectory = "wwwroot/images";
    private readonly IProductRepository _productRepository;
    private readonly IImageService _imageService;

    public ProductService(IProductRepository productRepository, IImageService imageService)
    {
        _productRepository = productRepository;
        _imageService = imageService;
    }

    public async Task<IEnumerable<ProductResponseModel>> GetAllProductAsync()
    {
        var product = await _productRepository.GetProductAsync();
        return product.Select(x => new ProductResponseModel() { Id = x.Id, Brand = x.Brand, Price = x.Price }).ToList();
    }
    
    public async Task<ProductResponseModel> GetProductByIdAsync(Guid guid)
    {
        var product = await _productRepository.GetProductByIdAsync(guid);
        var productById = new ProductResponseModel()
        {
            Brand = product.Brand,
            Id = product.Id,
            Price = product.Price
            
        };
        return productById;
    }

    public async Task<ProductResponseModel> CreateProductAsync(ProductResponseModel productResponseModel, IFormFile imgFile)
    {
        
        if (imgFile == null || imgFile.Length <= 0)
        {
            throw new Exception("No image upload.");
        }
        
        var uniqueFileName = Guid.NewGuid().ToString() + "-" + imgFile.FileName;
        var filePath = Path.Combine(_imageDirectory, "images", uniqueFileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imgFile.CopyToAsync(fileStream);
        }
        var imageUrl = "/images/" + uniqueFileName;
        var product = new Product()
        {
            Brand = productResponseModel.Brand,
            Price = productResponseModel.Price,
            Color = productResponseModel.Color,
            Height = productResponseModel.Height,
            Description = productResponseModel.Description,
            Image = imageUrl,
            Title = productResponseModel.Title,
            Quantity = productResponseModel.Quantity,
            Type = productResponseModel.Type
        };
        var createProduct = await _productRepository.CreateProduct(product);
        return new ProductResponseModel()
        {
            Brand = createProduct.Brand,
            Price = createProduct.Price,
            Color = createProduct.Color,
            Height = createProduct.Height,
            Description = createProduct.Description,
            Image = createProduct.Image,
            Title = createProduct.Title,
            Quantity = createProduct.Quantity,
            Type = createProduct.Type
        };
    }

    public async Task<ProductResponseModel> UpdateProduct(Guid guid, ProductResponseModel productResponseModel)
    {
        var productId = await _productRepository.GetProductByIdAsync(guid);
        productId.Brand = productResponseModel.Brand;
        productId.Price = productResponseModel.Price;
        var updateProduct = await _productRepository.UpdateProduct(productId);
        return new ProductResponseModel()
        {
            Brand = updateProduct.Brand,
            Id = updateProduct.Id,
            Price = updateProduct.Price
        };
    }
    
    public async Task<ProductResponseModel> DeleteProduct(Guid guid)
    {
        var product = await _productRepository.GetProductByIdAsync(guid);
        var productDelete = await _productRepository.DeleteProduct(product);
        var productModel = new ProductResponseModel()
        {
            Brand = productDelete.Brand,
            Id = productDelete.Id,
            Price = productDelete.Price
        };
        return productModel;
    }
}