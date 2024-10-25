using System;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
using WEB_253502_BARANOVSKY.API.Data;
using Microsoft.EntityFrameworkCore;

namespace WEB_253502_BARANOVSKY.API.Services.CategoryService;

public class CategoryService : ITourCategoryService
{
     private readonly AppDbContext _context;
     public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseData<List<TourCategory>>> GetCategoryListAsync()
    {
        var responseData = new ResponseData<List<TourCategory>>();

        try
        {
            var categories = await _context.TourCategories.ToListAsync();
            return ResponseData<List<TourCategory>>.Success(categories);
        }
        catch (Exception ex)
        {
            return ResponseData<List<TourCategory>>.Error(ex.Message);
        }
    }
}
