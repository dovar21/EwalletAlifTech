using EwalletAlifTech.Modules.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EwalletAlifTech.Modules.Users.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUserServiceCollection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserRepository, UserRepository>();

            return serviceCollection;
        }
    }
}
