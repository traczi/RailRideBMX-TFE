using Application.Models.Bmx;

namespace Application.Services;

public interface IBmxService
{
    Task<IEnumerable<BmxResponseModel>> GetAllBmxAsync();
    Task<BmxResponseModel> CreateBmxAsync(BmxResponseModel bmxResponseModel);
    Task<BmxResponseModel> GetBmxByIdAsync(Guid guid);
    Task<BmxResponseModel> DeleteBmx(Guid guid);
    Task<BmxResponseModel> UpdateBmx(Guid guid,  BmxResponseModel bmxResponseModel);
}