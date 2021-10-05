using CariocaMix.CrossCutting.Interfaces;
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
            services.AddSingleton(_ => configuration);
            services.AddTransient<IServiceUser, ServiceUser>();
            services.AddTransient<IServiceAdmin, ServiceAdmin>();
            services.AddTransient<IRepositoryUser, RepositoryUser>();
            services.AddTransient<IRepositoryAdmin, RepositoryAdmin>();
            services.AddTransient<ISendEmail, SendEmail>();
            services.AddScoped<IConfigurationHelper, ConfigurationHelper>();
            services.AddDbContext<Context>();
        }
    }
}
