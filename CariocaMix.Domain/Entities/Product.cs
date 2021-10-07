using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Product")]
    public class Product : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public long Points { get; set; }

        public bool IsOneItem { get; set; }
    }
}
