using System;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
namespace WEB_253502_BARANOVSKY.Services.CategoryService;

public interface ITourCategoryService
{
    public Task<ResponseData<List<TourCategory>>> GetCategoryListAsync();
}
