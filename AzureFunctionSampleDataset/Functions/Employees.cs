using System.Collections.Generic;
using System.Net;
using AzureFunctionSampleDataset.Model;
using AzureFunctionSampleDataset.Services;
using Bogus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace AzureFunctionSampleDataset.Functions
{
    public class Employees
    {
        private readonly ILogger _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly EmployeeService _employeeService;

        public Employees(ILoggerFactory loggerFactory, IMemoryCache memoryCache, EmployeeService employeeService)
        {
            _logger = loggerFactory.CreateLogger<Employees>();
            _memoryCache = memoryCache;
            _employeeService = employeeService;
        }

        [Function("Employees")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);            
            var employees = await _employeeService.GetEmployees();
            await response.WriteAsJsonAsync(employees);

            return response;
        }
    }
}
