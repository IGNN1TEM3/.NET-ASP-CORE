using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_253502_BARANOVSKY.API.Data;
using WEB_253502_BARANOVSKY.DOMAIN.Entities;
using WEB_253502_BARANOVSKY.API.Services.TourService;
using WEB_253502_BARANOVSKY.DOMAIN.Models;
using System.ComponentModel;

namespace WEB_253502_BARANOVSKY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITourService _tourService;

        public ToursController(AppDbContext context, ITourService tourService)
        {
            _context = context;
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Tour>>>> GetAllTours(string? category, int pageNo = 1, int pageSize = 3)
        {
            var result = await _tourService.GetProductListAsync(category, pageNo, pageSize);
            if (!result.Successfull)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }

        // GET: api/Tours/{categoryNormalizedName}
        [HttpGet("{categoryNormalizedName}")]
        public async Task<ActionResult<ResponseData<List<Tour>>>> GetTours(string? categoryNormalizedName, int pageNo=1, int pageSize=3)
        {
            var result = await _tourService.GetProductListAsync(categoryNormalizedName,pageNo,pageSize);
            if (!result.Successfull)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }

        // GET: api/Tours/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseData<Tour>>> GetTour(int id)
        {
            var result = await _tourService.GetProductByIdAsync(id);

            if (!result.Successfull)
            {
                return NotFound(result.ErrorMessage);
            }

            return Ok(result);
        }

        // PUT: api/Tours/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, Tour tour)
        {
            if (id != tour.Id)
            {
                return BadRequest("ID in the URL and body do not match.");
            }

            try
            {
                await _tourService.UpdateProductAsync(id, tour, null);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TourExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Tours
        [HttpPost]
        public async Task<ActionResult<ResponseData<Tour>>> PostTour(Tour tour)
        {
            var result = await _tourService.CreateProductAsync(tour, null);

            if (!result.Successfull)
            {
                return BadRequest(result.ErrorMessage);
            }

            return CreatedAtAction("GetTour", new { id = result.Data?.Id }, result.Data);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            try
            {
                await _tourService.DeleteProductAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        private async Task<bool> TourExists(int id)
        {
            var result = await _tourService.GetProductByIdAsync(id);
            return result.Successfull;
        }
    }
}
