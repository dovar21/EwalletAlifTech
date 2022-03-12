using EwalletAlifTech.Modules.Transactions.Repositories;
using EwalletAlifTech.Modules.Transactions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EwalletAlifTech.Modules.Transactions.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddTransactionServiceCollection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITransactionRepository,TransactionRepository>();
            serviceCollection.AddTransient<ITransactionService,TransactionService>();

            return serviceCollection;
        }
    }
}
