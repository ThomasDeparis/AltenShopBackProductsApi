using AltenShopBackProductsApi.Entities;
using AltenShopBackProductsApi.Models;
using AltenShopBackProductsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AltenShopBackProductsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<IProduct>> GetAll()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<IProduct> Get(int id)
        {
            return await _productService.GetProduct(id);
        }

        [HttpPost]
        public async Task Create([FromBody] Product newProduct)
        {
            await _productService.AddNewProduct(newProduct);
        }

        [HttpPatch("{productId}")]
        public async Task Update(int productId, [FromBody] ProductUpdate productUpdate)
        {
            await _productService.UpdateProduct(productId, productUpdate);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _productService.RemoveProduct(id);
        }
    }
}
