using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAssignment.Data;
using MyAssignment.Models;
using MyAssignment.Respositories.CategoryRespo;
using Assignment.Shared.Category;

namespace MyAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private ICateRespo _cateRespo;

        public CategoriesController(ICateRespo cateRespo)
        {
            _cateRespo = cateRespo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryVM>> GetCategoryById(int id)
        {
            var result = await _cateRespo.GetCategoryById(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryVM>>> GetCategories()
        {
            var result = await _cateRespo.GetCategories();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryVM>> Create([FromForm] CategoryCreateRequest caterequest)
        {
            var createdCategory = await _cateRespo.Create(caterequest);

            return Created("", createdCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryVM>> Delete(int id)
        {
            var categoryRespone = await _cateRespo.Delete(id);

            return Ok(categoryRespone);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryVM>> Update(int id, [FromForm] CategoryCreateRequest request)
        {
            var updatedCategory = await _cateRespo.Update(id, request);

            return Ok(updatedCategory);
        }
    }
}
