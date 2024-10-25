using WEB_253502_BARANOVSKY.API.Services.CategoryService;
using WEB_253502_BARANOVSKY.API.Services.TourService;
using WEB_253502_BARANOVSKY.Extensions;
using WEB_253502_BARANOVSKY.Services.UriService;
using WEB_253502_BARANOVSKY.Uri;

namespace WEB_253502_BARANOVSKY{
    public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.RegisterCustomServices();

        var uriData = builder.Configuration.GetSection("UriData").Get<UriData>();

        builder.Services.AddHttpClient<ITourService, ApiTourService>(opt => opt.BaseAddress = new System.Uri(uriData.ApiUri));
        builder.Services.AddHttpClient<ITourCategoryService, ApiCategoryService>(opt => opt.BaseAddress = new System.Uri(uriData.ApiUri));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

}
