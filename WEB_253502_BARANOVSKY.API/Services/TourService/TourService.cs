using System;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
using WEB_253502_BARANOVSKY.API.Data;
using Microsoft.EntityFrameworkCore;
namespace WEB_253502_BARANOVSKY.API.Services.TourService;

public class TourService : ITourService
{
    private readonly AppDbContext _context;
        private readonly int _maxPageSize = 20;

        public TourService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseData<ListModel<Tour>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1, int pageSize = 3)
        {
            // Ограничение на размер страницы
            pageSize = pageSize > _maxPageSize ? _maxPageSize : pageSize;

            var query = _context.Tours.AsQueryable();
            var dataList = new ListModel<Tour>();

            // Фильтрация по категории
            if (!string.IsNullOrEmpty(categoryNormalizedName))
            {
                query = query.Where(t=> categoryNormalizedName == null
                    ||
                    t.Category.NormalizedName == categoryNormalizedName);
            }

            var totalItems = await query.CountAsync();
            if(totalItems==0)
            {
                return ResponseData<ListModel<Tour>>.Success(dataList);
            }

            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            if (pageNo > totalPages)
                return ResponseData<ListModel<Tour>>.Error("No such page");

            dataList.Items = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            dataList.TotalPages = totalPages;
            dataList.CurrentPage = pageNo;

            return ResponseData<ListModel<Tour>>.Success(dataList);
        }

        public async Task<ResponseData<Tour>> GetProductByIdAsync(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return ResponseData<Tour>.Error("Tour not found.");
            }

            return ResponseData<Tour>.Success(tour);
        }

        public async Task UpdateProductAsync(int id, Tour product, IFormFile? formFile)
        {
            if (id != product.Id)
            {
                throw new ArgumentException("Product ID mismatch.");
            }

            _context.Entry(product).State = EntityState.Modified;

            if (formFile != null)
            {
                await SaveImageAsync(id, formFile);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ResponseData<Tour>> CreateProductAsync(Tour product, IFormFile? formFile)
        {
            _context.Tours.Add(product);
            await _context.SaveChangesAsync();

            if (formFile != null)
            {
                await SaveImageAsync(product.Id, formFile);
            }

            return ResponseData<Tour>.Success(product);
        }

        public async Task<ResponseData<string>> SaveImageAsync(int id, IFormFile formFile)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return ResponseData<string>.Error("Tour not found.");
            }

            var uploadsFolder = Path.Combine("wwwroot", "Images");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"tourism-{id}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            tour.ImagePath = $"https://localhost:7002/Images/{fileName}";
            await _context.SaveChangesAsync();

            return ResponseData<string>.Success(tour.ImagePath);
        }

}
