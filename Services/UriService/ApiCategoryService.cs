using System;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
namespace WEB_253502_BARANOVSKY.Services.UriService;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using WEB_253502_BARANOVSKY.API.Services.CategoryService;

public class ApiCategoryService : ITourCategoryService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;

    public ApiCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<ResponseData<List<TourCategory>>> GetCategoryListAsync()
    {
        var response = await _httpClient.GetAsync("categories");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ResponseData<List<TourCategory>>>(_serializerOptions)
                   ?? ResponseData<List<TourCategory>>.Error("Failed to parse response.");
        }

        return ResponseData<List<TourCategory>>.Error($"Error: {response.ReasonPhrase}");
    }
}
