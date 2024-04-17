using AltenShopBackProductsApi.Data;
using AltenShopBackProductsApi.Factories;
using AltenShopBackProductsApi.Models;
using AltenShopBackProductsApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AltenShopBackProductsApi.UnitTests
{
    [TestClass]
    public class ProductServiceTest
    {
        private readonly Mock<IFactory<Product>> productFactory;
        private readonly IProductService _productService;
        private readonly DbContextOptions<DataContext> dbOptions;

        private static DbSet<T> MockDbSet<T>(IEnumerable<T> list) where T : class, new()
        {
            IQueryable<T> queryableList = list.AsQueryable();
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
            return dbSetMock.Object;
        }

        public ProductServiceTest()
        {
            Product product = new Product()
            {
                Id = 1000,
                Code = "f230fh0g3",
                Name = "Bamboo Watch",
                Description = "Product Description",
                Image = "bamboo-watch.jpg",
                Price = 65,
                Category = "Accessories",
                Quantity = 24,
                InventoryStatus = Entities.InventoryStatus.INSTOCK,
                Rating = 5
            };

            Product product2 = new Product()
            {
                Id = 1001,
                Code = "nvklal433",
                Name = "Black Watch",
                Description = "Product Description",
                Image = "Black-watch.jpg",
                Price = 72,
                Category = "Accessories",
                Quantity = 61,
                InventoryStatus = Entities.InventoryStatus.INSTOCK,
                Rating = 4
            };

            // prepare using in memory DB
            dbOptions = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(databaseName: "Products DB")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new DataContext(dbOptions))
            {
                context.Products.Add(product);
                context.Products.Add(product2);
                context.SaveChanges();
            }

            // prepare using factory / dbset mock

            //var dbContextOptions = new Mock<DbContextOptions<DataContext>>();
            //dbContextOptions.Setup(o => o.ContextType).Returns(typeof(DataContext));

            //var dataContext = new Mock<DataContext>(dbContextOptions.Object);
            //dataContext.Setup(dc => dc.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            //var productsDbSet = MockDbSet<Product>(new List<Product> { product, product2 });                 <-- use these 2 lines
            //dataContext.Setup(dc => dc.Set<Product>()).Returns(productsDbSet);                               
            //dataContext.Setup(dc => dc.Products).ReturnsDbSet(new List<Product> { product, product2 });      <-- or this for dataContext.Products

            //productFactory = new Mock<IFactory<Product>>();
            //_productService = new ProductService(dataContext.Object);
        }

        [TestMethod]
        public async Task GetAllProductsTest_UsingInMemory()
        {
            using (var context = new DataContext(dbOptions))
            {
                var productService = new ProductService(context);
                var result = await productService.GetAllProducts();
                Assert.AreEqual(result.Count(), 2);
            }
        }

        //public async Task GetAllProductsTest_UsingDbSetMock()
        //{
        //    //productFactory.Setup(pf => pf.GetAll()).ReturnsAsync(new List<Product> { product, product2 });
        //    var result = await _productService.GetAllProducts();
        //    Assert.AreEqual(result.Count(), 2);
        //}
    }
}
