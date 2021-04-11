using Assignment.Shared.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAssignment.Respositories.CategoryRespo
{
    public interface ICateRespo
    {
        Task<CategoryVM> GetCategoryById(int idCate);

        Task<IEnumerable<CategoryVM>> GetCategories();
    }
}
