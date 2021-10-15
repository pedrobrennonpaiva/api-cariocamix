using CariocaMix.Domain.Models.CategoryProduct;
using CariocaMix.Domain.Models.ProductItem;
using System.Collections.Generic;

namespace CariocaMix.Domain.Models.Product
{
    public class ProductAddModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public long Points { get; set; }

        public bool IsOneItem { get; set; }

        public List<CategoryProductAddModel> CategoryProducts { get; set; }

        public List<ProductItemAddModel> ProductItems { get; set; }
    }
}
