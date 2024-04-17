using AltenShopBackProductsApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AltenShopBackProductsApi.Models
{
    public class ProductUpdate
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public float? Quantity { get; set; }
        public float? Price { get; set; }
        public InventoryStatus? InventoryStatus { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }
        public float? Rating { get; set; }
    }
}
