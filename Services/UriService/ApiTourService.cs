using System;
using System.Text;
using System.Text.Json;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using WEB_253502_BARANOVSKY.API.Services.TourService;
namespace WEB_253502_BARANOVSKY.Services.UriService;

public class ApiTourService : ITourService
{
    private readonly HttpClient _httpClient;
    private readonly string _pageSize;
    private readonly JsonSerializerOptions _serializerOptions;

    public ApiTourService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _pageSize = configuration.GetSection("ItemsPerPage").Value ?? "3";
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<ResponseData<ListModel<Tour>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1, int pageSize = 3)
    {
        var urlString = new StringBuilder($"{_httpClient.BaseAddress}tours");
        
        if (!string.IsNullOrEmpty(categoryNormalizedName))
        {
            urlString.Append($"/{categoryNormalizedName}");
        }

        urlString.Append($"?pageNo={pageNo}&pageSize={(pageSize > 0 ? pageSize : _pageSize)}");

        var response = await _httpClient.GetAsync(urlString.ToString());
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ResponseData<ListModel<Tour>>>(_serializerOptions)
                   ?? ResponseData<ListModel<Tour>>.Error("Failed to parse response.");
        }

        return ResponseData<ListModel<Tour>>.Error($"Error: {response.ReasonPhrase}");
    }

    public async Task<ResponseData<Tour>> GetProductByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"tours/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ResponseData<Tour>>(_serializerOptions)
                   ?? ResponseData<Tour>.Error("Failed to parse response.");
        }

        return ResponseData<Tour>.Error($"Error: {response.ReasonPhrase}");
    }

    public async Task UpdateProductAsync(int id, Tour product, IFormFile? formFile)
    {
        await _httpClient.PutAsJsonAsync($"tours/{id}", product, _serializerOptions);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _httpClient.DeleteAsync($"tours/{id}");
    }

    public async Task<ResponseData<Tour>> CreateProductAsync(Tour product, IFormFile? formFile)
    {
        var response = await _httpClient.PostAsJsonAsync("tours", product, _serializerOptions);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ResponseData<Tour>>(_serializerOptions)
                   ?? ResponseData<Tour>.Error("Failed to parse response.");
        }

        return ResponseData<Tour>.Error($"Error: {response.ReasonPhrase}");
    }

    public async Task<ResponseData<string>> SaveImageAsync(int id, IFormFile formFile)
    {
        // Example to implement image save functionality if required.
        return ResponseData<string>.Error("Image save functionality not implemented.");
    }
}