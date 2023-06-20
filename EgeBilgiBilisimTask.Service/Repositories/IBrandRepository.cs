using EgeBilgiBilisimTask.Entities;

namespace EgeBilgiBilisimTask.Service.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<Brand> GetBrandByProduct(int brandId);
    }
}
