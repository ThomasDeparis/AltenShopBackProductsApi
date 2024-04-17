using AltenShopBackProductsApi.Entities;
using AltenShopBackProductsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltenShopBackProductsApi.Factories
{
    public interface IFactory<T>
    {
        Task<T> Create(T newT);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(T changes);
        Task Delete(T toRemove);

    }
}
