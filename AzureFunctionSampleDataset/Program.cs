using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using AzureFunctionSampleDataset.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices (services =>
    {
        services.AddMemoryCache();
        services.AddSingleton<EmployeeService>();        
    })
    .Build();

host.Run();
