using AutoMapper;
using MyAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Shared.Category;
using Microsoft.EntityFrameworkCore;
using MyAssignment.Models;

namespace MyAssignment.Respositories.CategoryRespo
{
    public class CategoryRespository : ICateRespo
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CategoryRespository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<CategoryVM> GetCategoryById(int idCate)
        {
            var cate = await _context.Categories
                .Include(p => p.Products)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.IDCate.Equals(idCate));

            var result = _mapper.Map<CategoryVM>(cate);
            return result;
        }
        public async Task<IEnumerable<CategoryVM>> GetCategories()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<CategoryVM>>(categories);

            return result;
        }

        public async Task<CategoryVM> Create(CategoryCreateRequest categoryRequest)
        {
            
            var newCategory = _mapper.Map<Category>(categoryRequest);

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            var category = _mapper.Map<CategoryVM>(newCategory);

            return category;
        }

        public async Task<CategoryVM> Update(int categoryId, CategoryCreateRequest categoryRequest)
        {
            var existCategory = await _context.Categories.FindAsync(categoryId);
            if(existCategory is null)
            {
                return null;
            }

            _context.Entry<Category>(existCategory).CurrentValues.SetValues(categoryRequest);
            await _context.SaveChangesAsync();

            var updatedCategory = _mapper.Map<CategoryVM>(existCategory);

            return updatedCategory;
        }

        public async Task<CategoryVM> Delete(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category is null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            var categoryRespone = _mapper.Map<CategoryVM>(category);
            return categoryRespone;
        }

    }
}
