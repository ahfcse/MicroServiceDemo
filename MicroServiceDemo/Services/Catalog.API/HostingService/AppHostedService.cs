
using Catalog.API.Context;

namespace Catalog.API.HostingService
{
    public class AppHostedService : IHostedService
    {
        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            CatalogDbContextSeed.Seed();
           return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
