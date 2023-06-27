using Core.Entities;

namespace DataAccess.Repositories;

public interface IBmxRepository
{
    Task<List<Bmx>> GetBmxAsync();
    Task<Bmx> GetBmxByIdAsync(Guid bmxId);
    Task<Bmx> UpdateBmx(Bmx bmx);
    Task<Bmx> CreateBmx(Bmx bmx);
    Task<Bmx> DeleteBmx(Bmx bmx);

}