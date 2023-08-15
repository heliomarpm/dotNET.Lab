using Microsoft.Extensions.DependencyInjection;

namespace Sample.DependencyInjection.Interfaces
{
    internal interface IReportServiceLifetime
    {
        Guid Id { get; }
        ServiceLifetime Lifetime { get; }
    }
}
