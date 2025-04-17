using Microsoft.EntityFrameworkCore;
using MTKW_MyApi.DataAccess;

namespace MTKW_MyApi.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _context.CATEGORIES.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
