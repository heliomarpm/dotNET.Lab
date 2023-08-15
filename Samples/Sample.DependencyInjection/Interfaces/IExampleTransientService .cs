using Microsoft.Extensions.DependencyInjection;

namespace Sample.DependencyInjection.Interfaces
{
    internal interface IExampleTransientService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
