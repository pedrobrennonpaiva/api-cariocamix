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
        public virtual Category Category { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }
        //public virtual Product Product { get; set; }
    }
}
