using CariocaMix.Domain.Entities.Base;
using CariocaMix.Domain.Models.CategoryProduct;
using CariocaMix.Domain.Models.ProductItem;
using System.Collections.Generic;

namespace CariocaMix.Domain.Models.Product
{
    public class ProductDetailsModel : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public long Points { get; set; }

        public bool IsOneItem { get; set; }

        public List<CategoryProductDetailsModel> CategoryProducts { get; set; }

        public List<ProductItemDetailsModel> ProductItems { get; set; }
    }
}
