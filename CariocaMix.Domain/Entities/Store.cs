using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Store")]
    public class Store : BaseModel
    {
        public string Name { get; set; }
    }
}
