using EgeBilgiBilisimTask.Entities;
using EgeBilgiBilisimTask.Service.Repositories;

namespace EgeBilgiBilisimTask.Service.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> KategoriyiUrunleriyleGetir(int categoryId);
    }
}
