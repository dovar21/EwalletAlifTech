using EwalletAlifTech.Modules.Settings.Repositories;
using EwalletAlifTech.Modules.Settings.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EwalletAlifTech.Modules.Settings.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSettingServiceCollection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISettingRepository, SettingRepository>();
            serviceCollection.AddTransient<ISettingService,SettingService>();
            
            return serviceCollection;
        }
    }
}
