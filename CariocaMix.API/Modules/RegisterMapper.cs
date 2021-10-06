using CariocaMix.Service.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace CariocaMix.API.Modules
{
    public static class RegisterMapper
    {
        public static void ConfigurationMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(ItemProfile));
            services.AddAutoMapper(typeof(AdminProfile));
            services.AddAutoMapper(typeof(OrderProfile));
            services.AddAutoMapper(typeof(StoreProfile));
            services.AddAutoMapper(typeof(CouponProfile));
            services.AddAutoMapper(typeof(AddressProfile));
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(CategoryProfile));
            services.AddAutoMapper(typeof(UserCouponProfile));
            services.AddAutoMapper(typeof(PaymentTypeProfile));
            services.AddAutoMapper(typeof(DeliveryTaxProfile));
            services.AddAutoMapper(typeof(ProductItemProfile));
            services.AddAutoMapper(typeof(AddressStoreProfile));
            services.AddAutoMapper(typeof(OrderProductProfile));
            services.AddAutoMapper(typeof(StoreDayHourProfile));
            services.AddAutoMapper(typeof(PaymentStatusProfile));
            services.AddAutoMapper(typeof(DeliveryStatusProfile));
            services.AddAutoMapper(typeof(CategoryProductProfile));
            services.AddAutoMapper(typeof(OrderProductItemProfile));
        }
    }
}
