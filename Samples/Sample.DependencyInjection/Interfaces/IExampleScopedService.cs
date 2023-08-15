using Microsoft.Extensions.DependencyInjection;

namespace Sample.DependencyInjection.Interfaces
{
    internal interface IExampleScopedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}
