using Sample.DependencyInjection.Interfaces;

namespace Sample.DependencyInjection.Services;
internal sealed class ExampleSingletonService : IExampleSingletonService
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
}