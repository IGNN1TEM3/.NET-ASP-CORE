using System;
using Microsoft.EntityFrameworkCore;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;

namespace WEB_253502_BARANOVSKY.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    DbSet<Tour> Tours {get; set;}
    DbSet<TourCategory> tourCategories {get; set;}
}
