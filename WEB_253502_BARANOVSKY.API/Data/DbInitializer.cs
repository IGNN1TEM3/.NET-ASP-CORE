using System;
using WEB_253502_BARANOVSKY.API.Data;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace WEB_253502_BARANOVSKY.API.Data;

public class DbInitializer
{
    public static async Task SeedData(WebApplication app)
    {
        Console.WriteLine("Начинается инициализация данных...");

        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
        var baseUrl = app.Configuration["AppSettings:BaseUrl"];

        if (!context.Tours.Any() && !context.TourCategories.Any())
        {
            var tourCategories = new List<TourCategory>
            {
                new TourCategory { Id = 1, Name = "Приключения", NormalizedName = "adventures" },
                new TourCategory { Id = 2, Name = "Пляжный отдых", NormalizedName = "beach-holidays" },
                new TourCategory { Id = 3, Name = "Экскурсии", NormalizedName = "excursions" },
                new TourCategory { Id = 4, Name = "Горнолыжные курорты", NormalizedName = "ski-resorts" },
                new TourCategory { Id = 5, Name = "Круизы", NormalizedName = "cruises" },
                new TourCategory { Id = 6, Name = "Семейные туры", NormalizedName = "family-tours" },
                new TourCategory { Id = 7, Name = "Экотуризм", NormalizedName = "ecotourism" }
            };
            await context.TourCategories.AddRangeAsync(tourCategories);
            var tours = new List<Tour>
            {
                 new Tour
                {
                    Name = "Приключенческий тур в горы",
                    Description = "Увлекательное путешествие по горам с восхождением на вершину.",
                    Price = 1500,
                    CategoryId = 1,
                    ImagePath = $"{baseUrl}/Images/tourism-1.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Отдых на пляже",
                    Description = "Расслабляющий отдых на берегу моря с комфортными условиями.",
                    Price = 1200,
                    CategoryId = 2,
                    ImagePath = $"{baseUrl}/Images/tourism-2.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Экскурсия по достопримечательностям",
                    Description = "Исследуйте местные достопримечательности.",
                    Price = 1800,
                    CategoryId = 3,
                    ImagePath = $"{baseUrl}/Images/tourism-3.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Романтический отдых на Мальдивах",
                    Description = "Идеальный пляжный отдых для двоих на тропических островах Мальдив.",
                    Price = 4000,
                    CategoryId = 2,
                    ImagePath = $"{baseUrl}/Images/tourism-4.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Круиз по Норвежским фьордам",
                    Description = "Путешествие по фьордам с потрясающими видами и захватывающими остановками.",
                    Price = 3700,
                    CategoryId = 5,
                    ImagePath = $"{baseUrl}/Images/tourism-5.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Экотуризм в джунглях Амазонии",
                    Description = "Окунитесь в природу, исследуя джунгли и уникальные экосистемы Амазонии.",
                    Price = 3200,
                    CategoryId = 7,
                    ImagePath = $"{baseUrl}/Images/tourism-6.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Приключенческий сафари-тур в Африке",
                    Description = "Насладитесь дикой природой Африки в приключенческом сафари-туре.",
                    Price = 3500,
                    CategoryId = 1,
                    ImagePath = $"{baseUrl}/Images/tourism-7.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {   
                    Name = "Горнолыжный курорт в Альпах",
                    Description = "Насладитесь катанием на лыжах и сноуборде на лучших трассах Европы.",
                    Price = 2500,
                    CategoryId = 4,
                    ImagePath = $"{baseUrl}/Images/tourism-8.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Круиз по Карибскому морю",
                    Description = "Роскошный круиз с посещением лучших островов Карибского моря.",
                    Price = 3000,
                    CategoryId = 5,
                    ImagePath = $"{baseUrl}/Images/tourism-9.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Экскурсия по историческим местам Европы",
                    Description = "Посетите знаковые культурные и исторические достопримечательности Европы.",
                    Price = 2200,
                    CategoryId = 3,
                    ImagePath = $"{baseUrl}/Images/tourism-10.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Экскурсия по историческим местам Азии",
                    Description = "Посетите знаковые культурные и исторические достопримечательности Азии.",
                    Price = 2500,
                    CategoryId = 3,
                    ImagePath = $"{baseUrl}/Images/tourism-5.jpg",
                    MimeString = "image/jpeg"
                },
                new Tour
                {
                    Name = "Экскурсия по историческим местам Африки",
                    Description = "Посетите знаковые культурные и исторические достопримечательности Африки.",
                    Price = 100,
                    CategoryId = 3,
                    ImagePath = $"{baseUrl}/Images/tourism-7.jpg",
                    MimeString = "image/jpeg"
                }
            };
            await context.Tours.AddRangeAsync(tours);
            await context.SaveChangesAsync();
        }
    }
}
