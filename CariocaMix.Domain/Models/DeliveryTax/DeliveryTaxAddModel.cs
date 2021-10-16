namespace CariocaMix.Domain.Models.DeliveryTax
{
    public class DeliveryTaxAddModel
    {
        public long StoreId { get; set; }

        public decimal Radius { get; set; }

        public decimal Price { get; set; }
    }
}
