using Microsoft.EntityFrameworkCore;
using EgeBilgiBilisimTask.Data;
using EgeBilgiBilisimTask.Entities;

namespace EgeBilgiBilisimTask.Service.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Category> GetCategoryByProduct(int categoryId)
        {
           return await _databaseContext.Categories.Include(c=>c.Products).FirstOrDefaultAsync(c=>c.Id== categoryId);
        }
    }
}
