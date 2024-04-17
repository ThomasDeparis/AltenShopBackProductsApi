using AltenShopBackProductsApi.Data;
using AltenShopBackProductsApi.Entities;
using AltenShopBackProductsApi.Factories;
using AltenShopBackProductsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltenShopBackProductsApi.Services
{
    public interface IProductService
    {
        Task<Product> AddNewProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task RemoveProduct(int id);
        Task UpdateProduct(int id, ProductUpdate changes);
    }

    public class ProductService : IProductService
    {
        private ProductFactory _factory;

        public ProductService(DataContext dbContext) 
        {
            _factory = new ProductFactory(dbContext);
        }

        public Task<Product> AddNewProduct(Product product)
        {
            return _factory.Create(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _factory.GetAll();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _factory.GetById(id);
        }

        public async Task UpdateProduct(int id, ProductUpdate changes)
        {
            var toUpdate = await _factory.GetById(id);

            if (toUpdate == null)
            {
                throw new System.ArgumentException("Update product : product cannot be found");
            }
            toUpdate.Edit(changes);
            await _factory.Update(toUpdate);
        }

        public async Task RemoveProduct(int id)
        {
            // Remarque : plus judicieux d'ajouter un champ "deleted" au modèle Product, et conserver les données
            var toRemove = await _factory.GetById(id);

            if(toRemove == null)
            {
                throw new System.ArgumentException("Remove product : product cannot be found");
            }
            await _factory.Delete(toRemove);
        }
    }
}
