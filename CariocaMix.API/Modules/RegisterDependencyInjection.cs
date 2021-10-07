﻿using CariocaMix.CrossCutting.Interfaces;
using CariocaMix.CrossCutting.Services;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Domain.Interfaces.Services;
using CariocaMix.Repository.Persistence;
using CariocaMix.Repository.Persistence.Repositories;
using CariocaMix.Service.Services;
using CariocaMix.Utils.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CariocaMix.API.Modules
{
    public static class RegisterDependencyInjection
    {
        public static void ConfigurationDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IServiceUser, ServiceUser>();
            services.AddTransient<IServiceItem, ServiceItem>();
            services.AddTransient<IServiceAdmin, ServiceAdmin>();
            services.AddTransient<IServiceOrder, ServiceOrder>();
            services.AddTransient<IServiceStore, ServiceStore>();
            services.AddTransient<IServiceCoupon, ServiceCoupon>();
            services.AddTransient<IServiceProduct, ServiceProduct>();
            services.AddTransient<IServiceAddress, ServiceAddress>();
            services.AddTransient<IServiceCategory, ServiceCategory>();
            services.AddTransient<IServiceUserCoupon, ServiceUserCoupon>();
            services.AddTransient<IServiceProductItem, ServiceProductItem>();
            services.AddTransient<IServicePaymentType, ServicePaymentType>();
            services.AddTransient<IServiceDeliveryTax, ServiceDeliveryTax>();
            services.AddTransient<IServiceOrderProduct, ServiceOrderProduct>();
            services.AddTransient<IServiceAddressStore, ServiceAddressStore>();
            services.AddTransient<IServiceStoreDayHour, ServiceStoreDayHour>();
            services.AddTransient<IServicePaymentStatus, ServicePaymentStatus>();
            services.AddTransient<IServiceDeliveryStatus, ServiceDeliveryStatus>();
            services.AddTransient<IServiceCategoryProduct, ServiceCategoryProduct>();
            services.AddTransient<IServiceOrderProductItem, ServiceOrderProductItem>();

            services.AddTransient<IRepositoryUser, RepositoryUser>();
            services.AddTransient<IRepositoryItem, RepositoryItem>();
            services.AddTransient<IRepositoryAdmin, RepositoryAdmin>();
            services.AddTransient<IRepositoryOrder, RepositoryOrder>();
            services.AddTransient<IRepositoryStore, RepositoryStore>();
            services.AddTransient<IRepositoryCoupon, RepositoryCoupon>();
            services.AddTransient<IRepositoryProduct, RepositoryProduct>();
            services.AddTransient<IRepositoryAddress, RepositoryAddress>();
            services.AddTransient<IRepositoryCategory, RepositoryCategory>();
            services.AddTransient<IRepositoryUserCoupon, RepositoryUserCoupon>();
            services.AddTransient<IRepositoryProductItem, RepositoryProductItem>();
            services.AddTransient<IRepositoryPaymentType, RepositoryPaymentType>();
            services.AddTransient<IRepositoryDeliveryTax, RepositoryDeliveryTax>();
            services.AddTransient<IRepositoryOrderProduct, RepositoryOrderProduct>();
            services.AddTransient<IRepositoryAddressStore, RepositoryAddressStore>();
            services.AddTransient<IRepositoryStoreDayHour, RepositoryStoreDayHour>();
            services.AddTransient<IRepositoryPaymentStatus, RepositoryPaymentStatus>();
            services.AddTransient<IRepositoryDeliveryStatus, RepositoryDeliveryStatus>();
            services.AddTransient<IRepositoryCategoryProduct, RepositoryCategoryProduct>();
            services.AddTransient<IRepositoryOrderProductItem, RepositoryOrderProductItem>();

            services.AddSingleton(_ => configuration);
            services.AddTransient<ISendEmail, SendEmail>();
            services.AddScoped<IConfigurationHelper, ConfigurationHelper>();
            services.AddDbContext<Context>();
        }
    }
}