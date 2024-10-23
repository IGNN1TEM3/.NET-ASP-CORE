using System;
using WEB_253502_BARANOVSKY.Services.TourService;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
using WEB_253502_BARANOVSKY.Services.CategoryService;
namespace WEB_253502_BARANOVSKY.Services.TourService;

public class MemoryTourService : ITourService
{
    List<Tour> _tours;
    List<TourCategory> _categories;
    private readonly int _itemsPerPage;
    public MemoryTourService(IConfiguration config,ITourCategoryService categoryService)
    {
        _categories=categoryService.GetCategoryListAsync().Result.Data;
        _itemsPerPage = config.GetValue<int>("ItemsPerPage");
        SetupData();
    }
    private void SetupData()
{
    _tours = new List<Tour>
    {
        new Tour
        {
            Id = 1,
            Name = "Приключенческий тур в горы",
            Description = "Увлекательное путешествие по горам с восхождением на вершину.",
            Price = 1500,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "adventures")?.Id ?? 0,
            ImagePath = "Images/tourism-1.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 2,
            Name = "Отдых на пляже",
            Description = "Расслабляющий отдых на берегу моря с комфортными условиями.",
            Price = 1200,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "beach-holidays")?.Id ?? 0,
            ImagePath = "Images/tourism-2.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 3,
            Name = "Экскурсия по достопримечательностям",
            Description = "Исследуйте местные достопримечательности.",
            Price = 1800,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "excursions")?.Id ?? 0, // Измените на существующую категорию
            ImagePath = "Images/tourism-3.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 4,
            Name = "Романтический отдых на Мальдивах",
            Description = "Идеальный пляжный отдых для двоих на тропических островах Мальдив.",
            Price = 4000,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "beach-holidays")?.Id ?? 0,
            ImagePath = "Images/tourism-4.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 5,
            Name = "Круиз по Норвежским фьордам",
            Description = "Путешествие по фьордам с потрясающими видами и захватывающими остановками.",
            Price = 3700,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "cruises")?.Id ?? 0,
            ImagePath = "Images/tourism-5.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 6,
            Name = "Экотуризм в джунглях Амазонии",
            Description = "Окунитесь в природу, исследуя джунгли и уникальные экосистемы Амазонии.",
            Price = 3200,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "ecotourism")?.Id ?? 0,
            ImagePath = "Images/tourism-6.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 7,
            Name = "Приключенческий сафари-тур в Африке",
            Description = "Насладитесь дикой природой Африки в приключенческом сафари-туре.",
            Price = 3500,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "adventures")?.Id ?? 0,
            ImagePath = "Images/tourism-7.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {   
            Id = 8,
            Name = "Горнолыжный курорт в Альпах",
            Description = "Насладитесь катанием на лыжах и сноуборде на лучших трассах Европы.",
            Price = 2500,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "ski-resorts")?.Id ?? 0,
            ImagePath = "Images/tourism-8.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 9,
            Name = "Круиз по Карибскому морю",
            Description = "Роскошный круиз с посещением лучших островов Карибского моря.",
            Price = 3000,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "cruises")?.Id ?? 0,
            ImagePath = "Images/tourism-9.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 10,
            Name = "Экскурсия по историческим местам Европы",
            Description = "Посетите знаковые культурные и исторические достопримечательности Европы.",
            Price = 2200,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "excursions")?.Id ?? 0,
            ImagePath = "Images/tourism-10.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 11,
            Name = "Экскурсия по историческим местам Азии",
            Description = "Посетите знаковые культурные и исторические достопримечательности Азии.",
            Price = 2500,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "excursions")?.Id ?? 0,
            ImagePath = "Images/tourism-5.jpg",
            MimeString = "image/jpeg"
        },
        new Tour
        {
            Id = 12,
            Name = "Экскурсия по историческим местам Африки",
            Description = "Посетите знаковые культурные и исторические достопримечательности Африки.",
            Price = 100,
            CategoryId = _categories.FirstOrDefault(c => c.NormalizedName == "excursions")?.Id ?? 0,
            ImagePath = "Images/tourism-7.jpg",
            MimeString = "image/jpeg"
        }
    };
}
    public async Task<ResponseData<ListModel<Tour>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
{
    // Получаем ID категории или 0, если категория не найдена
    var categoryId = string.IsNullOrEmpty(categoryNormalizedName)
        ? 0
        : _categories.FirstOrDefault(c => c.NormalizedName == categoryNormalizedName)?.Id ?? 0;

    // Фильтруем туры по найденному categoryId
    var filteredTours = categoryId == 0 ? _tours : _tours.Where(t => t.CategoryId == categoryId);

    var totalTours = filteredTours.Count();
    var totalPages = (int)Math.Ceiling(totalTours / (double)_itemsPerPage);

    var productsToReturn = filteredTours.Skip((pageNo - 1) * _itemsPerPage).Take(_itemsPerPage).ToList();

    return await Task.FromResult(ResponseData<ListModel<Tour>>.Success(new ListModel<Tour>
    {
        Items = productsToReturn,
        CurrentPage = pageNo,
        TotalPages = totalPages
    }));
}


    public async Task<ResponseData<Tour>> GetProductByIdAsync(int id)
    {
        var tour = _tours.FirstOrDefault(t => t.Id == id);
        return tour != null
            ? ResponseData<Tour>.Success(tour)
            : ResponseData<Tour>.Error("Тур не найден.");
    }

    public async Task UpdateProductAsync(int id, Tour product, IFormFile? formFile)
    {
        var existingTour = _tours.FirstOrDefault(t => t.Id == id);
        if (existingTour != null)
        {
            existingTour.Name = product.Name;
            existingTour.Description = product.Description;
            existingTour.Price = product.Price;
            existingTour.CategoryId = product.CategoryId;

            if (formFile != null)
            {
                existingTour.ImagePath = $"images/{formFile.FileName}"; 
                existingTour.MimeString = formFile.ContentType;
            }
        }

        await Task.CompletedTask;
    }

    public async Task DeleteProductAsync(int id)
    {
        var tour = _tours.FirstOrDefault(t => t.Id == id);
        if (tour != null)
        {
            _tours.Remove(tour);
        }

        await Task.CompletedTask;
    }

    public async Task<ResponseData<Tour>> CreateProductAsync(Tour product, IFormFile? formFile)
    {
        product.Id = _tours.Max(t => t.Id) + 1;
        if (formFile != null)
        {
            product.ImagePath = $"images/{formFile.FileName}"; 
            product.MimeString = formFile.ContentType;
        }

        _tours.Add(product);

        return await Task.FromResult(ResponseData<Tour>.Success(product));
    }
}
