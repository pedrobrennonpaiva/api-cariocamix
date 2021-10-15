using CariocaMix.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Store")]
    public class Store : BaseModel
    {
        public string Name { get; set; }

        public virtual List<StoreDayHour> StoreDayHours { get; set; }

        public virtual AddressStore AddressStore { get; set; }
    }
}
