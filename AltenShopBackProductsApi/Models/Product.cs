using AltenShopBackProductsApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AltenShopBackProductsApi.Models
{
    public class Product : IProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public InventoryStatus InventoryStatus { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public float Rating { get; set; }

        public void Edit(ProductUpdate changes)
        {
            if (!string.IsNullOrEmpty(changes.Name))
            {
                this.Name = changes.Name;
            }

            if (!string.IsNullOrEmpty(changes.Description))
            {
                this.Description = changes.Description;
            }
            if (!string.IsNullOrEmpty(changes.Code))
            {
                this.Code = changes.Code;
            }

            this.Quantity = changes.Quantity ?? this.Quantity;
            this.Price = changes.Price ?? this.Price;
            this.InventoryStatus = changes.InventoryStatus ?? this.InventoryStatus;
            this.Rating = changes.Rating ?? this.Rating;

            if (!string.IsNullOrEmpty(changes.Category))
            {
                this.Category = changes.Category;
            }

            if (!string.IsNullOrEmpty(changes.Image))
            {
                this.Image = changes.Image;
            }
        }
    }
}
