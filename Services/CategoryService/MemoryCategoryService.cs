using System;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
namespace WEB_253502_BARANOVSKY.Services.CategoryService;

public class MemoryCategoryService : ITourCategoryService
{
    public Task<ResponseData<List<TourCategory>>> GetCategoryListAsync()
    {
        var categories = new List<TourCategory>
        {
            new TourCategory { Id = 1, Name = "Приключения", NormalizedName = "adventures" },
            new TourCategory { Id = 2, Name = "Пляжный отдых", NormalizedName = "beach-holidays" },
            new TourCategory { Id = 3, Name = "Экскурсии", NormalizedName = "excursions" },
            new TourCategory { Id = 4, Name = "Горнолыжные курорты", NormalizedName = "ski-resorts" },
            new TourCategory { Id = 5, Name = "Круизы", NormalizedName = "cruises" },
            new TourCategory { Id = 6, Name = "Семейные туры", NormalizedName = "family-tours" },
            new TourCategory { Id = 7, Name = "Экотуризм", NormalizedName = "ecotourism" }
        };
        var result = ResponseData<List<TourCategory>>.Success(categories);
        return Task.FromResult(result);
    }
}



