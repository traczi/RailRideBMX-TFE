using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Persistence;

public class ApplicationDbContext : DbContext
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Bmx> Bmxs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bmx>().HasKey(b => b.Id);
    }
}