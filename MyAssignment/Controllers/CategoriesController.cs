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
    }
}
