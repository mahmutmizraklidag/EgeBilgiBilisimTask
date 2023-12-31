﻿using Microsoft.EntityFrameworkCore;
using EgeBilgiBilisimTask.Data;
using EgeBilgiBilisimTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBilgiBilisimTask.Service.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAndBrand()
        {
            return await _databaseContext.Products.Include(c => c.Brand).Include(c => c.Category).ToListAsync();
        }

        public async Task<Product> GetProductByCategoryAndBrand(int productId)
        {
            return await _databaseContext.Products.Include(c => c.Brand).Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == productId);
        }
    }
}
