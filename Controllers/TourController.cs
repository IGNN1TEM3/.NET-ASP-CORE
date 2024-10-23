using Microsoft.AspNetCore.Mvc;
using WEB_253502_BARANOVSKY.Services.CategoryService;
using WEB_253502_BARANOVSKY.Services.TourService;

namespace WEB_253502_BARANOVSKY.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourCategoryService _categoryService;
        private readonly ITourService _tourService;
        public TourController(ITourService tourService, ITourCategoryService categoryService)
        {
            _tourService = tourService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(string? categoryNormalizedName = null, int pageNo = 1)
        {   
            var productResponse = await _tourService.GetProductListAsync(categoryNormalizedName, pageNo);

            if (!productResponse.Successfull)
            {
                return NotFound(productResponse.ErrorMessage);
            }

            var categoriesResponse = await _categoryService.GetCategoryListAsync();

            if (!categoriesResponse.Successfull)
            {
                return NotFound(categoriesResponse.ErrorMessage);
            }

            var categories = categoriesResponse.Data;
            ViewBag.Categories = categories;

            var currentCategory = categories.FirstOrDefault(c => c.NormalizedName == categoryNormalizedName);
            ViewBag.CurrentCategory = categoryNormalizedName;
            ViewBag.CurrentCategoryName = currentCategory?.Name;
            return View(productResponse.Data);
        }
    }
}
