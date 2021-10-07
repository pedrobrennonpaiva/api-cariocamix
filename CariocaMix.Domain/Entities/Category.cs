using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Category")]
    public class Category : BaseModel
    {
        public string Title { get; set; }
    }
}
