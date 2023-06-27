using Application.Models.Bmx;
using Core.Entities;
using DataAccess.Repositories;

namespace Application.Services.Impl;

public class BmxService : IBmxService
{
    private readonly IBmxRepository _bmxRepository;

    public BmxService(IBmxRepository bmxRepository)
    {
        _bmxRepository = bmxRepository;
    }

    public async Task<IEnumerable<BmxResponseModel>> GetAllBmxAsync()
    {
        var bmx = await _bmxRepository.GetBmxAsync();
        return bmx.Select(x => new BmxResponseModel() { Id = x.Id, Brand = x.Brand, Price = x.Price }).ToList();
    }
    
    public async Task<BmxResponseModel> GetBmxByIdAsync(Guid guid)
    {
        var bmx = await _bmxRepository.GetBmxByIdAsync(guid);
        var bmxById = new BmxResponseModel()
        {
            Brand = bmx.Brand,
            Id = bmx.Id,
            Price = bmx.Price
        };
        return bmxById;
    }

    public async Task<BmxResponseModel> CreateBmxAsync(BmxResponseModel bmxResponseModel)
    {
        var bmx = new Bmx()
        {
            Brand = bmxResponseModel.Brand,
            Id = bmxResponseModel.Id,
            Price = bmxResponseModel.Price
        };
        var createBmx = await _bmxRepository.CreateBmx(bmx);
        return new BmxResponseModel()
        {
            Brand = createBmx.Brand,
            Id = createBmx.Id,
            Price = createBmx.Price
        };
    }

    public async Task<BmxResponseModel> UpdateBmx(Guid guid, BmxResponseModel bmxResponseModel)
    {
        var bmxId = await _bmxRepository.GetBmxByIdAsync(guid);
        bmxId.Brand = bmxResponseModel.Brand;
        bmxId.Price = bmxResponseModel.Price;
        var updateBmx = await _bmxRepository.UpdateBmx(bmxId);
        return new BmxResponseModel()
        {
            Brand = updateBmx.Brand,
            Id = updateBmx.Id,
            Price = updateBmx.Price
        };
    }
    
    public async Task<BmxResponseModel> DeleteBmx(Guid guid)
    {
        var bmx = await _bmxRepository.GetBmxByIdAsync(guid);
        var bmxDelete = await _bmxRepository.DeleteBmx(bmx);
        var bmxModel = new BmxResponseModel()
        {
            Brand = bmxDelete.Brand,
            Id = bmxDelete.Id,
            Price = bmxDelete.Price
        };
        return bmxModel;
    }
}