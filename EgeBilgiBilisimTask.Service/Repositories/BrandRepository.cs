using Microsoft.EntityFrameworkCore;
using EgeBilgiBilisimTask.Data;
using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;

namespace EgeBilgiBilisimTask.Service.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Brand> GetBrandByProduct(int brandId)
        {
            return await _databaseContext.Brands.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == brandId);
        }
    }
}
