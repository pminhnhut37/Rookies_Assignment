using AutoMapper;
using MyAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Shared.Category;
using Microsoft.EntityFrameworkCore;

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
                .Include(p => p.Products)
                .AsNoTracking()
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<CategoryVM>>(categories);

            return result;
        }



    }
}
