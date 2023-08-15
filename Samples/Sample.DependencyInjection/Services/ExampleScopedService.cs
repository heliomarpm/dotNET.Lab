using Sample.DependencyInjection.Interfaces;

namespace Sample.DependencyInjection.Services;
internal sealed class ExampleScopedService : IExampleScopedService
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
}