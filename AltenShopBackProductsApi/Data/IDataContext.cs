using AltenShopBackProductsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AltenShopBackProductsApi.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
    }
}
