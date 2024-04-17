using AltenShopBackProductsApi.Data;
using AltenShopBackProductsApi.Entities;
using AltenShopBackProductsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltenShopBackProductsApi.Factories
{
    internal class ProductFactory : IFactory<Product>
    {
        private readonly DataContext _dataContext;
        public ProductFactory(DataContext dbContext)
        {
            _dataContext = dbContext;
        }

        public async Task<Product> Create(Product newProduct)
        {
            var result = _dataContext.Products.Add(newProduct);
            await _dataContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dataContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Product changes)
        {
            _dataContext.Products.Update(changes);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(Product toRemove)
        {
            _dataContext.Products.Remove(toRemove);
            await _dataContext.SaveChangesAsync();
        }
    }
}
