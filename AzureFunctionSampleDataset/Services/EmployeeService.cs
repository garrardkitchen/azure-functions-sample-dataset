using Bogus;
using Microsoft.Extensions.Caching.Memory;
using AzureFunctionSampleDataset.Model;

namespace AzureFunctionSampleDataset.Services
{
    public class EmployeeService
    {
        private readonly IMemoryCache _memoryCache;

        public EmployeeService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _memoryCache.GetOrCreateAsync("employees", async entry =>
            {
                var userIds = 0;
                var employees = new Faker<Employee>()
                    .CustomInstantiator(f=> new Employee(userIds++))
                    .RuleFor(e => e.Firstname, f => f.Name.FirstName())
                    .RuleFor(e => e.LastName, f => f.Name.LastName())
                    .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.Firstname, e.LastName))
                    .RuleFor(e => e.Age, f => f.Random.Int(20, 60))
                    .RuleFor(e => e.Salary, f => f.Random.Decimal(30000, 200000))
                    .RuleFor(e => e.SickDays, f => f.Random.Int(0, 10))
                    .RuleFor(e => e.Gender, f => f.PickRandom<Gender>());

                return employees.Generate(100).AsEnumerable();
            });

        }
    }
}