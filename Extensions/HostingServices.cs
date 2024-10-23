using System;
using WEB_253502_BARANOVSKY.Services.CategoryService;
using WEB_253502_BARANOVSKY.Services.TourService;
namespace WEB_253502_BARANOVSKY.Extensions;

public static class HostingServices
{
    public static void RegisterCustomServices( this WebApplicationBuilder builder)
    {  
        builder.Services.AddScoped<ITourCategoryService, MemoryCategoryService>();
        builder.Services.AddScoped<ITourService, MemoryTourService>();
    }
}
