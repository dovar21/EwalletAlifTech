using EwalletAlifTech.Modules.Accounts.Repositories;
using Microsoft.Extensions.DependencyInjection;
using EwalletAlifTech.Modules.Accounts.Services;

namespace EwalletAlifTech.Modules.Accounts.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddAccountServiceCollection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountRepository, AccountRepository>();
            serviceCollection.AddTransient<IAccountService, AccountService>();

            return serviceCollection;
        }
    }
}
