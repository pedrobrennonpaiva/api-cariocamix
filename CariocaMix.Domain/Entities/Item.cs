using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Item")]
    public class Item : BaseModel
    {
        public string Title { get; set; }

        public decimal Price { get; set; }
    }
}
