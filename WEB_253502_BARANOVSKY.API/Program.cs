using WEB_253502_BARANOVSKY.API.Data;
using Microsoft.EntityFrameworkCore;
using WEB_253502_BARANOVSKY.API.Services.CategoryService;
using WEB_253502_BARANOVSKY.API.Services.TourService;

namespace WEB_253502_BARANOVSKY.API{
    public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        string connectionString = builder.Configuration.GetConnectionString("Default");

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
        builder.Services.AddControllers();
        builder.Services.AddScoped<ITourService, TourService>();
        builder.Services.AddScoped<ITourCategoryService, CategoryService>();

        var app = builder.Build();
        
        app.UseHttpsRedirection();  
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        await DbInitializer.SeedData(app);
        app.Run();
    }
}
}

