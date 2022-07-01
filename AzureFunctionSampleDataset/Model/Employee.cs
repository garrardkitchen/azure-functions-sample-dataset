namespace AzureFunctionSampleDataset.Model;
public record Employee
{
    public Employee()
    {        
    }

    public Employee(int id)
    {
        Id = id;
    }

    public int Id { get; set; } = default!;

    public string Firstname { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public int Age { get; set; } = default!;

    public string Email { get; set; } = default!;

    public Gender Gender { get; set; } = default!;

    public decimal Salary { get; set; } = default!;

    public int SickDays { get; set; } = default!;
}
