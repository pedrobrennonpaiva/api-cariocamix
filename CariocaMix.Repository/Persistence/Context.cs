using CariocaMix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CariocaMix.Repository.Persistence
{
    public class Context : DbContext
    {
        private readonly IConfiguration _config;

        public Context(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetConnectionString("Homolog");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressStore> AddressStores { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public virtual DbSet<DeliveryTax> DeliveryTaxes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<OrderProductItem> OrderProductItems { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreDayHour> StoreDayHours { get; set; }
        public virtual DbSet<User> Users { get; set; }   
        public virtual DbSet<UserCoupon> UserCoupons { get; set; }
    }
}
