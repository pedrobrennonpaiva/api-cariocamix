using CariocaMix.CrossCutting.Interfaces;
using CariocaMix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CariocaMix.Repository.Persistence
{
    public class Context : DbContext
    {
        private readonly IConfigurationHelper _configurationHelper;

        public Context(IConfigurationHelper configurationHelper, DbContextOptions<Context> options) : base(options)
        {
            _configurationHelper = configurationHelper;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configurationHelper.GetString("ConnectionString");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressStore> AddressStores { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public virtual DbSet<DeliveryTax> DeliveryTaxes { get; set; }
        public virtual DbSet<DeliveryRemoveArea> DeliveryRemoveAreas { get; set; }
        public virtual DbSet<Image> Images { get; set; }
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
