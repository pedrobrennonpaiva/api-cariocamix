using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("CategoryProduct")]
    public class CategoryProduct: BaseModel
    {
        [ForeignKey("Category")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
