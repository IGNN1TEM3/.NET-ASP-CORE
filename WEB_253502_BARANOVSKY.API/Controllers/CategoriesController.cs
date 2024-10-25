using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_253502_BARANOVSKY.API.Data;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using WEB_253502_BARANOVSKY.API.Services.CategoryService;
using WEB_253502_BARANOVSKY.DOMAIN.Models;

namespace WEB_253502_BARANOVSKY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ITourCategoryService _categoryService;

        public CategoriesController(ITourCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<TourCategory>>>> GetTourCategories()
        {
            var result = await _categoryService.GetCategoryListAsync();

            if (!result.Successfull)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }
    }
}
