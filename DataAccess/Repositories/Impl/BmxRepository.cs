using Core.Entities;
using DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Impl;

public class BmxRepository : IBmxRepository
{
    private readonly ApplicationDbContext _context;

    public BmxRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Bmx>> GetBmxAsync()
    {
        return await _context.Bmxs.ToListAsync();
    }

    public async Task<Bmx> GetBmxByIdAsync(Guid bmxId)
    {
        var bmxById = await _context.Bmxs.FirstOrDefaultAsync(x => x.Id == bmxId);
        return bmxById;
    }

    public async Task<Bmx> UpdateBmx(Bmx bmx)
    {
        var existingUser = await _context.Bmxs.FindAsync(bmx.Id);
        if (existingUser != null)
        {
            _context.Entry(existingUser).State = EntityState.Detached;
        }
        _context.Bmxs.Update(bmx);
        await _context.SaveChangesAsync();
        return bmx;
    }

    public async Task<Bmx> CreateBmx(Bmx bmx)
    {
        _context.Bmxs.Add(bmx);
        await _context.SaveChangesAsync();
        return bmx;
    }

    public async Task<Bmx> DeleteBmx(Bmx bmx)
    {
        _context.Bmxs.Remove(bmx);
        await _context.SaveChangesAsync();
        return bmx;
    }
}