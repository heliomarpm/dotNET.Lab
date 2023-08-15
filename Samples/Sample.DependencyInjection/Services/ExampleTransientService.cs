using Sample.DependencyInjection.Interfaces;

namespace Sample.DependencyInjection.Services;

internal sealed class ExampleTransientService : IExampleTransientService
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
}