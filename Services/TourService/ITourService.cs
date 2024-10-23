using System;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
namespace WEB_253502_BARANOVSKY.Services.TourService;

public interface ITourService
{
    public Task<ResponseData<ListModel<Tour>>> GetProductListAsync(string? categoryNormalizedName, int pageNo=1);
    public Task<ResponseData<Tour>> GetProductByIdAsync(int id);
    public Task UpdateProductAsync(int id, Tour product, IFormFile? formFile);
    public Task DeleteProductAsync(int id);
    public Task<ResponseData<Tour>> CreateProductAsync(Tour product, IFormFile? formFile);
}