using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("StoreDayHour")]
    public class StoreDayHour : BaseModel
    {
        [ForeignKey("Store")]
        public long StoreId { get; set; }
        public Store Store { get; set; }

        public int DayOfWeek { get; set; }

        public string HourOpen { get; set; }

        public string HourClose { get; set; }

        public bool IsDayBefore { get; set; }
    }
}
