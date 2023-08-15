using Microsoft.Extensions.DependencyInjection;

namespace Sample.DependencyInjection.Interfaces
{
    internal interface IExampleSingletonService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}
