using System;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using WEB_253502_BARANOVSKY.DOMAIN.Models;

namespace WEB_253502_BARANOVSKY.API.Services.TourService;

public interface ITourService
{
    public Task<ResponseData<ListModel<Tour>>> GetProductListAsync(string? categoryNormalizedName, int pageNo=1, int pageSize=3);
    public Task<ResponseData<Tour>> GetProductByIdAsync(int id);
    public Task UpdateProductAsync(int id, Tour product, IFormFile? formFile);
    public Task DeleteProductAsync(int id);
    public Task<ResponseData<Tour>> CreateProductAsync(Tour product, IFormFile? formFile);
    public Task<ResponseData<string>> SaveImageAsync(int id, IFormFile formFile);
}
