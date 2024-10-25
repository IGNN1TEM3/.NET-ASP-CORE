using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace WEB_253502_BARANOVSKY.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Tour> Tours {get; set;}
    public DbSet<TourCategory> TourCategories {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tour>()
                .HasOne(t => t.Category) 
                .WithMany(c => c.Tours)
                .HasForeignKey(t => t.CategoryId);
    }
}
